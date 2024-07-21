namespace LiliumLauncher
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
            this.groupBoxStaarupParms = new System.Windows.Forms.GroupBox();
            this.chkUpdates = new System.Windows.Forms.CheckBox();
            this.chkLauncherMain = new System.Windows.Forms.CheckBox();
            this.chkNoWebView = new System.Windows.Forms.CheckBox();
            this.groupBoxWebview2Default = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBoxLauncherMethod = new System.Windows.Forms.GroupBox();
            this.radLauncherBrowser = new System.Windows.Forms.RadioButton();
            this.radLauncherWebView = new System.Windows.Forms.RadioButton();
            this.radLauncherDef = new System.Windows.Forms.RadioButton();
            this.groupBoxLauncherLang = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chkSaveLog = new System.Windows.Forms.CheckBox();
            this.groupBoxStaarupParms.SuspendLayout();
            this.groupBoxWebview2Default.SuspendLayout();
            this.groupBoxLauncherMethod.SuspendLayout();
            this.groupBoxLauncherLang.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(399, 221);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(87, 28);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "套用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(307, 221);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "確定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBoxStaarupParms
            // 
            this.groupBoxStaarupParms.Controls.Add(this.chkSaveLog);
            this.groupBoxStaarupParms.Controls.Add(this.chkUpdates);
            this.groupBoxStaarupParms.Controls.Add(this.chkLauncherMain);
            this.groupBoxStaarupParms.Controls.Add(this.chkNoWebView);
            this.groupBoxStaarupParms.Location = new System.Drawing.Point(10, 9);
            this.groupBoxStaarupParms.Name = "groupBoxStaarupParms";
            this.groupBoxStaarupParms.Size = new System.Drawing.Size(261, 109);
            this.groupBoxStaarupParms.TabIndex = 2;
            this.groupBoxStaarupParms.TabStop = false;
            this.groupBoxStaarupParms.Text = "啟動參數";
            // 
            // chkUpdates
            // 
            this.chkUpdates.AutoSize = true;
            this.chkUpdates.Checked = true;
            this.chkUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdates.Location = new System.Drawing.Point(9, 62);
            this.chkUpdates.Name = "chkUpdates";
            this.chkUpdates.Size = new System.Drawing.Size(108, 16);
            this.chkUpdates.TabIndex = 2;
            this.chkUpdates.Text = "啟動時檢查更新";
            this.chkUpdates.UseVisualStyleBackColor = true;
            this.chkUpdates.CheckedChanged += new System.EventHandler(this.chkUpdates_CheckedChanged);
            // 
            // chkLauncherMain
            // 
            this.chkLauncherMain.AutoSize = true;
            this.chkLauncherMain.Checked = true;
            this.chkLauncherMain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLauncherMain.Location = new System.Drawing.Point(9, 40);
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
            this.chkNoWebView.Location = new System.Drawing.Point(9, 18);
            this.chkNoWebView.Name = "chkNoWebView";
            this.chkNoWebView.Size = new System.Drawing.Size(136, 16);
            this.chkNoWebView.TabIndex = 0;
            this.chkNoWebView.Text = "關閉 WebView 主框架";
            this.chkNoWebView.UseVisualStyleBackColor = true;
            this.chkNoWebView.Click += new System.EventHandler(this.chkNoWebView_Click);
            // 
            // groupBoxWebview2Default
            // 
            this.groupBoxWebview2Default.Controls.Add(this.label2);
            this.groupBoxWebview2Default.Controls.Add(this.label1);
            this.groupBoxWebview2Default.Controls.Add(this.textBox2);
            this.groupBoxWebview2Default.Controls.Add(this.textBox1);
            this.groupBoxWebview2Default.Location = new System.Drawing.Point(10, 124);
            this.groupBoxWebview2Default.Name = "groupBoxWebview2Default";
            this.groupBoxWebview2Default.Size = new System.Drawing.Size(261, 125);
            this.groupBoxWebview2Default.TabIndex = 3;
            this.groupBoxWebview2Default.TabStop = false;
            this.groupBoxWebview2Default.Text = "WebView2 預設載入網址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "自訂啟動器框架載入網址";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "自訂主框架首頁網址";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 91);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(246, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "https://www.snkms.com/minecraftNews.html";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "https://www.snkms.com/chat/webchat2/";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBoxLauncherMethod
            // 
            this.groupBoxLauncherMethod.Controls.Add(this.radLauncherBrowser);
            this.groupBoxLauncherMethod.Controls.Add(this.radLauncherWebView);
            this.groupBoxLauncherMethod.Controls.Add(this.radLauncherDef);
            this.groupBoxLauncherMethod.Location = new System.Drawing.Point(277, 100);
            this.groupBoxLauncherMethod.Name = "groupBoxLauncherMethod";
            this.groupBoxLauncherMethod.Size = new System.Drawing.Size(209, 103);
            this.groupBoxLauncherMethod.TabIndex = 4;
            this.groupBoxLauncherMethod.TabStop = false;
            this.groupBoxLauncherMethod.Text = "啟動器登入方式";
            // 
            // radLauncherBrowser
            // 
            this.radLauncherBrowser.AutoSize = true;
            this.radLauncherBrowser.Location = new System.Drawing.Point(10, 74);
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
            this.radLauncherWebView.Location = new System.Drawing.Point(10, 48);
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
            this.radLauncherDef.Location = new System.Drawing.Point(10, 22);
            this.radLauncherDef.Name = "radLauncherDef";
            this.radLauncherDef.Size = new System.Drawing.Size(166, 16);
            this.radLauncherDef.TabIndex = 0;
            this.radLauncherDef.TabStop = true;
            this.radLauncherDef.Text = "預設 (依條件詢問啟動方式)";
            this.radLauncherDef.UseVisualStyleBackColor = true;
            this.radLauncherDef.Click += new System.EventHandler(this.radLauncherDef_Click);
            // 
            // groupBoxLauncherLang
            // 
            this.groupBoxLauncherLang.Controls.Add(this.panel1);
            this.groupBoxLauncherLang.Controls.Add(this.comboBox1);
            this.groupBoxLauncherLang.Location = new System.Drawing.Point(277, 9);
            this.groupBoxLauncherLang.Name = "groupBoxLauncherLang";
            this.groupBoxLauncherLang.Size = new System.Drawing.Size(209, 85);
            this.groupBoxLauncherLang.TabIndex = 5;
            this.groupBoxLauncherLang.TabStop = false;
            this.groupBoxLauncherLang.Text = "啟動器顯示語言";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(9, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 32);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "更改語言設定須重新啟動程式";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 12;
            this.comboBox1.Location = new System.Drawing.Point(6, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(193, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chkSaveLog
            // 
            this.chkSaveLog.AutoSize = true;
            this.chkSaveLog.Location = new System.Drawing.Point(9, 84);
            this.chkSaveLog.Name = "chkSaveLog";
            this.chkSaveLog.Size = new System.Drawing.Size(132, 16);
            this.chkSaveLog.TabIndex = 3;
            this.chkSaveLog.Text = "儲存啟動器執行日誌";
            this.chkSaveLog.UseVisualStyleBackColor = true;
            this.chkSaveLog.CheckedChanged += new System.EventHandler(this.chkSaveLog_CheckedChanged);
            // 
            // settingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(498, 261);
            this.Controls.Add(this.groupBoxLauncherLang);
            this.Controls.Add(this.groupBoxLauncherMethod);
            this.Controls.Add(this.groupBoxWebview2Default);
            this.Controls.Add(this.groupBoxStaarupParms);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnApply);
            this.Font = new System.Drawing.Font("新細明體", 9F);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(514, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(514, 300);
            this.Name = "settingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系統設定";
            this.Load += new System.EventHandler(this.settingForm_Load);
            this.groupBoxStaarupParms.ResumeLayout(false);
            this.groupBoxStaarupParms.PerformLayout();
            this.groupBoxWebview2Default.ResumeLayout(false);
            this.groupBoxWebview2Default.PerformLayout();
            this.groupBoxLauncherMethod.ResumeLayout(false);
            this.groupBoxLauncherMethod.PerformLayout();
            this.groupBoxLauncherLang.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBoxStaarupParms;
        private System.Windows.Forms.CheckBox chkLauncherMain;
        private System.Windows.Forms.CheckBox chkNoWebView;
        private System.Windows.Forms.GroupBox groupBoxWebview2Default;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBoxLauncherMethod;
        private System.Windows.Forms.RadioButton radLauncherBrowser;
        private System.Windows.Forms.RadioButton radLauncherWebView;
        private System.Windows.Forms.RadioButton radLauncherDef;
        private System.Windows.Forms.CheckBox chkUpdates;
        private System.Windows.Forms.GroupBox groupBoxLauncherLang;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkSaveLog;
    }
}