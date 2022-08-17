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
            this.groupBoxMemory = new System.Windows.Forms.GroupBox();
            this.checkBoxMaxMem = new System.Windows.Forms.CheckBox();
            this.trackBarMiB = new System.Windows.Forms.TrackBar();
            this.textBoxMiB = new System.Windows.Forms.TextBox();
            this.groupBoxVersionReload = new System.Windows.Forms.GroupBox();
            this.btnVerRecache = new System.Windows.Forms.Button();
            this.buttonVerReload = new System.Windows.Forms.Button();
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
            this.chkConcurrent = new System.Windows.Forms.CheckBox();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.panelSettingsTop = new System.Windows.Forms.Panel();
            this.groupBoxInstance = new System.Windows.Forms.GroupBox();
            this.textBoxInstance = new System.Windows.Forms.TextBox();
            this.btnInstanceIntro = new System.Windows.Forms.Button();
            this.btnInstanceDel = new System.Windows.Forms.Button();
            this.btnInstanceAdd = new System.Windows.Forms.Button();
            this.instanceList = new System.Windows.Forms.ComboBox();
            this.groupBoxDataFolder = new System.Windows.Forms.GroupBox();
            this.panelSettingsLeft = new System.Windows.Forms.Panel();
            this.btnVerifyFile = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.textBoxAD = new System.Windows.Forms.TextBox();
            this.debugPage = new System.Windows.Forms.TabPage();
            this.textBox = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timerConcurrent = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.mainPage.SuspendLayout();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.settingPage.SuspendLayout();
            this.groupBoxMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMiB)).BeginInit();
            this.groupBoxVersionReload.SuspendLayout();
            this.groupBoxVersion.SuspendLayout();
            this.groupBoxAccount.SuspendLayout();
            this.groupBoxMainProg.SuspendLayout();
            this.groupBoxInterval.SuspendLayout();
            this.panelSettingsTop.SuspendLayout();
            this.groupBoxInstance.SuspendLayout();
            this.groupBoxDataFolder.SuspendLayout();
            this.panelSettingsLeft.SuspendLayout();
            this.debugPage.SuspendLayout();
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
            this.settingPage.Controls.Add(this.groupBoxMemory);
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
            // groupBoxMemory
            // 
            this.groupBoxMemory.Controls.Add(this.checkBoxMaxMem);
            this.groupBoxMemory.Controls.Add(this.trackBarMiB);
            this.groupBoxMemory.Controls.Add(this.textBoxMiB);
            this.groupBoxMemory.Location = new System.Drawing.Point(165, 205);
            this.groupBoxMemory.Name = "groupBoxMemory";
            this.groupBoxMemory.Size = new System.Drawing.Size(283, 83);
            this.groupBoxMemory.TabIndex = 11;
            this.groupBoxMemory.TabStop = false;
            this.groupBoxMemory.Text = "遊戲最大記憶體(MB)";
            // 
            // checkBoxMaxMem
            // 
            this.checkBoxMaxMem.AutoSize = true;
            this.checkBoxMaxMem.Location = new System.Drawing.Point(217, 22);
            this.checkBoxMaxMem.Name = "checkBoxMaxMem";
            this.checkBoxMaxMem.Size = new System.Drawing.Size(55, 22);
            this.checkBoxMaxMem.TabIndex = 12;
            this.checkBoxMaxMem.Text = "開啟";
            this.checkBoxMaxMem.UseVisualStyleBackColor = true;
            this.checkBoxMaxMem.CheckedChanged += new System.EventHandler(this.checkBoxMaxMem_CheckedChanged);
            // 
            // trackBarMiB
            // 
            this.trackBarMiB.Enabled = false;
            this.trackBarMiB.Location = new System.Drawing.Point(8, 30);
            this.trackBarMiB.Name = "trackBarMiB";
            this.trackBarMiB.Size = new System.Drawing.Size(203, 45);
            this.trackBarMiB.TabIndex = 10;
            this.trackBarMiB.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarMiB.Scroll += new System.EventHandler(this.trackBarMiB_Scroll);
            this.trackBarMiB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarMiB_MouseUp);
            // 
            // textBoxMiB
            // 
            this.textBoxMiB.Enabled = false;
            this.textBoxMiB.Location = new System.Drawing.Point(217, 47);
            this.textBoxMiB.MaxLength = 6;
            this.textBoxMiB.Name = "textBoxMiB";
            this.textBoxMiB.Size = new System.Drawing.Size(57, 25);
            this.textBoxMiB.TabIndex = 11;
            this.textBoxMiB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxMiB_KeyUp);
            this.textBoxMiB.Leave += new System.EventHandler(this.textBoxMiB_Leave);
            // 
            // groupBoxVersionReload
            // 
            this.groupBoxVersionReload.Controls.Add(this.btnVerRecache);
            this.groupBoxVersionReload.Controls.Add(this.buttonVerReload);
            this.groupBoxVersionReload.Location = new System.Drawing.Point(266, 106);
            this.groupBoxVersionReload.Name = "groupBoxVersionReload";
            this.groupBoxVersionReload.Size = new System.Drawing.Size(93, 93);
            this.groupBoxVersionReload.TabIndex = 9;
            this.groupBoxVersionReload.TabStop = false;
            this.groupBoxVersionReload.Text = "版本資料";
            // 
            // btnVerRecache
            // 
            this.btnVerRecache.Location = new System.Drawing.Point(7, 56);
            this.btnVerRecache.Name = "btnVerRecache";
            this.btnVerRecache.Size = new System.Drawing.Size(80, 28);
            this.btnVerRecache.TabIndex = 1;
            this.btnVerRecache.Text = "重新快取";
            this.btnVerRecache.UseVisualStyleBackColor = true;
            this.btnVerRecache.Click += new System.EventHandler(this.btnVerRecache_Click);
            // 
            // buttonVerReload
            // 
            this.buttonVerReload.Location = new System.Drawing.Point(7, 21);
            this.buttonVerReload.Name = "buttonVerReload";
            this.buttonVerReload.Size = new System.Drawing.Size(80, 28);
            this.buttonVerReload.TabIndex = 0;
            this.buttonVerReload.Text = "重新載入";
            this.buttonVerReload.UseVisualStyleBackColor = true;
            this.buttonVerReload.Click += new System.EventHandler(this.buttonVerReload_Click);
            // 
            // groupBoxVersion
            // 
            this.groupBoxVersion.Controls.Add(this.chkBoxSnapshot);
            this.groupBoxVersion.Controls.Add(this.chkBoxRelease);
            this.groupBoxVersion.Location = new System.Drawing.Point(365, 106);
            this.groupBoxVersion.Name = "groupBoxVersion";
            this.groupBoxVersion.Size = new System.Drawing.Size(83, 93);
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
            this.groupBoxMainProg.Size = new System.Drawing.Size(95, 93);
            this.groupBoxMainProg.TabIndex = 6;
            this.groupBoxMainProg.TabStop = false;
            this.groupBoxMainProg.Text = "啟動器選項";
            // 
            // btnChkUpdate
            // 
            this.btnChkUpdate.Location = new System.Drawing.Point(7, 22);
            this.btnChkUpdate.Name = "btnChkUpdate";
            this.btnChkUpdate.Size = new System.Drawing.Size(82, 28);
            this.btnChkUpdate.TabIndex = 5;
            this.btnChkUpdate.Text = "檢查更新";
            this.btnChkUpdate.UseVisualStyleBackColor = true;
            this.btnChkUpdate.Click += new System.EventHandler(this.btnChkUpdate_Click);
            // 
            // btnMainSetting
            // 
            this.btnMainSetting.Location = new System.Drawing.Point(7, 57);
            this.btnMainSetting.Name = "btnMainSetting";
            this.btnMainSetting.Size = new System.Drawing.Size(82, 28);
            this.btnMainSetting.TabIndex = 4;
            this.btnMainSetting.Text = "系統設定";
            this.btnMainSetting.UseVisualStyleBackColor = true;
            this.btnMainSetting.Click += new System.EventHandler(this.btnMainSetting_Click);
            // 
            // groupBoxInterval
            // 
            this.groupBoxInterval.Controls.Add(this.chkConcurrent);
            this.groupBoxInterval.Controls.Add(this.textBoxInterval);
            this.groupBoxInterval.Location = new System.Drawing.Point(8, 235);
            this.groupBoxInterval.Name = "groupBoxInterval";
            this.groupBoxInterval.Size = new System.Drawing.Size(151, 53);
            this.groupBoxInterval.TabIndex = 3;
            this.groupBoxInterval.TabStop = false;
            this.groupBoxInterval.Text = "執行間隔與下載模式";
            // 
            // chkConcurrent
            // 
            this.chkConcurrent.AutoSize = true;
            this.chkConcurrent.Checked = true;
            this.chkConcurrent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConcurrent.Location = new System.Drawing.Point(62, 23);
            this.chkConcurrent.Name = "chkConcurrent";
            this.chkConcurrent.Size = new System.Drawing.Size(83, 22);
            this.chkConcurrent.TabIndex = 1;
            this.chkConcurrent.Text = "並行下載";
            this.chkConcurrent.UseVisualStyleBackColor = true;
            this.chkConcurrent.Click += new System.EventHandler(this.chkConcurrent_Click);
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(6, 22);
            this.textBoxInterval.MaxLength = 2;
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(52, 25);
            this.textBoxInterval.TabIndex = 0;
            this.textBoxInterval.Text = "0";
            this.textBoxInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.textBoxInterval, "程式執行下載與檢查檔案時的間隔，過短的間隔可能導致渲染出現延遲");
            this.textBoxInterval.Click += new System.EventHandler(this.textBoxInterval_Click);
            this.textBoxInterval.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxInterval_KeyUp);
            // 
            // panelSettingsTop
            // 
            this.panelSettingsTop.Controls.Add(this.groupBoxInstance);
            this.panelSettingsTop.Controls.Add(this.groupBoxDataFolder);
            this.panelSettingsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSettingsTop.Location = new System.Drawing.Point(0, 0);
            this.panelSettingsTop.Name = "panelSettingsTop";
            this.panelSettingsTop.Size = new System.Drawing.Size(456, 100);
            this.panelSettingsTop.TabIndex = 1;
            // 
            // groupBoxInstance
            // 
            this.groupBoxInstance.Controls.Add(this.textBoxInstance);
            this.groupBoxInstance.Controls.Add(this.btnInstanceIntro);
            this.groupBoxInstance.Controls.Add(this.btnInstanceDel);
            this.groupBoxInstance.Controls.Add(this.btnInstanceAdd);
            this.groupBoxInstance.Controls.Add(this.instanceList);
            this.groupBoxInstance.Location = new System.Drawing.Point(288, 10);
            this.groupBoxInstance.Name = "groupBoxInstance";
            this.groupBoxInstance.Size = new System.Drawing.Size(160, 88);
            this.groupBoxInstance.TabIndex = 1;
            this.groupBoxInstance.TabStop = false;
            this.groupBoxInstance.Text = "啟動實例管理";
            // 
            // textBoxInstance
            // 
            this.textBoxInstance.Location = new System.Drawing.Point(6, 57);
            this.textBoxInstance.Name = "textBoxInstance";
            this.textBoxInstance.ReadOnly = true;
            this.textBoxInstance.Size = new System.Drawing.Size(129, 25);
            this.textBoxInstance.TabIndex = 4;
            this.textBoxInstance.Click += new System.EventHandler(this.textBoxInstance_Click);
            // 
            // btnInstanceIntro
            // 
            this.btnInstanceIntro.Location = new System.Drawing.Point(108, 25);
            this.btnInstanceIntro.Name = "btnInstanceIntro";
            this.btnInstanceIntro.Size = new System.Drawing.Size(46, 27);
            this.btnInstanceIntro.TabIndex = 3;
            this.btnInstanceIntro.Text = "說明";
            this.btnInstanceIntro.UseVisualStyleBackColor = true;
            this.btnInstanceIntro.Click += new System.EventHandler(this.btnInstanceIntro_Click);
            // 
            // btnInstanceDel
            // 
            this.btnInstanceDel.Location = new System.Drawing.Point(57, 25);
            this.btnInstanceDel.Name = "btnInstanceDel";
            this.btnInstanceDel.Size = new System.Drawing.Size(46, 27);
            this.btnInstanceDel.TabIndex = 2;
            this.btnInstanceDel.Text = "刪除";
            this.btnInstanceDel.UseVisualStyleBackColor = true;
            this.btnInstanceDel.Click += new System.EventHandler(this.btnInstanceDel_Click);
            // 
            // btnInstanceAdd
            // 
            this.btnInstanceAdd.Location = new System.Drawing.Point(6, 25);
            this.btnInstanceAdd.Name = "btnInstanceAdd";
            this.btnInstanceAdd.Size = new System.Drawing.Size(46, 27);
            this.btnInstanceAdd.TabIndex = 1;
            this.btnInstanceAdd.Text = "新增";
            this.btnInstanceAdd.UseVisualStyleBackColor = true;
            this.btnInstanceAdd.Click += new System.EventHandler(this.btnInstanceAdd_Click);
            // 
            // instanceList
            // 
            this.instanceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.instanceList.FormattingEnabled = true;
            this.instanceList.Items.AddRange(new object[] {
            "無"});
            this.instanceList.Location = new System.Drawing.Point(136, 57);
            this.instanceList.Name = "instanceList";
            this.instanceList.Size = new System.Drawing.Size(19, 25);
            this.instanceList.TabIndex = 0;
            this.instanceList.SelectedIndexChanged += new System.EventHandler(this.instanceList_SelectedIndexChanged);
            // 
            // groupBoxDataFolder
            // 
            this.groupBoxDataFolder.Controls.Add(this.panelSettingsLeft);
            this.groupBoxDataFolder.Location = new System.Drawing.Point(8, 10);
            this.groupBoxDataFolder.Name = "groupBoxDataFolder";
            this.groupBoxDataFolder.Size = new System.Drawing.Size(277, 88);
            this.groupBoxDataFolder.TabIndex = 0;
            this.groupBoxDataFolder.TabStop = false;
            this.groupBoxDataFolder.Text = "Minecraft 主程式資料";
            // 
            // panelSettingsLeft
            // 
            this.panelSettingsLeft.Controls.Add(this.btnVerifyFile);
            this.panelSettingsLeft.Controls.Add(this.btnOpenFolder);
            this.panelSettingsLeft.Controls.Add(this.btnChangeFolder);
            this.panelSettingsLeft.Controls.Add(this.textBoxAD);
            this.panelSettingsLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettingsLeft.Location = new System.Drawing.Point(3, 21);
            this.panelSettingsLeft.Name = "panelSettingsLeft";
            this.panelSettingsLeft.Size = new System.Drawing.Size(271, 64);
            this.panelSettingsLeft.TabIndex = 0;
            // 
            // btnVerifyFile
            // 
            this.btnVerifyFile.Location = new System.Drawing.Point(105, 3);
            this.btnVerifyFile.Name = "btnVerifyFile";
            this.btnVerifyFile.Size = new System.Drawing.Size(131, 30);
            this.btnVerifyFile.TabIndex = 4;
            this.btnVerifyFile.Text = "檢查資料完整性";
            this.toolTip.SetToolTip(this.btnVerifyFile, "驗證所有資料的雜湊值，並且不啟動遊戲");
            this.btnVerifyFile.UseVisualStyleBackColor = true;
            this.btnVerifyFile.Click += new System.EventHandler(this.btnVerifyFile_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(3, 3);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(96, 30);
            this.btnOpenFolder.TabIndex = 3;
            this.btnOpenFolder.Text = "開啟資料夾";
            this.toolTip.SetToolTip(this.btnOpenFolder, "開啟目前主程式所在的資料夾");
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnChangeFolder
            // 
            this.btnChangeFolder.Location = new System.Drawing.Point(241, 38);
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.btnChangeFolder.Size = new System.Drawing.Size(25, 23);
            this.btnChangeFolder.TabIndex = 3;
            this.btnChangeFolder.Text = "...";
            this.toolTip.SetToolTip(this.btnChangeFolder, "選擇新的資料夾作為主程式資料存放位置");
            this.btnChangeFolder.UseVisualStyleBackColor = true;
            this.btnChangeFolder.Click += new System.EventHandler(this.btnChangeFolder_Click);
            // 
            // textBoxAD
            // 
            this.textBoxAD.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxAD.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.textBoxAD.Location = new System.Drawing.Point(3, 38);
            this.textBoxAD.Name = "textBoxAD";
            this.textBoxAD.ReadOnly = true;
            this.textBoxAD.Size = new System.Drawing.Size(233, 23);
            this.textBoxAD.TabIndex = 2;
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
            // timerConcurrent
            // 
            this.timerConcurrent.Tick += new System.EventHandler(this.timerConcurrent_Tick);
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
            this.groupBoxMemory.ResumeLayout(false);
            this.groupBoxMemory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMiB)).EndInit();
            this.groupBoxVersionReload.ResumeLayout(false);
            this.groupBoxVersion.ResumeLayout(false);
            this.groupBoxVersion.PerformLayout();
            this.groupBoxAccount.ResumeLayout(false);
            this.groupBoxMainProg.ResumeLayout(false);
            this.groupBoxInterval.ResumeLayout(false);
            this.groupBoxInterval.PerformLayout();
            this.panelSettingsTop.ResumeLayout(false);
            this.groupBoxInstance.ResumeLayout(false);
            this.groupBoxInstance.PerformLayout();
            this.groupBoxDataFolder.ResumeLayout(false);
            this.panelSettingsLeft.ResumeLayout(false);
            this.panelSettingsLeft.PerformLayout();
            this.debugPage.ResumeLayout(false);
            this.debugPage.PerformLayout();
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
        private System.Windows.Forms.Panel panelSettingsTop;
        private System.Windows.Forms.Panel panelSettingsLeft;
        private System.Windows.Forms.ComboBox versionList;
        private System.Windows.Forms.GroupBox groupBoxInterval;
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
        private System.Windows.Forms.TrackBar trackBarMiB;
        private System.Windows.Forms.GroupBox groupBoxMemory;
        private System.Windows.Forms.TextBox textBoxMiB;
        private System.Windows.Forms.CheckBox checkBoxMaxMem;
        private System.Windows.Forms.Button btnVerRecache;
        private System.Windows.Forms.Timer timerConcurrent;
        private System.Windows.Forms.CheckBox chkConcurrent;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.Button btnVerifyFile;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnChangeFolder;
        private System.Windows.Forms.TextBox textBoxAD;
        private System.Windows.Forms.GroupBox groupBoxInstance;
        private System.Windows.Forms.Button btnInstanceIntro;
        private System.Windows.Forms.Button btnInstanceDel;
        private System.Windows.Forms.Button btnInstanceAdd;
        private System.Windows.Forms.ComboBox instanceList;
        private System.Windows.Forms.TextBox textBoxInstance;
    }
}