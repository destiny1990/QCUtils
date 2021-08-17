using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            this.btn_export_background.Text = "用例导出";
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

        public class TestWithPathComparer : IComparer<TestWithPath>
        {
            public int Compare(TestWithPath p1, TestWithPath p2)
            {
                return p1.path.CompareTo(p2.path);
            }
        }

        public class TreeNodeComparer:IComparer<TreeNode>
        {
            public int Compare(TreeNode p1, TreeNode p2)
        {
            return p1.Text.CompareTo(p2.Text);
        }
    }

}
}
