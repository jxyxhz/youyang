namespace WindowsFormsApplication1
{
    partial class Test
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Test));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.webBrowser3 = new System.Windows.Forms.WebBrowser();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtCopyrightInfo = new System.Windows.Forms.TextBox();
            this.txtCmpName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(4, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(476, 413);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webBrowser1);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 9F);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(468, 387);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主界面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(3, 6);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(457, 372);
            this.webBrowser1.TabIndex = 6;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.webBrowser2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(468, 387);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "本次排行";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(188, 346);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "刷新排行";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // webBrowser2
            // 
            this.webBrowser2.Location = new System.Drawing.Point(25, 20);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScrollBarsEnabled = false;
            this.webBrowser2.Size = new System.Drawing.Size(400, 320);
            this.webBrowser2.TabIndex = 7;
            this.webBrowser2.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.webBrowser3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(468, 387);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "今日排行";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(188, 346);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "刷新排行";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // webBrowser3
            // 
            this.webBrowser3.Location = new System.Drawing.Point(25, 20);
            this.webBrowser3.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser3.Name = "webBrowser3";
            this.webBrowser3.ScrollBarsEnabled = false;
            this.webBrowser3.Size = new System.Drawing.Size(400, 320);
            this.webBrowser3.TabIndex = 8;
            this.webBrowser3.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtCopyrightInfo);
            this.tabPage3.Controls.Add(this.txtCmpName);
            this.tabPage3.Controls.Add(this.txtUserName);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(468, 387);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "关于";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtCopyrightInfo
            // 
            this.txtCopyrightInfo.Location = new System.Drawing.Point(136, 177);
            this.txtCopyrightInfo.Multiline = true;
            this.txtCopyrightInfo.Name = "txtCopyrightInfo";
            this.txtCopyrightInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCopyrightInfo.Size = new System.Drawing.Size(257, 122);
            this.txtCopyrightInfo.TabIndex = 11;
            // 
            // txtCmpName
            // 
            this.txtCmpName.Location = new System.Drawing.Point(136, 115);
            this.txtCmpName.Name = "txtCmpName";
            this.txtCmpName.Size = new System.Drawing.Size(257, 21);
            this.txtCmpName.TabIndex = 10;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(136, 58);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(257, 21);
            this.txtUserName.TabIndex = 9;
            this.txtUserName.Text = "国家领导";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 8;
            this.label12.Text = "版权信息:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(65, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "公司名称:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(89, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "姓名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("隶书", 23F);
            this.label1.Location = new System.Drawing.Point(87, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 31);
            this.label1.TabIndex = 56;
            this.label1.Text = "悠扬棋牌自动抢红包";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F);
            this.button2.Location = new System.Drawing.Point(249, 494);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 30);
            this.button2.TabIndex = 57;
            this.button2.Text = "停止刷新";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F);
            this.button1.Location = new System.Drawing.Point(111, 494);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 30);
            this.button1.TabIndex = 58;
            this.button1.Text = "开始刷新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 540);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Test";
            this.Text = "自动刷新";
            this.Load += new System.EventHandler(this.Test_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtCopyrightInfo;
        private System.Windows.Forms.TextBox txtCmpName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.WebBrowser webBrowser3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}