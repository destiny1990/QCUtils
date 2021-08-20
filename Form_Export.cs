using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDAPIOLELib;

namespace QCUtils
{
    public partial class Form_Export : Form
    {
        public static TDConnection conn;
        public static TreeManager treeManager;
        private BackgroundWorker bgWorker = new BackgroundWorker();

        public class TestWithPath
        {
            public Test test;
            public string path;
        }

        public Form_Export()
        {
            InitializeComponent();
        }

        public Form_Export(TDConnection tdconn)
        {
            InitializeComponent();
            conn = tdconn;
            treeManager = (TreeManager)conn.TreeManager;
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            bgWorker.WorkerReportsProgress = true;
            bgWorker.DoWork += new DoWorkEventHandler(bw_DoWork);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_runWorkerCompleted);
        }

        private void bw_runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btn_export_background.Text = "导出用例";
            this.btn_export_background.Enabled = true;
            MessageBox.Show(e.Result.ToString());
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            this.label_progress.Text = Convert.ToString(e.ProgressPercentage) + "%";
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string path = tbx_filepath.Text;
            try
            {
                #region 用例输出至Excel
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    #region 表格数据初始化
                    int rowIndex = 0;
                    int columnIndex = 0;
                    XSSFWorkbook workbook = new XSSFWorkbook();
                    POIXMLProperties xmlProps = workbook.GetProperties();
                    CoreProperties coreProps = xmlProps.CoreProperties;
                    coreProps.Creator = "Creator";
                    coreProps.Category = "Category";
                    coreProps.Subject = "Subject";
                    ISheet excelSheet = workbook.CreateSheet("Sheet1");
                    excelSheet.SetColumnWidth(0, 30 * 256);
                    excelSheet.SetColumnWidth(1, 30 * 256);
                    excelSheet.SetColumnWidth(2, 50 * 256);
                    excelSheet.SetColumnWidth(3, 8 * 256);
                    excelSheet.SetColumnWidth(4, 80 * 256);
                    excelSheet.SetColumnWidth(5, 80 * 256);
                    IRow row = excelSheet.CreateRow(rowIndex);
                    ICellStyle cellStyle_WrapText = workbook.CreateCellStyle();
                    cellStyle_WrapText.WrapText = true;//自动换行
                    cellStyle_WrapText.VerticalAlignment = VerticalAlignment.Center;//垂直居中
                    #endregion

                    #region 表头
                    ICellStyle styleTableHead = workbook.CreateCellStyle();
                    styleTableHead.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    styleTableHead.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                    styleTableHead.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    styleTableHead.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    row.CreateCell(0).SetCellValue("主题");
                    row.CreateCell(1).SetCellValue("测试名称");
                    row.CreateCell(2).SetCellValue("描述");
                    row.CreateCell(3).SetCellValue("步骤名");
                    row.CreateCell(4).SetCellValue("输入要素");
                    row.CreateCell(5).SetCellValue("预期结果");
                    row.GetCell(0).CellStyle = styleTableHead;
                    row.GetCell(1).CellStyle = styleTableHead;
                    row.GetCell(2).CellStyle = styleTableHead;
                    row.GetCell(3).CellStyle = styleTableHead;
                    row.GetCell(4).CellStyle = styleTableHead;
                    row.GetCell(5).CellStyle = styleTableHead;
                    rowIndex++;
                    #endregion

                    #region 用例导出
                    List tests = (List)e.Argument;
                    int cur = tests.Count;

                    #region List排序
                    List<TestWithPath> testList = new List<TestWithPath> { };
                    for (int i = 0; i < cur; i++)
                    {
                        TestWithPath tmp = new TestWithPath();
                        tmp.test = tests[i + 1];
                        tmp.path = tests[i + 1].Field("TS_SUBJECT").Path + "\\" + tests[i + 1].Field("TS_NAME");
                        testList.Add(tmp);
                    }

                    testList.Sort(new TestWithPathComparer());

                    for (int i = 0; i < testList.Count; i++)
                        tests.Add(testList[i].test);

                    #endregion

                    for (int i = cur; i < tests.Count; i++)
                    {
                        #region 输出用例主题、描述等信息
                        IRow row_tmp = excelSheet.CreateRow(rowIndex);
                        //用例主题
                        string subject = tests[i + 1].Field("TS_SUBJECT").Path;
                        row_tmp.CreateCell(columnIndex).SetCellValue(subject);
                        row_tmp.GetCell(columnIndex).CellStyle = cellStyle_WrapText;
                        columnIndex++;
                        //用例名称
                        string name = tests[i + 1].Field("TS_NAME");
                        row_tmp.CreateCell(columnIndex).SetCellValue(name);
                        row_tmp.GetCell(columnIndex).CellStyle = cellStyle_WrapText;
                        columnIndex++;
                        //用例描述
                        string description = HtmlToPlainText(tests[i + 1].Field("TS_DESCRIPTION"));
                        row_tmp.CreateCell(columnIndex).SetCellValue(description);
                        row_tmp.GetCell(columnIndex).CellStyle = cellStyle_WrapText;
                        columnIndex++;
                        #endregion

                        #region 输出用例步骤
                        DesignStepFactory designStepFactory = tests[i + 1].DesignStepFactory;
                        //TDFilter filter = (TDFilter)designStepFactory.Filter;
                        //filter.set_Order("DS_STEP_ORDER",1);
                        //filter.set_OrderDirection("DS_STEP_ORDER", 1);
                        //List designSteps = designStepFactory.NewList(filter.Text);
                        List designSteps = designStepFactory.NewList("");
                        if (0 != designSteps.Count)
                        {
                            rowIndex++;
                            foreach (DesignStep ds in designSteps)
                            {
                                IRow row_tmp_step = excelSheet.CreateRow(rowIndex);

                                //步骤名
                                string stepName = (string)ds.StepName;
                                row_tmp_step.CreateCell(columnIndex).SetCellValue(stepName);
                                columnIndex++;

                                //步骤描述
                                string stepDescription = (string)ds.StepDescription;
                                row_tmp_step.CreateCell(columnIndex).SetCellValue(stepDescription);
                                row_tmp_step.GetCell(columnIndex).CellStyle = cellStyle_WrapText;
                                columnIndex++;

                                //预期结果
                                string stepExpectedResult = (string)ds.StepExpectedResult;
                                row_tmp_step.CreateCell(columnIndex).SetCellValue(stepExpectedResult);
                                row_tmp_step.GetCell(columnIndex).CellStyle = cellStyle_WrapText;
                                columnIndex -= 2;
                                rowIndex++;
                            }
                            columnIndex = 0;
                        }
                        else
                        {
                            rowIndex++;
                            columnIndex = 0;
                            continue;
                        }
                        #endregion
                        //进度传递
                        int progress = i * 100 / cur;
                        progress = progress > 100 ? 100 : progress;
                        bgWorker.ReportProgress(progress, "Working");
                    }
                    #endregion

                    workbook.Write(fs);
                    fs.Close();
                    bgWorker.ReportProgress(100, "Finished");
                }
                #endregion
                e.Result = "导出完毕！";
            }
            catch (Exception ex) { e.Result = "导出异常:" + ex.Message; }
        }

        private void Form_Export_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.DisconnectProject();
            conn.Logout();
            conn.ReleaseConnection();
            this.Dispose(true);
        }

        private void Form_Export_Load(object sender, EventArgs e)
        {
            MessageBox.Show("已进入项目：" + conn.ProjectName);
            try
            {
                string str = treeManager.get_RootList(1)[1].ToString();
                SubjectNode sNode = (SubjectNode)treeManager.get_NodeByPath(str);
                TreeNode node = new TreeNode
                {
                    Text = str,
                    ToolTipText = str
                };
                if (sNode.Count > 0)
                {
                    TreeNode node_fake = new TreeNode
                    {
                        Text = "fake",
                        ToolTipText = str
                    };
                    node.Nodes.Add(node_fake);
                }
                this.treeView1.Nodes.Add(node);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_filepath_Click(object sender, EventArgs e)
        {
            SaveFileDialog a = new SaveFileDialog();
            a.Filter = "Excel文件(*.xlsx)|*.xlsx";
            a.ShowDialog();
            tbx_filepath.Text = a.FileName;
        }

        private void btn_export_background_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            label_progress.Text = "0%";
            if (tbx_testcase_path.Text.Equals(String.Empty))
            {
                MessageBox.Show("请选择用例目录！");
                return;
            }
            if (tbx_filepath.Text.Equals(String.Empty))
            {
                MessageBox.Show("请选择文件输出路径！");
                return;
            }
            try
            {
                SubjectNode sNode = (SubjectNode)treeManager.get_NodeByPath(tbx_testcase_path.Text);
                List tests = sNode.FindTests("", false, null);
                if (tests == null || tests.Count == 0)
                {
                    MessageBox.Show("没有用例可以导出！");
                    return;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("确定导出这" + tests.Count + "个用例么？", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        this.btn_export_background.Text = "用例导出中！";
                        this.btn_export_background.Enabled = false;
                        bgWorker.RunWorkerAsync(tests);
                    }
                    else
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //展开节点前需要做的操作
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            SubjectNode sNode = (SubjectNode)treeManager.get_NodeByPath(e.Node.ToolTipText);
            e.Node.Nodes.Clear();
            this.Expand_Node(sNode, e.Node);
        }

        //展开treeview时获取节点并排序
        private void Expand_Node(SubjectNode sNode, TreeNode tNode)
        {
            try
            {
                List<TreeNode> listTreeNode = new List<TreeNode> { };
                for (int i = 0; i < sNode.Count; i++)
                {
                    TreeNode node = new TreeNode();
                    SubjectNode childNode = (SubjectNode)sNode.get_Child(i + 1);
                    node.Text = childNode.Name;
                    node.ToolTipText = childNode.Path;
                    if (childNode.Count > 0)
                    {
                        TreeNode fakeNode = new TreeNode
                        {
                            Text = "fake",
                            ToolTipText = "fake"
                        };
                        node.Nodes.Add(fakeNode);
                    }
                    listTreeNode.Add(node);
                }
                listTreeNode.Sort(new TreeNodeComparer());
                foreach (var tmp in listTreeNode)
                {
                    tNode.Nodes.Add(tmp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //选中节点时更新用例所在目录
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tbx_testcase_path.Text = e.Node.ToolTipText;
        }

        //HTML转换成普通文本
        public static string HtmlToPlainText(String html)
        {
            if (string.IsNullOrEmpty(html))
                return html;
            //matches one or more (white space or line breaks) between '>' and '<'
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";
            //match any character between '<' and '>', even when end tag is missing
            const string stripFormatting = @"<[^>]*(>|$)";
            const string lineBreak = @"<(br|BR|p|P)\s{0,1}\/{0,1}>";
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);
            string text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);
            //Remove the nbsp and amp
            text = text.Replace("&nbsp;", "").Replace("&amp;", "");
            return text;
        }

        #region 自定义排序
        public class TestWithPathComparer : IComparer<TestWithPath>
        {
            public int Compare(TestWithPath p1, TestWithPath p2)
            {
                return p1.path.CompareTo(p2.path);
            }
        }

        public class TreeNodeComparer : IComparer<TreeNode>
        {
            public int Compare(TreeNode p1, TreeNode p2)
            {
                return p1.Text.CompareTo(p2.Text);
            }
        }
        #endregion
    }
}
