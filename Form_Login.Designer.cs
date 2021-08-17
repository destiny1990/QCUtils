
namespace QCUtils
{
    partial class Form_Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_loginname = new System.Windows.Forms.TextBox();
            this.tbx_pwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_verify = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.comBox_domain = new System.Windows.Forms.ComboBox();
            this.comBox_project = new System.Windows.Forms.ComboBox();
            this.tbx_serverURL = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "QC地址：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_verify);
            this.groupBox1.Controls.Add(this.tbx_pwd);
            this.groupBox1.Controls.Add(this.tbx_loginname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 84);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请先进行身份认证";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comBox_project);
            this.groupBox2.Controls.Add(this.comBox_domain);
            this.groupBox2.Controls.Add(this.btn_login);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(15, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 74);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "请选择域及项目";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "登录名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "密码：";
            // 
            // tbx_loginname
            // 
            this.tbx_loginname.Location = new System.Drawing.Point(55, 21);
            this.tbx_loginname.Name = "tbx_loginname";
            this.tbx_loginname.Size = new System.Drawing.Size(156, 21);
            this.tbx_loginname.TabIndex = 2;
            // 
            // tbx_pwd
            // 
            this.tbx_pwd.Location = new System.Drawing.Point(55, 48);
            this.tbx_pwd.Name = "tbx_pwd";
            this.tbx_pwd.Size = new System.Drawing.Size(156, 21);
            this.tbx_pwd.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "域：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "项目：";
            // 
            // btn_verify
            // 
            this.btn_verify.Location = new System.Drawing.Point(217, 35);
            this.btn_verify.Name = "btn_verify";
            this.btn_verify.Size = new System.Drawing.Size(75, 23);
            this.btn_verify.TabIndex = 4;
            this.btn_verify.Text = "身份认证";
            this.btn_verify.UseVisualStyleBackColor = true;
            this.btn_verify.Click += new System.EventHandler(this.btn_verify_Click);
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(217, 32);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "登录";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // comBox_domain
            // 
            this.comBox_domain.FormattingEnabled = true;
            this.comBox_domain.Location = new System.Drawing.Point(55, 20);
            this.comBox_domain.Name = "comBox_domain";
            this.comBox_domain.Size = new System.Drawing.Size(156, 20);
            this.comBox_domain.Sorted = true;
            this.comBox_domain.TabIndex = 5;
            // 
            // comBox_project
            // 
            this.comBox_project.FormattingEnabled = true;
            this.comBox_project.Location = new System.Drawing.Point(55, 46);
            this.comBox_project.Name = "comBox_project";
            this.comBox_project.Size = new System.Drawing.Size(156, 20);
            this.comBox_project.Sorted = true;
            this.comBox_project.TabIndex = 6;
            // 
            // tbx_serverURL
            // 
            this.tbx_serverURL.Location = new System.Drawing.Point(70, 3);
            this.tbx_serverURL.Name = "tbx_serverURL";
            this.tbx_serverURL.Size = new System.Drawing.Size(253, 21);
            this.tbx_serverURL.TabIndex = 3;
            this.tbx_serverURL.Text = "http://qc.domain.com/qcbin/";
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 200);
            this.Controls.Add(this.tbx_serverURL);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QC用例导出工具";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_verify;
        private System.Windows.Forms.TextBox tbx_pwd;
        private System.Windows.Forms.TextBox tbx_loginname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comBox_project;
        private System.Windows.Forms.ComboBox comBox_domain;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_serverURL;
    }
}

