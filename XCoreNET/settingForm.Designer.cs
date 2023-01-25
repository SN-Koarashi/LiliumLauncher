namespace XCoreNET
{
    partial class settingForm
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
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLauncherMain = new System.Windows.Forms.CheckBox();
            this.chkNoWebView = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radLauncherBrowser = new System.Windows.Forms.RadioButton();
            this.radLauncherWebView = new System.Windows.Forms.RadioButton();
            this.radLauncherDef = new System.Windows.Forms.RadioButton();
            this.chkUpdates = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(311, 184);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(87, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "套用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(219, 184);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "確定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUpdates);
            this.groupBox1.Controls.Add(this.chkLauncherMain);
            this.groupBox1.Controls.Add(this.chkNoWebView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 72);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "啟動參數";
            // 
            // chkLauncherMain
            // 
            this.chkLauncherMain.AutoSize = true;
            this.chkLauncherMain.Checked = true;
            this.chkLauncherMain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLauncherMain.Location = new System.Drawing.Point(7, 45);
            this.chkLauncherMain.Name = "chkLauncherMain";
            this.chkLauncherMain.Size = new System.Drawing.Size(183, 16);
            this.chkLauncherMain.TabIndex = 1;
            this.chkLauncherMain.Text = "將 Minecraft 啟動器作為主視窗";
            this.chkLauncherMain.UseVisualStyleBackColor = true;
            this.chkLauncherMain.Click += new System.EventHandler(this.chkLauncherMain_Click);
            // 
            // chkNoWebView
            // 
            this.chkNoWebView.AutoSize = true;
            this.chkNoWebView.Location = new System.Drawing.Point(7, 22);
            this.chkNoWebView.Name = "chkNoWebView";
            this.chkNoWebView.Size = new System.Drawing.Size(136, 16);
            this.chkNoWebView.TabIndex = 0;
            this.chkNoWebView.Text = "關閉 WebView 主框架";
            this.chkNoWebView.UseVisualStyleBackColor = true;
            this.chkNoWebView.Click += new System.EventHandler(this.chkNoWebView_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 119);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "主要設定";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "自訂啟動器框架載入網址";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "自訂主框架首頁網址";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 86);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(183, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "https://www.snkms.com/minecraftNews.html";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "https://www.snkms.com/chat/webchat2/";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radLauncherBrowser);
            this.groupBox3.Controls.Add(this.radLauncherWebView);
            this.groupBox3.Controls.Add(this.radLauncherDef);
            this.groupBox3.Location = new System.Drawing.Point(218, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(179, 88);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "啟動器登入方式";
            // 
            // radLauncherBrowser
            // 
            this.radLauncherBrowser.AutoSize = true;
            this.radLauncherBrowser.Location = new System.Drawing.Point(7, 65);
            this.radLauncherBrowser.Name = "radLauncherBrowser";
            this.radLauncherBrowser.Size = new System.Drawing.Size(143, 16);
            this.radLauncherBrowser.TabIndex = 5;
            this.radLauncherBrowser.TabStop = true;
            this.radLauncherBrowser.Text = "永遠以原生瀏覽器登入";
            this.radLauncherBrowser.UseVisualStyleBackColor = true;
            this.radLauncherBrowser.Click += new System.EventHandler(this.radLauncherBrowser_Click);
            // 
            // radLauncherWebView
            // 
            this.radLauncherWebView.AutoSize = true;
            this.radLauncherWebView.Location = new System.Drawing.Point(7, 43);
            this.radLauncherWebView.Name = "radLauncherWebView";
            this.radLauncherWebView.Size = new System.Drawing.Size(165, 16);
            this.radLauncherWebView.TabIndex = 1;
            this.radLauncherWebView.TabStop = true;
            this.radLauncherWebView.Text = "永遠以 WevView2 框架登入";
            this.radLauncherWebView.UseVisualStyleBackColor = true;
            this.radLauncherWebView.Click += new System.EventHandler(this.radLauncherWebView_Click);
            // 
            // radLauncherDef
            // 
            this.radLauncherDef.AutoSize = true;
            this.radLauncherDef.Checked = true;
            this.radLauncherDef.Location = new System.Drawing.Point(7, 20);
            this.radLauncherDef.Name = "radLauncherDef";
            this.radLauncherDef.Size = new System.Drawing.Size(166, 16);
            this.radLauncherDef.TabIndex = 0;
            this.radLauncherDef.TabStop = true;
            this.radLauncherDef.Text = "預設 (依條件詢問啟動方式)";
            this.radLauncherDef.UseVisualStyleBackColor = true;
            this.radLauncherDef.Click += new System.EventHandler(this.radLauncherDef_Click);
            // 
            // chkUpdates
            // 
            this.chkUpdates.AutoSize = true;
            this.chkUpdates.Checked = true;
            this.chkUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdates.Location = new System.Drawing.Point(206, 21);
            this.chkUpdates.Name = "chkUpdates";
            this.chkUpdates.Size = new System.Drawing.Size(108, 16);
            this.chkUpdates.TabIndex = 2;
            this.chkUpdates.Text = "啟動時檢查更新";
            this.chkUpdates.UseVisualStyleBackColor = true;
            this.chkUpdates.CheckedChanged += new System.EventHandler(this.chkUpdates_CheckedChanged);
            // 
            // settingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 214);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnApply);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(426, 253);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(426, 253);
            this.Name = "settingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系統設定";
            this.Load += new System.EventHandler(this.settingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkLauncherMain;
        private System.Windows.Forms.CheckBox chkNoWebView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radLauncherBrowser;
        private System.Windows.Forms.RadioButton radLauncherWebView;
        private System.Windows.Forms.RadioButton radLauncherDef;
        private System.Windows.Forms.CheckBox chkUpdates;
    }
}