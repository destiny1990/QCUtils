
namespace QCUtils
{
    partial class Form_Export
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_export_background = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_progress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_testcase_path = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_filepath = new System.Windows.Forms.TextBox();
            this.btn_filepath = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(265, 528);
            this.treeView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_filepath);
            this.groupBox1.Controls.Add(this.tbx_filepath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbx_testcase_path);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(284, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 222);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作面板";
            // 
            // btn_export_background
            // 
            this.btn_export_background.Location = new System.Drawing.Point(284, 463);
            this.btn_export_background.Name = "btn_export_background";
            this.btn_export_background.Size = new System.Drawing.Size(403, 47);
            this.btn_export_background.TabIndex = 2;
            this.btn_export_background.Text = "导出用例";
            this.btn_export_background.UseVisualStyleBackColor = true;
            this.btn_export_background.Click += new System.EventHandler(this.btn_export_background_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(284, 516);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(356, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // label_progress
            // 
            this.label_progress.AutoSize = true;
            this.label_progress.Location = new System.Drawing.Point(656, 522);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(17, 12);
            this.label_progress.TabIndex = 4;
            this.label_progress.Text = "0%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "当前目录地址：";
            // 
            // tbx_testcase_path
            // 
            this.tbx_testcase_path.Location = new System.Drawing.Point(101, 20);
            this.tbx_testcase_path.Multiline = true;
            this.tbx_testcase_path.Name = "tbx_testcase_path";
            this.tbx_testcase_path.Size = new System.Drawing.Size(245, 60);
            this.tbx_testcase_path.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "用例详情：";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "主题",
            "测试名称",
            "描述",
            "步骤名",
            "输入要素",
            "预期结果"});
            this.checkedListBox1.Location = new System.Drawing.Point(101, 86);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(245, 100);
            this.checkedListBox1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "保存路径：";
            // 
            // tbx_filepath
            // 
            this.tbx_filepath.Location = new System.Drawing.Point(101, 193);
            this.tbx_filepath.Name = "tbx_filepath";
            this.tbx_filepath.Size = new System.Drawing.Size(245, 21);
            this.tbx_filepath.TabIndex = 5;
            // 
            // btn_filepath
            // 
            this.btn_filepath.Location = new System.Drawing.Point(352, 191);
            this.btn_filepath.Name = "btn_filepath";
            this.btn_filepath.Size = new System.Drawing.Size(44, 23);
            this.btn_filepath.TabIndex = 6;
            this.btn_filepath.Text = "浏览";
            this.btn_filepath.UseVisualStyleBackColor = true;
            this.btn_filepath.Click += new System.EventHandler(this.btn_filepath_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(284, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 215);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "使用说明";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(389, 189);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "如果您觉得有用，请点个star!";
            // 
            // Form_Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 552);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label_progress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_export_background);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form_Export";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用例导出";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Export_FormClosing);
            this.Load += new System.EventHandler(this.Form_Export_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_filepath;
        private System.Windows.Forms.TextBox tbx_filepath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_testcase_path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_export_background;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_progress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}