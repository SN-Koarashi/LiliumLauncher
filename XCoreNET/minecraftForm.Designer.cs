namespace XCoreNET
{
    partial class minecraftForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(minecraftForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.mainPage = new System.Windows.Forms.TabPage();
            this.panelBody = new System.Windows.Forms.Panel();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.textVersionSelected = new System.Windows.Forms.TextBox();
            this.versionList = new System.Windows.Forms.ComboBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.avatar = new System.Windows.Forms.PictureBox();
            this.settingPage = new System.Windows.Forms.TabPage();
            this.groupBoxVersion = new System.Windows.Forms.GroupBox();
            this.chkBoxSnapshot = new System.Windows.Forms.CheckBox();
            this.chkBoxRelease = new System.Windows.Forms.CheckBox();
            this.groupBoxAccount = new System.Windows.Forms.GroupBox();
            this.btnLogoutAll = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSwitchAcc = new System.Windows.Forms.Button();
            this.groupBoxMainProg = new System.Windows.Forms.GroupBox();
            this.btnChkUpdate = new System.Windows.Forms.Button();
            this.btnMainSetting = new System.Windows.Forms.Button();
            this.groupBoxInterval = new System.Windows.Forms.GroupBox();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.panelSettingsTop = new System.Windows.Forms.Panel();
            this.groupBoxDataFolder = new System.Windows.Forms.GroupBox();
            this.panelSettingsLeft = new System.Windows.Forms.Panel();
            this.panelSettingsInsideRight = new System.Windows.Forms.Panel();
            this.radBtnMain = new System.Windows.Forms.RadioButton();
            this.textBoxMain = new System.Windows.Forms.TextBox();
            this.panelSettingsInsideLeft = new System.Windows.Forms.Panel();
            this.radBtnAD = new System.Windows.Forms.RadioButton();
            this.textBoxAD = new System.Windows.Forms.TextBox();
            this.panelSettingsRight = new System.Windows.Forms.Panel();
            this.btnVerifyFile = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.debugPage = new System.Windows.Forms.TabPage();
            this.textBox = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxVersionReload = new System.Windows.Forms.GroupBox();
            this.buttonVerReload = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.mainPage.SuspendLayout();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.settingPage.SuspendLayout();
            this.groupBoxVersion.SuspendLayout();
            this.groupBoxAccount.SuspendLayout();
            this.groupBoxMainProg.SuspendLayout();
            this.groupBoxInterval.SuspendLayout();
            this.panelSettingsTop.SuspendLayout();
            this.groupBoxDataFolder.SuspendLayout();
            this.panelSettingsLeft.SuspendLayout();
            this.panelSettingsInsideRight.SuspendLayout();
            this.panelSettingsInsideLeft.SuspendLayout();
            this.panelSettingsRight.SuspendLayout();
            this.debugPage.SuspendLayout();
            this.groupBoxVersionReload.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.mainPage);
            this.tabControl1.Controls.Add(this.settingPage);
            this.tabControl1.Controls.Add(this.debugPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 321);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // mainPage
            // 
            this.mainPage.BackColor = System.Drawing.SystemColors.Control;
            this.mainPage.Controls.Add(this.panelBody);
            this.mainPage.Controls.Add(this.panelFooter);
            this.mainPage.Controls.Add(this.panelHeader);
            this.mainPage.Location = new System.Drawing.Point(4, 26);
            this.mainPage.Name = "mainPage";
            this.mainPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainPage.Size = new System.Drawing.Size(456, 291);
            this.mainPage.TabIndex = 0;
            this.mainPage.Text = "主畫面";
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.webView);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(3, 44);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(450, 176);
            this.panelBody.TabIndex = 8;
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.SystemColors.Control;
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView.Location = new System.Drawing.Point(0, 0);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(450, 176);
            this.webView.Source = new System.Uri("https://www.snkms.com/minecraftNews.html", System.UriKind.Absolute);
            this.webView.TabIndex = 0;
            this.webView.ZoomFactor = 1D;
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.textStatus);
            this.panelFooter.Controls.Add(this.btnLaunch);
            this.panelFooter.Controls.Add(this.progressBar);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(3, 220);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(450, 68);
            this.panelFooter.TabIndex = 7;
            // 
            // textStatus
            // 
            this.textStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textStatus.BackColor = System.Drawing.SystemColors.Control;
            this.textStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textStatus.Font = new System.Drawing.Font("Verdana", 10F);
            this.textStatus.Location = new System.Drawing.Point(5, 14);
            this.textStatus.Name = "textStatus";
            this.textStatus.ReadOnly = true;
            this.textStatus.Size = new System.Drawing.Size(340, 17);
            this.textStatus.TabIndex = 5;
            // 
            // btnLaunch
            // 
            this.btnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaunch.Enabled = false;
            this.btnLaunch.Location = new System.Drawing.Point(351, 5);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(96, 31);
            this.btnLaunch.TabIndex = 4;
            this.btnLaunch.Text = "啟動遊戲";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 40);
            this.progressBar.Margin = new System.Windows.Forms.Padding(15);
            this.progressBar.MarqueeAnimationSpeed = 5;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(450, 28);
            this.progressBar.TabIndex = 2;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.textVersionSelected);
            this.panelHeader.Controls.Add(this.versionList);
            this.panelHeader.Controls.Add(this.textUser);
            this.panelHeader.Controls.Add(this.avatar);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(3, 3);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(450, 41);
            this.panelHeader.TabIndex = 6;
            // 
            // textVersionSelected
            // 
            this.textVersionSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textVersionSelected.Location = new System.Drawing.Point(265, 9);
            this.textVersionSelected.Name = "textVersionSelected";
            this.textVersionSelected.ReadOnly = true;
            this.textVersionSelected.Size = new System.Drawing.Size(160, 25);
            this.textVersionSelected.TabIndex = 1;
            this.textVersionSelected.Click += new System.EventHandler(this.textVersionSelected_Click);
            // 
            // versionList
            // 
            this.versionList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.versionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionList.FormattingEnabled = true;
            this.versionList.Location = new System.Drawing.Point(426, 9);
            this.versionList.Name = "versionList";
            this.versionList.Size = new System.Drawing.Size(19, 25);
            this.versionList.TabIndex = 7;
            this.versionList.SelectionChangeCommitted += new System.EventHandler(this.versionList_SelectionChangeCommitted);
            // 
            // textUser
            // 
            this.textUser.BackColor = System.Drawing.SystemColors.Control;
            this.textUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textUser.Font = new System.Drawing.Font("Verdana", 12F);
            this.textUser.Location = new System.Drawing.Point(41, 10);
            this.textUser.Name = "textUser";
            this.textUser.ReadOnly = true;
            this.textUser.Size = new System.Drawing.Size(218, 20);
            this.textUser.TabIndex = 6;
            this.textUser.Text = "User";
            this.textUser.Visible = false;
            // 
            // avatar
            // 
            this.avatar.Location = new System.Drawing.Point(3, 3);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(32, 32);
            this.avatar.TabIndex = 5;
            this.avatar.TabStop = false;
            this.avatar.Visible = false;
            this.avatar.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.avatar_LoadCompleted);
            this.avatar.Click += new System.EventHandler(this.avatar_Click);
            // 
            // settingPage
            // 
            this.settingPage.BackColor = System.Drawing.SystemColors.Control;
            this.settingPage.Controls.Add(this.groupBoxVersionReload);
            this.settingPage.Controls.Add(this.groupBoxVersion);
            this.settingPage.Controls.Add(this.groupBoxAccount);
            this.settingPage.Controls.Add(this.groupBoxMainProg);
            this.settingPage.Controls.Add(this.groupBoxInterval);
            this.settingPage.Controls.Add(this.panelSettingsTop);
            this.settingPage.Location = new System.Drawing.Point(4, 26);
            this.settingPage.Name = "settingPage";
            this.settingPage.Size = new System.Drawing.Size(456, 291);
            this.settingPage.TabIndex = 2;
            this.settingPage.Text = "設定";
            // 
            // groupBoxVersion
            // 
            this.groupBoxVersion.Controls.Add(this.chkBoxSnapshot);
            this.groupBoxVersion.Controls.Add(this.chkBoxRelease);
            this.groupBoxVersion.Location = new System.Drawing.Point(266, 106);
            this.groupBoxVersion.Name = "groupBoxVersion";
            this.groupBoxVersion.Size = new System.Drawing.Size(83, 85);
            this.groupBoxVersion.TabIndex = 8;
            this.groupBoxVersion.TabStop = false;
            this.groupBoxVersion.Text = "版本選項";
            // 
            // chkBoxSnapshot
            // 
            this.chkBoxSnapshot.AutoSize = true;
            this.chkBoxSnapshot.Location = new System.Drawing.Point(9, 53);
            this.chkBoxSnapshot.Name = "chkBoxSnapshot";
            this.chkBoxSnapshot.Size = new System.Drawing.Size(69, 22);
            this.chkBoxSnapshot.TabIndex = 1;
            this.chkBoxSnapshot.Text = "快照版";
            this.chkBoxSnapshot.UseVisualStyleBackColor = true;
            this.chkBoxSnapshot.Click += new System.EventHandler(this.chkBoxSnapshot_Click);
            // 
            // chkBoxRelease
            // 
            this.chkBoxRelease.AutoSize = true;
            this.chkBoxRelease.Checked = true;
            this.chkBoxRelease.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxRelease.Location = new System.Drawing.Point(9, 25);
            this.chkBoxRelease.Name = "chkBoxRelease";
            this.chkBoxRelease.Size = new System.Drawing.Size(69, 22);
            this.chkBoxRelease.TabIndex = 0;
            this.chkBoxRelease.Text = "正式版";
            this.chkBoxRelease.UseVisualStyleBackColor = true;
            this.chkBoxRelease.Click += new System.EventHandler(this.chkBoxRelease_Click);
            // 
            // groupBoxAccount
            // 
            this.groupBoxAccount.Controls.Add(this.btnLogoutAll);
            this.groupBoxAccount.Controls.Add(this.btnLogout);
            this.groupBoxAccount.Controls.Add(this.btnSwitchAcc);
            this.groupBoxAccount.Location = new System.Drawing.Point(8, 106);
            this.groupBoxAccount.Name = "groupBoxAccount";
            this.groupBoxAccount.Size = new System.Drawing.Size(151, 125);
            this.groupBoxAccount.TabIndex = 7;
            this.groupBoxAccount.TabStop = false;
            this.groupBoxAccount.Text = "帳號選項";
            // 
            // btnLogoutAll
            // 
            this.btnLogoutAll.Location = new System.Drawing.Point(6, 90);
            this.btnLogoutAll.Name = "btnLogoutAll";
            this.btnLogoutAll.Size = new System.Drawing.Size(139, 28);
            this.btnLogoutAll.TabIndex = 9;
            this.btnLogoutAll.Text = "清除所有登入資料";
            this.btnLogoutAll.UseVisualStyleBackColor = true;
            this.btnLogoutAll.Click += new System.EventHandler(this.btnLogoutAll_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(6, 56);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(139, 28);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "登出此帳號";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnSwitchAcc
            // 
            this.btnSwitchAcc.Location = new System.Drawing.Point(6, 22);
            this.btnSwitchAcc.Name = "btnSwitchAcc";
            this.btnSwitchAcc.Size = new System.Drawing.Size(139, 28);
            this.btnSwitchAcc.TabIndex = 0;
            this.btnSwitchAcc.Text = "登入其他帳號";
            this.btnSwitchAcc.UseVisualStyleBackColor = true;
            this.btnSwitchAcc.Click += new System.EventHandler(this.btnSwitchAcc_Click);
            // 
            // groupBoxMainProg
            // 
            this.groupBoxMainProg.Controls.Add(this.btnChkUpdate);
            this.groupBoxMainProg.Controls.Add(this.btnMainSetting);
            this.groupBoxMainProg.Location = new System.Drawing.Point(165, 106);
            this.groupBoxMainProg.Name = "groupBoxMainProg";
            this.groupBoxMainProg.Size = new System.Drawing.Size(95, 85);
            this.groupBoxMainProg.TabIndex = 6;
            this.groupBoxMainProg.TabStop = false;
            this.groupBoxMainProg.Text = "主程式選項";
            // 
            // btnChkUpdate
            // 
            this.btnChkUpdate.Location = new System.Drawing.Point(7, 19);
            this.btnChkUpdate.Name = "btnChkUpdate";
            this.btnChkUpdate.Size = new System.Drawing.Size(76, 27);
            this.btnChkUpdate.TabIndex = 5;
            this.btnChkUpdate.Text = "檢查更新";
            this.btnChkUpdate.UseVisualStyleBackColor = true;
            this.btnChkUpdate.Click += new System.EventHandler(this.btnChkUpdate_Click);
            // 
            // btnMainSetting
            // 
            this.btnMainSetting.Location = new System.Drawing.Point(7, 51);
            this.btnMainSetting.Name = "btnMainSetting";
            this.btnMainSetting.Size = new System.Drawing.Size(76, 26);
            this.btnMainSetting.TabIndex = 4;
            this.btnMainSetting.Text = "系統設定";
            this.btnMainSetting.UseVisualStyleBackColor = true;
            this.btnMainSetting.Click += new System.EventHandler(this.btnMainSetting_Click);
            // 
            // groupBoxInterval
            // 
            this.groupBoxInterval.Controls.Add(this.textBoxInterval);
            this.groupBoxInterval.Location = new System.Drawing.Point(8, 235);
            this.groupBoxInterval.Name = "groupBoxInterval";
            this.groupBoxInterval.Size = new System.Drawing.Size(81, 53);
            this.groupBoxInterval.TabIndex = 3;
            this.groupBoxInterval.TabStop = false;
            this.groupBoxInterval.Text = "執行間隔";
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(6, 21);
            this.textBoxInterval.MaxLength = 2;
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(65, 25);
            this.textBoxInterval.TabIndex = 0;
            this.textBoxInterval.Text = "1";
            this.textBoxInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.textBoxInterval, "程式執行下載與檢查檔案時的間隔，過短的間隔可能導致渲染出現延遲");
            this.textBoxInterval.Click += new System.EventHandler(this.textBoxInterval_Click);
            this.textBoxInterval.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxInterval_KeyUp);
            // 
            // panelSettingsTop
            // 
            this.panelSettingsTop.Controls.Add(this.groupBoxDataFolder);
            this.panelSettingsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSettingsTop.Location = new System.Drawing.Point(0, 0);
            this.panelSettingsTop.Name = "panelSettingsTop";
            this.panelSettingsTop.Size = new System.Drawing.Size(456, 100);
            this.panelSettingsTop.TabIndex = 1;
            // 
            // groupBoxDataFolder
            // 
            this.groupBoxDataFolder.Controls.Add(this.panelSettingsLeft);
            this.groupBoxDataFolder.Controls.Add(this.panelSettingsRight);
            this.groupBoxDataFolder.Location = new System.Drawing.Point(8, 10);
            this.groupBoxDataFolder.Name = "groupBoxDataFolder";
            this.groupBoxDataFolder.Size = new System.Drawing.Size(440, 88);
            this.groupBoxDataFolder.TabIndex = 0;
            this.groupBoxDataFolder.TabStop = false;
            this.groupBoxDataFolder.Text = "Minecraft 主程式資料";
            // 
            // panelSettingsLeft
            // 
            this.panelSettingsLeft.Controls.Add(this.panelSettingsInsideRight);
            this.panelSettingsLeft.Controls.Add(this.panelSettingsInsideLeft);
            this.panelSettingsLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettingsLeft.Location = new System.Drawing.Point(3, 21);
            this.panelSettingsLeft.Name = "panelSettingsLeft";
            this.panelSettingsLeft.Size = new System.Drawing.Size(308, 64);
            this.panelSettingsLeft.TabIndex = 0;
            // 
            // panelSettingsInsideRight
            // 
            this.panelSettingsInsideRight.Controls.Add(this.radBtnMain);
            this.panelSettingsInsideRight.Controls.Add(this.textBoxMain);
            this.panelSettingsInsideRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettingsInsideRight.Location = new System.Drawing.Point(154, 0);
            this.panelSettingsInsideRight.Name = "panelSettingsInsideRight";
            this.panelSettingsInsideRight.Size = new System.Drawing.Size(154, 64);
            this.panelSettingsInsideRight.TabIndex = 5;
            // 
            // radBtnMain
            // 
            this.radBtnMain.AutoSize = true;
            this.radBtnMain.Location = new System.Drawing.Point(6, 8);
            this.radBtnMain.Name = "radBtnMain";
            this.radBtnMain.Size = new System.Drawing.Size(124, 22);
            this.radBtnMain.TabIndex = 1;
            this.radBtnMain.Text = "主程式執行位置";
            this.radBtnMain.UseVisualStyleBackColor = true;
            this.radBtnMain.CheckedChanged += new System.EventHandler(this.radBtnMain_CheckedChanged);
            this.radBtnMain.Click += new System.EventHandler(this.radBtnMain_Click);
            // 
            // textBoxMain
            // 
            this.textBoxMain.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxMain.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.textBoxMain.Location = new System.Drawing.Point(22, 36);
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.ReadOnly = true;
            this.textBoxMain.Size = new System.Drawing.Size(118, 23);
            this.textBoxMain.TabIndex = 3;
            // 
            // panelSettingsInsideLeft
            // 
            this.panelSettingsInsideLeft.Controls.Add(this.radBtnAD);
            this.panelSettingsInsideLeft.Controls.Add(this.textBoxAD);
            this.panelSettingsInsideLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSettingsInsideLeft.Location = new System.Drawing.Point(0, 0);
            this.panelSettingsInsideLeft.Name = "panelSettingsInsideLeft";
            this.panelSettingsInsideLeft.Size = new System.Drawing.Size(154, 64);
            this.panelSettingsInsideLeft.TabIndex = 4;
            // 
            // radBtnAD
            // 
            this.radBtnAD.AutoSize = true;
            this.radBtnAD.Location = new System.Drawing.Point(6, 8);
            this.radBtnAD.Name = "radBtnAD";
            this.radBtnAD.Size = new System.Drawing.Size(91, 22);
            this.radBtnAD.TabIndex = 0;
            this.radBtnAD.TabStop = true;
            this.radBtnAD.Text = "APPDATA";
            this.radBtnAD.UseVisualStyleBackColor = true;
            this.radBtnAD.CheckedChanged += new System.EventHandler(this.radBtnAD_CheckedChanged);
            this.radBtnAD.Click += new System.EventHandler(this.radBtnAD_Click);
            // 
            // textBoxAD
            // 
            this.textBoxAD.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxAD.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.textBoxAD.Location = new System.Drawing.Point(30, 36);
            this.textBoxAD.Name = "textBoxAD";
            this.textBoxAD.ReadOnly = true;
            this.textBoxAD.Size = new System.Drawing.Size(118, 23);
            this.textBoxAD.TabIndex = 2;
            // 
            // panelSettingsRight
            // 
            this.panelSettingsRight.Controls.Add(this.btnVerifyFile);
            this.panelSettingsRight.Controls.Add(this.btnOpenFolder);
            this.panelSettingsRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSettingsRight.Location = new System.Drawing.Point(311, 21);
            this.panelSettingsRight.Name = "panelSettingsRight";
            this.panelSettingsRight.Size = new System.Drawing.Size(126, 64);
            this.panelSettingsRight.TabIndex = 1;
            // 
            // btnVerifyFile
            // 
            this.btnVerifyFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerifyFile.Location = new System.Drawing.Point(3, 0);
            this.btnVerifyFile.Name = "btnVerifyFile";
            this.btnVerifyFile.Size = new System.Drawing.Size(118, 30);
            this.btnVerifyFile.TabIndex = 4;
            this.btnVerifyFile.Text = "檢查資料完整性";
            this.toolTip.SetToolTip(this.btnVerifyFile, "驗證所有資料的雜湊值，並且不啟動遊戲");
            this.btnVerifyFile.UseVisualStyleBackColor = true;
            this.btnVerifyFile.Click += new System.EventHandler(this.btnVerifyFile_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.Location = new System.Drawing.Point(3, 31);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(118, 30);
            this.btnOpenFolder.TabIndex = 3;
            this.btnOpenFolder.Text = "開啟資料夾";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // debugPage
            // 
            this.debugPage.Controls.Add(this.textBox);
            this.debugPage.Location = new System.Drawing.Point(4, 26);
            this.debugPage.Name = "debugPage";
            this.debugPage.Padding = new System.Windows.Forms.Padding(3);
            this.debugPage.Size = new System.Drawing.Size(456, 291);
            this.debugPage.TabIndex = 1;
            this.debugPage.Text = "偵錯與輸出";
            this.debugPage.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(3, 3);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(450, 285);
            this.textBox.TabIndex = 0;
            // 
            // groupBoxVersionReload
            // 
            this.groupBoxVersionReload.Controls.Add(this.buttonVerReload);
            this.groupBoxVersionReload.Location = new System.Drawing.Point(355, 106);
            this.groupBoxVersionReload.Name = "groupBoxVersionReload";
            this.groupBoxVersionReload.Size = new System.Drawing.Size(98, 85);
            this.groupBoxVersionReload.TabIndex = 9;
            this.groupBoxVersionReload.TabStop = false;
            this.groupBoxVersionReload.Text = "版本資料";
            // 
            // buttonVerReload
            // 
            this.buttonVerReload.Location = new System.Drawing.Point(6, 21);
            this.buttonVerReload.Name = "buttonVerReload";
            this.buttonVerReload.Size = new System.Drawing.Size(86, 28);
            this.buttonVerReload.TabIndex = 0;
            this.buttonVerReload.Text = "重新載入";
            this.buttonVerReload.UseVisualStyleBackColor = true;
            this.buttonVerReload.Click += new System.EventHandler(this.buttonVerReload_Click);
            // 
            // minecraftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 321);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("新細明體", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(480, 360);
            this.Name = "minecraftForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XCoreNET Minecraft Launcher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.minecraftForm_FormClosed);
            this.Load += new System.EventHandler(this.minecraftForm_Load);
            this.Resize += new System.EventHandler(this.minecraftForm_Resize);
            this.tabControl1.ResumeLayout(false);
            this.mainPage.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.settingPage.ResumeLayout(false);
            this.groupBoxVersion.ResumeLayout(false);
            this.groupBoxVersion.PerformLayout();
            this.groupBoxAccount.ResumeLayout(false);
            this.groupBoxMainProg.ResumeLayout(false);
            this.groupBoxInterval.ResumeLayout(false);
            this.groupBoxInterval.PerformLayout();
            this.panelSettingsTop.ResumeLayout(false);
            this.groupBoxDataFolder.ResumeLayout(false);
            this.panelSettingsLeft.ResumeLayout(false);
            this.panelSettingsInsideRight.ResumeLayout(false);
            this.panelSettingsInsideRight.PerformLayout();
            this.panelSettingsInsideLeft.ResumeLayout(false);
            this.panelSettingsInsideLeft.PerformLayout();
            this.panelSettingsRight.ResumeLayout(false);
            this.debugPage.ResumeLayout(false);
            this.debugPage.PerformLayout();
            this.groupBoxVersionReload.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage mainPage;
        private System.Windows.Forms.TabPage debugPage;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelBody;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.TextBox textStatus;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.TabPage settingPage;
        private System.Windows.Forms.GroupBox groupBoxDataFolder;
        private System.Windows.Forms.RadioButton radBtnMain;
        private System.Windows.Forms.RadioButton radBtnAD;
        private System.Windows.Forms.TextBox textBoxMain;
        private System.Windows.Forms.TextBox textBoxAD;
        private System.Windows.Forms.Panel panelSettingsTop;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Panel panelSettingsLeft;
        private System.Windows.Forms.Panel panelSettingsRight;
        private System.Windows.Forms.Panel panelSettingsInsideRight;
        private System.Windows.Forms.Panel panelSettingsInsideLeft;
        private System.Windows.Forms.Button btnVerifyFile;
        private System.Windows.Forms.ComboBox versionList;
        private System.Windows.Forms.GroupBox groupBoxInterval;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox textVersionSelected;
        private System.Windows.Forms.Button btnMainSetting;
        private System.Windows.Forms.Button btnChkUpdate;
        private System.Windows.Forms.GroupBox groupBoxMainProg;
        private System.Windows.Forms.GroupBox groupBoxAccount;
        private System.Windows.Forms.Button btnSwitchAcc;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.GroupBox groupBoxVersion;
        private System.Windows.Forms.CheckBox chkBoxRelease;
        private System.Windows.Forms.CheckBox chkBoxSnapshot;
        private System.Windows.Forms.Button btnLogoutAll;
        private System.Windows.Forms.GroupBox groupBoxVersionReload;
        private System.Windows.Forms.Button buttonVerReload;
    }
}