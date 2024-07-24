namespace LiliumLauncher
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnVerifyFile = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnVerRecache = new System.Windows.Forms.Button();
            this.buttonVerReload = new System.Windows.Forms.Button();
            this.timerConcurrent = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new LiliumLauncher.CustomComponent.FlatTabControl.FlatTabControl();
            this.mainPage = new System.Windows.Forms.TabPage();
            this.panelBody = new System.Windows.Forms.Panel();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelVersion = new System.Windows.Forms.Panel();
            this.btnVersionSelector = new System.Windows.Forms.Button();
            this.textVersionSelected = new System.Windows.Forms.TextBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.avatar = new System.Windows.Forms.PictureBox();
            this.settingPage = new System.Windows.Forms.TabPage();
            this.panelMainSettings = new System.Windows.Forms.Panel();
            this.groupBoxDataFolder = new System.Windows.Forms.GroupBox();
            this.panelSettingsLeft = new System.Windows.Forms.Panel();
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.textBoxAD = new System.Windows.Forms.TextBox();
            this.groupBoxInstance = new System.Windows.Forms.GroupBox();
            this.btnInstanceEdit = new System.Windows.Forms.Button();
            this.textBoxInstance = new System.Windows.Forms.TextBox();
            this.btnInstanceDel = new System.Windows.Forms.Button();
            this.btnInstanceAdd = new System.Windows.Forms.Button();
            this.instanceList = new System.Windows.Forms.ComboBox();
            this.groupBoxInterval = new System.Windows.Forms.GroupBox();
            this.radConcurrent = new System.Windows.Forms.RadioButton();
            this.radSingle = new System.Windows.Forms.RadioButton();
            this.groupBoxMemory = new System.Windows.Forms.GroupBox();
            this.checkBoxMaxMem = new System.Windows.Forms.CheckBox();
            this.trackBarMiB = new System.Windows.Forms.TrackBar();
            this.textBoxMiB = new System.Windows.Forms.TextBox();
            this.groupBoxMainProg = new System.Windows.Forms.GroupBox();
            this.btnChkUpdate = new System.Windows.Forms.Button();
            this.btnMainSetting = new System.Windows.Forms.Button();
            this.groupBoxAccount = new System.Windows.Forms.GroupBox();
            this.btnMultiAcc = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSwitchAcc = new System.Windows.Forms.Button();
            this.groupBoxVersionReload = new System.Windows.Forms.GroupBox();
            this.debugPage = new System.Windows.Forms.TabPage();
            this.textBox = new System.Windows.Forms.TextBox();
            this.updatePage = new System.Windows.Forms.TabPage();
            this.textBoxUpdateNote = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.mainPage.SuspendLayout();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelVersion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.settingPage.SuspendLayout();
            this.panelMainSettings.SuspendLayout();
            this.groupBoxDataFolder.SuspendLayout();
            this.panelSettingsLeft.SuspendLayout();
            this.groupBoxInstance.SuspendLayout();
            this.groupBoxInterval.SuspendLayout();
            this.groupBoxMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMiB)).BeginInit();
            this.groupBoxMainProg.SuspendLayout();
            this.groupBoxAccount.SuspendLayout();
            this.groupBoxVersionReload.SuspendLayout();
            this.debugPage.SuspendLayout();
            this.updatePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVerifyFile
            // 
            this.btnVerifyFile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnVerifyFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnVerifyFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnVerifyFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerifyFile.Location = new System.Drawing.Point(103, 3);
            this.btnVerifyFile.Name = "btnVerifyFile";
            this.btnVerifyFile.Size = new System.Drawing.Size(133, 30);
            this.btnVerifyFile.TabIndex = 4;
            this.btnVerifyFile.Text = "檢查資料完整性";
            this.toolTip.SetToolTip(this.btnVerifyFile, "驗證所有資料的雜湊值，並且不啟動遊戲");
            this.btnVerifyFile.UseVisualStyleBackColor = true;
            this.btnVerifyFile.Click += new System.EventHandler(this.btnVerifyFile_Click);
            this.btnVerifyFile.Paint += new System.Windows.Forms.PaintEventHandler(this.btnVerifyFile_Paint);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOpenFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnOpenFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFolder.Location = new System.Drawing.Point(3, 3);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(96, 30);
            this.btnOpenFolder.TabIndex = 3;
            this.btnOpenFolder.Text = "開啟資料夾";
            this.toolTip.SetToolTip(this.btnOpenFolder, "開啟目前主程式所在的資料夾");
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            this.btnOpenFolder.Paint += new System.Windows.Forms.PaintEventHandler(this.btnOpenFolder_Paint);
            // 
            // btnVerRecache
            // 
            this.btnVerRecache.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnVerRecache.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnVerRecache.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnVerRecache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerRecache.Location = new System.Drawing.Point(7, 56);
            this.btnVerRecache.Name = "btnVerRecache";
            this.btnVerRecache.Size = new System.Drawing.Size(147, 28);
            this.btnVerRecache.TabIndex = 1;
            this.btnVerRecache.Text = "重新快取";
            this.toolTip.SetToolTip(this.btnVerRecache, "向 Mojang 重新快取版本列表及重新載入啟動實例列表");
            this.btnVerRecache.UseVisualStyleBackColor = true;
            this.btnVerRecache.Click += new System.EventHandler(this.btnVerRecache_Click);
            this.btnVerRecache.Paint += new System.Windows.Forms.PaintEventHandler(this.btnVerRecache_Paint);
            // 
            // buttonVerReload
            // 
            this.buttonVerReload.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonVerReload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonVerReload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonVerReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVerReload.Location = new System.Drawing.Point(7, 21);
            this.buttonVerReload.Name = "buttonVerReload";
            this.buttonVerReload.Size = new System.Drawing.Size(147, 28);
            this.buttonVerReload.TabIndex = 0;
            this.buttonVerReload.Text = "重新整理";
            this.toolTip.SetToolTip(this.buttonVerReload, "重新載入版本列表及啟動實例列表");
            this.buttonVerReload.UseVisualStyleBackColor = true;
            this.buttonVerReload.Click += new System.EventHandler(this.buttonVerReload_Click);
            this.buttonVerReload.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonVerReload_Paint);
            // 
            // timerConcurrent
            // 
            this.timerConcurrent.Tick += new System.EventHandler(this.timerConcurrent_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.mainPage);
            this.tabControl1.Controls.Add(this.settingPage);
            this.tabControl1.Controls.Add(this.debugPage);
            this.tabControl1.Controls.Add(this.updatePage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.myBackColor = System.Drawing.SystemColors.ControlText;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 321);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "";
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // mainPage
            // 
            this.mainPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
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
            this.panelBody.Size = new System.Drawing.Size(450, 190);
            this.panelBody.TabIndex = 8;
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.webView.Location = new System.Drawing.Point(0, 0);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(450, 190);
            this.webView.Source = new System.Uri("https://www.snkms.com/minecraftNews.html", System.UriKind.Absolute);
            this.webView.TabIndex = 0;
            this.webView.ZoomFactor = 1D;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelFooter.Controls.Add(this.textStatus);
            this.panelFooter.Controls.Add(this.btnLaunch);
            this.panelFooter.Controls.Add(this.progressBar);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelFooter.Location = new System.Drawing.Point(3, 234);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(450, 54);
            this.panelFooter.TabIndex = 7;
            // 
            // textStatus
            // 
            this.textStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textStatus.Font = new System.Drawing.Font("Verdana", 10F);
            this.textStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textStatus.Location = new System.Drawing.Point(5, 15);
            this.textStatus.Name = "textStatus";
            this.textStatus.ReadOnly = true;
            this.textStatus.Size = new System.Drawing.Size(340, 17);
            this.textStatus.TabIndex = 5;
            this.textStatus.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textStatus_MouseMove);
            // 
            // btnLaunch
            // 
            this.btnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaunch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLaunch.Enabled = false;
            this.btnLaunch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLaunch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnLaunch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaunch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLaunch.Location = new System.Drawing.Point(350, 8);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(96, 31);
            this.btnLaunch.TabIndex = 4;
            this.btnLaunch.Text = "啟動遊戲";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            this.btnLaunch.Paint += new System.Windows.Forms.PaintEventHandler(this.btnLaunch_Paint);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 46);
            this.progressBar.Margin = new System.Windows.Forms.Padding(15);
            this.progressBar.MarqueeAnimationSpeed = 5;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(450, 8);
            this.progressBar.TabIndex = 2;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelHeader.Controls.Add(this.panelVersion);
            this.panelHeader.Controls.Add(this.textUser);
            this.panelHeader.Controls.Add(this.avatar);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(3, 3);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(450, 41);
            this.panelHeader.TabIndex = 6;
            // 
            // panelVersion
            // 
            this.panelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVersion.Controls.Add(this.btnVersionSelector);
            this.panelVersion.Controls.Add(this.textVersionSelected);
            this.panelVersion.Location = new System.Drawing.Point(264, 0);
            this.panelVersion.Name = "panelVersion";
            this.panelVersion.Size = new System.Drawing.Size(185, 38);
            this.panelVersion.TabIndex = 1;
            // 
            // btnVersionSelector
            // 
            this.btnVersionSelector.Enabled = false;
            this.btnVersionSelector.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnVersionSelector.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnVersionSelector.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnVersionSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVersionSelector.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnVersionSelector.Location = new System.Drawing.Point(160, 7);
            this.btnVersionSelector.Name = "btnVersionSelector";
            this.btnVersionSelector.Size = new System.Drawing.Size(22, 25);
            this.btnVersionSelector.TabIndex = 2;
            this.btnVersionSelector.Text = "+";
            this.btnVersionSelector.UseVisualStyleBackColor = true;
            this.btnVersionSelector.Click += new System.EventHandler(this.btnVersionSelector_Click);
            this.btnVersionSelector.Paint += new System.Windows.Forms.PaintEventHandler(this.btnVersionSelector_Paint);
            // 
            // textVersionSelected
            // 
            this.textVersionSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textVersionSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textVersionSelected.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.textVersionSelected.Location = new System.Drawing.Point(3, 7);
            this.textVersionSelected.MinimumSize = new System.Drawing.Size(4, 25);
            this.textVersionSelected.Name = "textVersionSelected";
            this.textVersionSelected.ReadOnly = true;
            this.textVersionSelected.Size = new System.Drawing.Size(156, 25);
            this.textVersionSelected.TabIndex = 1;
            this.textVersionSelected.Click += new System.EventHandler(this.textVersionSelected_Click);
            // 
            // textUser
            // 
            this.textUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textUser.Font = new System.Drawing.Font("Verdana", 12F);
            this.textUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
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
            this.settingPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.settingPage.Controls.Add(this.panelMainSettings);
            this.settingPage.Location = new System.Drawing.Point(4, 26);
            this.settingPage.Name = "settingPage";
            this.settingPage.Size = new System.Drawing.Size(456, 291);
            this.settingPage.TabIndex = 2;
            this.settingPage.Text = "設定";
            // 
            // panelMainSettings
            // 
            this.panelMainSettings.Controls.Add(this.groupBoxDataFolder);
            this.panelMainSettings.Controls.Add(this.groupBoxInstance);
            this.panelMainSettings.Controls.Add(this.groupBoxInterval);
            this.panelMainSettings.Controls.Add(this.groupBoxMemory);
            this.panelMainSettings.Controls.Add(this.groupBoxMainProg);
            this.panelMainSettings.Controls.Add(this.groupBoxAccount);
            this.panelMainSettings.Controls.Add(this.groupBoxVersionReload);
            this.panelMainSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainSettings.Location = new System.Drawing.Point(0, 0);
            this.panelMainSettings.Name = "panelMainSettings";
            this.panelMainSettings.Size = new System.Drawing.Size(456, 291);
            this.panelMainSettings.TabIndex = 12;
            // 
            // groupBoxDataFolder
            // 
            this.groupBoxDataFolder.Controls.Add(this.panelSettingsLeft);
            this.groupBoxDataFolder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxDataFolder.Location = new System.Drawing.Point(3, 6);
            this.groupBoxDataFolder.Name = "groupBoxDataFolder";
            this.groupBoxDataFolder.Size = new System.Drawing.Size(274, 88);
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
            this.panelSettingsLeft.Size = new System.Drawing.Size(268, 64);
            this.panelSettingsLeft.TabIndex = 0;
            // 
            // btnChangeFolder
            // 
            this.btnChangeFolder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnChangeFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnChangeFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnChangeFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeFolder.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnChangeFolder.Location = new System.Drawing.Point(239, 38);
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.btnChangeFolder.Size = new System.Drawing.Size(25, 23);
            this.btnChangeFolder.TabIndex = 3;
            this.btnChangeFolder.Text = "…";
            this.btnChangeFolder.UseVisualStyleBackColor = true;
            this.btnChangeFolder.Click += new System.EventHandler(this.btnChangeFolder_Click);
            this.btnChangeFolder.Paint += new System.Windows.Forms.PaintEventHandler(this.btnChangeFolder_Paint);
            // 
            // textBoxAD
            // 
            this.textBoxAD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxAD.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.textBoxAD.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxAD.Location = new System.Drawing.Point(3, 38);
            this.textBoxAD.MinimumSize = new System.Drawing.Size(4, 25);
            this.textBoxAD.Name = "textBoxAD";
            this.textBoxAD.ReadOnly = true;
            this.textBoxAD.Size = new System.Drawing.Size(233, 23);
            this.textBoxAD.TabIndex = 2;
            // 
            // groupBoxInstance
            // 
            this.groupBoxInstance.Controls.Add(this.btnInstanceEdit);
            this.groupBoxInstance.Controls.Add(this.textBoxInstance);
            this.groupBoxInstance.Controls.Add(this.btnInstanceDel);
            this.groupBoxInstance.Controls.Add(this.btnInstanceAdd);
            this.groupBoxInstance.Controls.Add(this.instanceList);
            this.groupBoxInstance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxInstance.Location = new System.Drawing.Point(283, 6);
            this.groupBoxInstance.Name = "groupBoxInstance";
            this.groupBoxInstance.Size = new System.Drawing.Size(160, 88);
            this.groupBoxInstance.TabIndex = 1;
            this.groupBoxInstance.TabStop = false;
            this.groupBoxInstance.Text = "啟動實例管理";
            // 
            // btnInstanceEdit
            // 
            this.btnInstanceEdit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInstanceEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnInstanceEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnInstanceEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstanceEdit.Location = new System.Drawing.Point(58, 25);
            this.btnInstanceEdit.Name = "btnInstanceEdit";
            this.btnInstanceEdit.Size = new System.Drawing.Size(46, 27);
            this.btnInstanceEdit.TabIndex = 5;
            this.btnInstanceEdit.Text = "編輯";
            this.btnInstanceEdit.UseVisualStyleBackColor = true;
            this.btnInstanceEdit.Click += new System.EventHandler(this.btnInstanceEdit_Click);
            this.btnInstanceEdit.Paint += new System.Windows.Forms.PaintEventHandler(this.btnInstanceEdit_Paint);
            // 
            // textBoxInstance
            // 
            this.textBoxInstance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxInstance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxInstance.Location = new System.Drawing.Point(6, 57);
            this.textBoxInstance.MinimumSize = new System.Drawing.Size(4, 25);
            this.textBoxInstance.Name = "textBoxInstance";
            this.textBoxInstance.ReadOnly = true;
            this.textBoxInstance.Size = new System.Drawing.Size(129, 25);
            this.textBoxInstance.TabIndex = 4;
            this.textBoxInstance.Click += new System.EventHandler(this.textBoxInstance_Click);
            // 
            // btnInstanceDel
            // 
            this.btnInstanceDel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInstanceDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnInstanceDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnInstanceDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstanceDel.Location = new System.Drawing.Point(109, 26);
            this.btnInstanceDel.Name = "btnInstanceDel";
            this.btnInstanceDel.Size = new System.Drawing.Size(46, 27);
            this.btnInstanceDel.TabIndex = 2;
            this.btnInstanceDel.Text = "刪除";
            this.btnInstanceDel.UseVisualStyleBackColor = true;
            this.btnInstanceDel.Click += new System.EventHandler(this.btnInstanceDel_Click);
            this.btnInstanceDel.Paint += new System.Windows.Forms.PaintEventHandler(this.btnInstanceDel_Paint);
            // 
            // btnInstanceAdd
            // 
            this.btnInstanceAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInstanceAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnInstanceAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnInstanceAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstanceAdd.Location = new System.Drawing.Point(6, 25);
            this.btnInstanceAdd.Name = "btnInstanceAdd";
            this.btnInstanceAdd.Size = new System.Drawing.Size(46, 27);
            this.btnInstanceAdd.TabIndex = 1;
            this.btnInstanceAdd.Text = "新增";
            this.btnInstanceAdd.UseVisualStyleBackColor = true;
            this.btnInstanceAdd.Click += new System.EventHandler(this.btnInstanceAdd_Click);
            this.btnInstanceAdd.Paint += new System.Windows.Forms.PaintEventHandler(this.btnInstanceAdd_Paint);
            // 
            // instanceList
            // 
            this.instanceList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.instanceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.instanceList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instanceList.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.instanceList.FormattingEnabled = true;
            this.instanceList.Items.AddRange(new object[] {
            "無"});
            this.instanceList.Location = new System.Drawing.Point(136, 57);
            this.instanceList.Name = "instanceList";
            this.instanceList.Size = new System.Drawing.Size(19, 24);
            this.instanceList.TabIndex = 0;
            this.instanceList.SelectedIndexChanged += new System.EventHandler(this.instanceList_SelectedIndexChanged);
            // 
            // groupBoxInterval
            // 
            this.groupBoxInterval.Controls.Add(this.radConcurrent);
            this.groupBoxInterval.Controls.Add(this.radSingle);
            this.groupBoxInterval.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxInterval.Location = new System.Drawing.Point(3, 229);
            this.groupBoxInterval.Name = "groupBoxInterval";
            this.groupBoxInterval.Size = new System.Drawing.Size(151, 53);
            this.groupBoxInterval.TabIndex = 3;
            this.groupBoxInterval.TabStop = false;
            this.groupBoxInterval.Text = "下載模式";
            // 
            // radConcurrent
            // 
            this.radConcurrent.AutoSize = true;
            this.radConcurrent.Checked = true;
            this.radConcurrent.Location = new System.Drawing.Point(69, 24);
            this.radConcurrent.Name = "radConcurrent";
            this.radConcurrent.Size = new System.Drawing.Size(54, 22);
            this.radConcurrent.TabIndex = 1;
            this.radConcurrent.TabStop = true;
            this.radConcurrent.Text = "並行";
            this.radConcurrent.UseVisualStyleBackColor = false;
            this.radConcurrent.Click += new System.EventHandler(this.radConcurrent_Click);
            this.radConcurrent.Paint += new System.Windows.Forms.PaintEventHandler(this.radConcurrent_Paint);
            // 
            // radSingle
            // 
            this.radSingle.AutoSize = true;
            this.radSingle.Location = new System.Drawing.Point(6, 24);
            this.radSingle.Name = "radSingle";
            this.radSingle.Size = new System.Drawing.Size(54, 22);
            this.radSingle.TabIndex = 0;
            this.radSingle.Text = "逐次";
            this.radSingle.UseVisualStyleBackColor = false;
            this.radSingle.Click += new System.EventHandler(this.radSingle_Click);
            this.radSingle.Paint += new System.Windows.Forms.PaintEventHandler(this.radSingle_Paint);
            // 
            // groupBoxMemory
            // 
            this.groupBoxMemory.Controls.Add(this.checkBoxMaxMem);
            this.groupBoxMemory.Controls.Add(this.trackBarMiB);
            this.groupBoxMemory.Controls.Add(this.textBoxMiB);
            this.groupBoxMemory.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxMemory.Location = new System.Drawing.Point(160, 199);
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
            this.checkBoxMaxMem.Paint += new System.Windows.Forms.PaintEventHandler(this.checkBoxMaxMem_Paint);
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
            this.textBoxMiB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxMiB.Enabled = false;
            this.textBoxMiB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxMiB.Location = new System.Drawing.Point(217, 47);
            this.textBoxMiB.MaxLength = 6;
            this.textBoxMiB.Name = "textBoxMiB";
            this.textBoxMiB.Size = new System.Drawing.Size(57, 25);
            this.textBoxMiB.TabIndex = 11;
            this.textBoxMiB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxMiB_KeyUp);
            this.textBoxMiB.Leave += new System.EventHandler(this.textBoxMiB_Leave);
            // 
            // groupBoxMainProg
            // 
            this.groupBoxMainProg.Controls.Add(this.btnChkUpdate);
            this.groupBoxMainProg.Controls.Add(this.btnMainSetting);
            this.groupBoxMainProg.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxMainProg.Location = new System.Drawing.Point(160, 100);
            this.groupBoxMainProg.Name = "groupBoxMainProg";
            this.groupBoxMainProg.Size = new System.Drawing.Size(117, 93);
            this.groupBoxMainProg.TabIndex = 6;
            this.groupBoxMainProg.TabStop = false;
            this.groupBoxMainProg.Text = "啟動器選項";
            // 
            // btnChkUpdate
            // 
            this.btnChkUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnChkUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnChkUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnChkUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChkUpdate.Location = new System.Drawing.Point(7, 22);
            this.btnChkUpdate.Name = "btnChkUpdate";
            this.btnChkUpdate.Size = new System.Drawing.Size(103, 28);
            this.btnChkUpdate.TabIndex = 5;
            this.btnChkUpdate.Text = "檢查更新";
            this.btnChkUpdate.UseVisualStyleBackColor = true;
            this.btnChkUpdate.Click += new System.EventHandler(this.btnChkUpdate_Click);
            this.btnChkUpdate.Paint += new System.Windows.Forms.PaintEventHandler(this.btnChkUpdate_Paint);
            // 
            // btnMainSetting
            // 
            this.btnMainSetting.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMainSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnMainSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnMainSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainSetting.Location = new System.Drawing.Point(7, 57);
            this.btnMainSetting.Name = "btnMainSetting";
            this.btnMainSetting.Size = new System.Drawing.Size(103, 28);
            this.btnMainSetting.TabIndex = 4;
            this.btnMainSetting.Text = "系統設定";
            this.btnMainSetting.UseVisualStyleBackColor = true;
            this.btnMainSetting.Click += new System.EventHandler(this.btnMainSetting_Click);
            this.btnMainSetting.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMainSetting_Paint);
            // 
            // groupBoxAccount
            // 
            this.groupBoxAccount.Controls.Add(this.btnMultiAcc);
            this.groupBoxAccount.Controls.Add(this.btnLogout);
            this.groupBoxAccount.Controls.Add(this.btnSwitchAcc);
            this.groupBoxAccount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxAccount.Location = new System.Drawing.Point(3, 100);
            this.groupBoxAccount.Name = "groupBoxAccount";
            this.groupBoxAccount.Size = new System.Drawing.Size(151, 125);
            this.groupBoxAccount.TabIndex = 7;
            this.groupBoxAccount.TabStop = false;
            this.groupBoxAccount.Text = "帳號選項";
            // 
            // btnMultiAcc
            // 
            this.btnMultiAcc.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMultiAcc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnMultiAcc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnMultiAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiAcc.Location = new System.Drawing.Point(6, 57);
            this.btnMultiAcc.Name = "btnMultiAcc";
            this.btnMultiAcc.Size = new System.Drawing.Size(139, 28);
            this.btnMultiAcc.TabIndex = 10;
            this.btnMultiAcc.Text = "多帳號管理";
            this.btnMultiAcc.UseVisualStyleBackColor = true;
            this.btnMultiAcc.Click += new System.EventHandler(this.btnMultiAcc_Click);
            this.btnMultiAcc.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMultiAcc_Paint);
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(6, 91);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(139, 28);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "登出此帳號";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.btnLogout.Paint += new System.Windows.Forms.PaintEventHandler(this.btnLogout_Paint);
            // 
            // btnSwitchAcc
            // 
            this.btnSwitchAcc.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSwitchAcc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSwitchAcc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSwitchAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchAcc.Location = new System.Drawing.Point(6, 22);
            this.btnSwitchAcc.Name = "btnSwitchAcc";
            this.btnSwitchAcc.Size = new System.Drawing.Size(139, 28);
            this.btnSwitchAcc.TabIndex = 0;
            this.btnSwitchAcc.Text = "新增帳號";
            this.btnSwitchAcc.UseVisualStyleBackColor = true;
            this.btnSwitchAcc.Click += new System.EventHandler(this.btnSwitchAcc_Click);
            this.btnSwitchAcc.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSwitchAcc_Paint);
            // 
            // groupBoxVersionReload
            // 
            this.groupBoxVersionReload.Controls.Add(this.btnVerRecache);
            this.groupBoxVersionReload.Controls.Add(this.buttonVerReload);
            this.groupBoxVersionReload.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxVersionReload.Location = new System.Drawing.Point(283, 100);
            this.groupBoxVersionReload.Name = "groupBoxVersionReload";
            this.groupBoxVersionReload.Size = new System.Drawing.Size(160, 93);
            this.groupBoxVersionReload.TabIndex = 9;
            this.groupBoxVersionReload.TabStop = false;
            this.groupBoxVersionReload.Text = "版本與實例列表";
            // 
            // debugPage
            // 
            this.debugPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.debugPage.Controls.Add(this.textBox);
            this.debugPage.Location = new System.Drawing.Point(4, 26);
            this.debugPage.Name = "debugPage";
            this.debugPage.Padding = new System.Windows.Forms.Padding(3);
            this.debugPage.Size = new System.Drawing.Size(456, 291);
            this.debugPage.TabIndex = 1;
            this.debugPage.Text = "偵錯與輸出";
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox.Location = new System.Drawing.Point(3, 3);
            this.textBox.MaxLength = 2147483647;
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(450, 285);
            this.textBox.TabIndex = 0;
            // 
            // updatePage
            // 
            this.updatePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.updatePage.Controls.Add(this.textBoxUpdateNote);
            this.updatePage.Location = new System.Drawing.Point(4, 26);
            this.updatePage.Name = "updatePage";
            this.updatePage.Padding = new System.Windows.Forms.Padding(3);
            this.updatePage.Size = new System.Drawing.Size(456, 291);
            this.updatePage.TabIndex = 3;
            this.updatePage.Text = "更新日誌";
            // 
            // textBoxUpdateNote
            // 
            this.textBoxUpdateNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxUpdateNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxUpdateNote.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxUpdateNote.Location = new System.Drawing.Point(3, 3);
            this.textBoxUpdateNote.Name = "textBoxUpdateNote";
            this.textBoxUpdateNote.ReadOnly = true;
            this.textBoxUpdateNote.Size = new System.Drawing.Size(450, 285);
            this.textBoxUpdateNote.TabIndex = 0;
            this.textBoxUpdateNote.Text = "";
            // 
            // minecraftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(464, 321);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("新細明體", 9F);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 360);
            this.MinimumSize = new System.Drawing.Size(480, 360);
            this.Name = "minecraftForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lilium Minecraft Launcher";
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
            this.panelVersion.ResumeLayout(false);
            this.panelVersion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.settingPage.ResumeLayout(false);
            this.panelMainSettings.ResumeLayout(false);
            this.groupBoxDataFolder.ResumeLayout(false);
            this.panelSettingsLeft.ResumeLayout(false);
            this.panelSettingsLeft.PerformLayout();
            this.groupBoxInstance.ResumeLayout(false);
            this.groupBoxInstance.PerformLayout();
            this.groupBoxInterval.ResumeLayout(false);
            this.groupBoxInterval.PerformLayout();
            this.groupBoxMemory.ResumeLayout(false);
            this.groupBoxMemory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMiB)).EndInit();
            this.groupBoxMainProg.ResumeLayout(false);
            this.groupBoxAccount.ResumeLayout(false);
            this.groupBoxVersionReload.ResumeLayout(false);
            this.debugPage.ResumeLayout(false);
            this.debugPage.PerformLayout();
            this.updatePage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage debugPage;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.TextBox textStatus;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.TabPage settingPage;
        private System.Windows.Forms.GroupBox groupBoxDataFolder;
        private System.Windows.Forms.Panel panelSettingsLeft;
        private System.Windows.Forms.GroupBox groupBoxInterval;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox textVersionSelected;
        private System.Windows.Forms.Button btnMainSetting;
        private System.Windows.Forms.Button btnChkUpdate;
        private System.Windows.Forms.GroupBox groupBoxMainProg;
        private System.Windows.Forms.GroupBox groupBoxAccount;
        private System.Windows.Forms.Button btnSwitchAcc;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.GroupBox groupBoxVersionReload;
        private System.Windows.Forms.Button buttonVerReload;
        private System.Windows.Forms.TrackBar trackBarMiB;
        private System.Windows.Forms.GroupBox groupBoxMemory;
        private System.Windows.Forms.TextBox textBoxMiB;
        private System.Windows.Forms.CheckBox checkBoxMaxMem;
        private System.Windows.Forms.Button btnVerRecache;
        private System.Windows.Forms.Timer timerConcurrent;
        private System.Windows.Forms.Button btnVerifyFile;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnChangeFolder;
        private System.Windows.Forms.TextBox textBoxAD;
        private System.Windows.Forms.GroupBox groupBoxInstance;
        private System.Windows.Forms.Button btnInstanceDel;
        private System.Windows.Forms.Button btnInstanceAdd;
        private System.Windows.Forms.ComboBox instanceList;
        private System.Windows.Forms.TextBox textBoxInstance;
        private System.Windows.Forms.Panel panelVersion;
        private System.Windows.Forms.TabPage updatePage;
        private System.Windows.Forms.RichTextBox textBoxUpdateNote;
        private System.Windows.Forms.Button btnMultiAcc;
        private System.Windows.Forms.Panel panelMainSettings;
        private System.Windows.Forms.Button btnInstanceEdit;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.Button btnVersionSelector;
        private System.Windows.Forms.RadioButton radConcurrent;
        private System.Windows.Forms.RadioButton radSingle;
        private System.Windows.Forms.TabPage mainPage;
        private CustomComponent.FlatTabControl.FlatTabControl tabControl1;
    }
}