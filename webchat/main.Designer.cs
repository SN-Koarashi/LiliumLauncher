namespace webchat
{
    partial class main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sysMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.nonDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.socialMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pixivMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.twitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messengerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instagramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dataMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.forumMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.accMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loginTrd = new System.Windows.Forms.ToolStripMenuItem();
            this.googleLoginMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.aboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sysMenu,
            this.mainMenu,
            this.socialMenu,
            this.serviceMenu,
            this.loginTrd});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sysMenu
            // 
            this.sysMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nonDisplay,
            this.checkUpdate,
            this.aboutMenu});
            this.sysMenu.Name = "sysMenu";
            this.sysMenu.Size = new System.Drawing.Size(43, 20);
            this.sysMenu.Text = "系統";
            // 
            // nonDisplay
            // 
            this.nonDisplay.Name = "nonDisplay";
            this.nonDisplay.Size = new System.Drawing.Size(180, 22);
            this.nonDisplay.Text = "沒有畫面？";
            this.nonDisplay.Click += new System.EventHandler(this.nonDisplay_Click);
            // 
            // checkUpdate
            // 
            this.checkUpdate.Name = "checkUpdate";
            this.checkUpdate.Size = new System.Drawing.Size(180, 22);
            this.checkUpdate.Text = "檢查更新";
            this.checkUpdate.Click += new System.EventHandler(this.checkUpdate_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(43, 20);
            this.mainMenu.Text = "首頁";
            this.mainMenu.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // socialMenu
            // 
            this.socialMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pixivMenu,
            this.twitterToolStripMenuItem,
            this.messengerToolStripMenuItem,
            this.instagramToolStripMenuItem,
            this.discordToolStripMenuItem,
            this.googleToolStripMenuItem});
            this.socialMenu.Name = "socialMenu";
            this.socialMenu.Size = new System.Drawing.Size(43, 20);
            this.socialMenu.Text = "社交";
            // 
            // pixivMenu
            // 
            this.pixivMenu.Name = "pixivMenu";
            this.pixivMenu.Size = new System.Drawing.Size(136, 22);
            this.pixivMenu.Text = "Pixiv";
            this.pixivMenu.Click += new System.EventHandler(this.pixivMenu_Click);
            // 
            // twitterToolStripMenuItem
            // 
            this.twitterToolStripMenuItem.Name = "twitterToolStripMenuItem";
            this.twitterToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.twitterToolStripMenuItem.Text = "Twitter";
            this.twitterToolStripMenuItem.Click += new System.EventHandler(this.twitterToolStripMenuItem_Click);
            // 
            // messengerToolStripMenuItem
            // 
            this.messengerToolStripMenuItem.Name = "messengerToolStripMenuItem";
            this.messengerToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.messengerToolStripMenuItem.Text = "Messenger";
            this.messengerToolStripMenuItem.Click += new System.EventHandler(this.messengerToolStripMenuItem_Click);
            // 
            // instagramToolStripMenuItem
            // 
            this.instagramToolStripMenuItem.Name = "instagramToolStripMenuItem";
            this.instagramToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.instagramToolStripMenuItem.Text = "Instagram";
            this.instagramToolStripMenuItem.Click += new System.EventHandler(this.instagramToolStripMenuItem_Click);
            // 
            // discordToolStripMenuItem
            // 
            this.discordToolStripMenuItem.Name = "discordToolStripMenuItem";
            this.discordToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.discordToolStripMenuItem.Text = "Discord";
            this.discordToolStripMenuItem.Click += new System.EventHandler(this.discordToolStripMenuItem_Click);
            // 
            // googleToolStripMenuItem
            // 
            this.googleToolStripMenuItem.Name = "googleToolStripMenuItem";
            this.googleToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.googleToolStripMenuItem.Text = "Google";
            this.googleToolStripMenuItem.Click += new System.EventHandler(this.googleToolStripMenuItem_Click);
            // 
            // serviceMenu
            // 
            this.serviceMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataMenu,
            this.forumMenu,
            this.accMenu});
            this.serviceMenu.Name = "serviceMenu";
            this.serviceMenu.Size = new System.Drawing.Size(43, 20);
            this.serviceMenu.Text = "服務";
            // 
            // dataMenu
            // 
            this.dataMenu.Name = "dataMenu";
            this.dataMenu.Size = new System.Drawing.Size(134, 22);
            this.dataMenu.Text = "公共資料庫";
            this.dataMenu.Click += new System.EventHandler(this.dataMenu_Click);
            // 
            // forumMenu
            // 
            this.forumMenu.Name = "forumMenu";
            this.forumMenu.Size = new System.Drawing.Size(134, 22);
            this.forumMenu.Text = "討論板";
            this.forumMenu.Click += new System.EventHandler(this.forumMenu_Click_1);
            // 
            // accMenu
            // 
            this.accMenu.Name = "accMenu";
            this.accMenu.Size = new System.Drawing.Size(134, 22);
            this.accMenu.Text = "會員中心";
            this.accMenu.Click += new System.EventHandler(this.accMenu_Click);
            // 
            // loginTrd
            // 
            this.loginTrd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.googleLoginMenu});
            this.loginTrd.Name = "loginTrd";
            this.loginTrd.Size = new System.Drawing.Size(103, 20);
            this.loginTrd.Text = "登入第三方帳戶";
            // 
            // googleLoginMenu
            // 
            this.googleLoginMenu.Name = "googleLoginMenu";
            this.googleLoginMenu.Size = new System.Drawing.Size(117, 22);
            this.googleLoginMenu.Text = "Google";
            this.googleLoginMenu.Click += new System.EventHandler(this.googleLoginMenu_Click);
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView.Location = new System.Drawing.Point(0, 24);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(1008, 705);
            this.webView.Source = new System.Uri("https://www.snkms.com/chat/webchat2/", System.UriKind.Absolute);
            this.webView.TabIndex = 2;
            this.webView.ZoomFactor = 1D;
            // 
            // aboutMenu
            // 
            this.aboutMenu.Name = "aboutMenu";
            this.aboutMenu.Size = new System.Drawing.Size(180, 22);
            this.aboutMenu.Text = "關於軟體";
            this.aboutMenu.Click += new System.EventHandler(this.aboutMenu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(720, 580);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "線上即時聊天室";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainMenu;
        private System.Windows.Forms.ToolStripMenuItem socialMenu;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.ToolStripMenuItem twitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messengerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instagramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceMenu;
        private System.Windows.Forms.ToolStripMenuItem dataMenu;
        private System.Windows.Forms.ToolStripMenuItem forumMenu;
        private System.Windows.Forms.ToolStripMenuItem accMenu;
        private System.Windows.Forms.ToolStripMenuItem pixivMenu;
        private System.Windows.Forms.ToolStripMenuItem loginTrd;
        private System.Windows.Forms.ToolStripMenuItem googleLoginMenu;
        private System.Windows.Forms.ToolStripMenuItem googleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sysMenu;
        private System.Windows.Forms.ToolStripMenuItem nonDisplay;
        private System.Windows.Forms.ToolStripMenuItem checkUpdate;
        private System.Windows.Forms.ToolStripMenuItem aboutMenu;
    }
}

