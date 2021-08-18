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
    public partial class Form_Login : Form
    {
        public static TDConnection tdconn;
        public Form_Login()
        {
            InitializeComponent();
        }

        private void btn_verify_Click(object sender, EventArgs e)
        {
            if (tbx_loginname.Text == String.Empty)
            {
                MessageBox.Show("请输入登录名！");
                return;
            }
            if (tbx_pwd.Text == String.Empty)
            {
                MessageBox.Show("请输入密码！");
                return;
            }
            comBox_domain.Items.Clear();
            comBox_project.Items.Clear();

            try
            {
                tdconn = new TDConnection();
                tdconn.InitConnectionEx(tbx_serverURL.Text);
                tdconn.Login(tbx_loginname.Text, tbx_pwd.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("身份验证失败!错误原因:"+ex.ToString());
                return;
            }
            List domainList = tdconn.DomainsList;
            foreach (var domain in domainList)
                comBox_domain.Items.Add(domain);
            List projectList = tdconn.ProjectsList;
            foreach (var domain in projectList)
                comBox_project.Items.Add(domain);
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (comBox_domain.Text.Equals(String.Empty))
            {
                MessageBox.Show("请选择域！");
                return;
            }
            if (comBox_project.Text.Equals(String.Empty))
            {
                MessageBox.Show("请选择项目！");
                return;
            }
            try
            {
                tdconn.Connect(comBox_domain.Text, comBox_project.Text);
                Form_Export formExport = new Form_Export(tdconn);
                formExport.Disposed += new EventHandler(form_export_Disposed);
                formExport.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("登陆项目失败！");
                return;
            }
        }

        private void form_export_Disposed(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
