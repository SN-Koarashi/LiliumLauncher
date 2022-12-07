using Global;
using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace XCoreNET
{
    public partial class main : Form
    {
        bool wantLaunch = false;
        bool isWebViewDisposed = false;
        bool isForced = false;

        public main()
        {
            Console.WriteLine("初始化程式進入點");
            InitialzeMain();
            InitializeComponent();
        }
        public main(string[] args)
        {
            Console.WriteLine("初始化程式進入點: 參數啟動");
            foreach (var arg in args)
            {
                if (arg.ToLower().Equals("-nowebview"))
                {
                    isWebViewDisposed = true;
                }
                if (arg.ToLower().Equals("-forcechat"))
                {
                    isForced = true;
                }
            }

            InitializeComponent();
            InitialzeMain();
        }

        public void InitialzeMain()
        {
            this.DoubleBuffered = true;

            if (isForced)
            {
                minecraftMenu.Visible = false;
                minecraftLaunchMenu.Visible = false;
                systemSettingsMenu.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (isWebViewDisposed)
            {
                webView.Dispose();
            }
            else
            {
                webView.Source = gb.mainHomepage;
            }


            checkUpdate_Click(sender, e);
            string availableVersion = null;
            try
            {
                availableVersion = CoreWebView2Environment.GetAvailableBrowserVersionString();
            }
            catch (WebView2RuntimeNotFoundException)
            {
            }

            if (availableVersion != null &&
                CoreWebView2Environment.CompareBrowserVersions(availableVersion, "100.0.0.0") >= 0)
            {
                Console.WriteLine($"找到框架核心版本: {availableVersion}");
            }
            else
            {
                Console.WriteLine($"框架核心版本尚未找到: {availableVersion}");
                nonDisplay_Click(sender, e);
            }
        }

        private void mainMenu_Click(object sender, EventArgs e)
        {
            if (webView.IsDisposed)
            {
                MessageBox.Show("使用 -noWebview 參數啟動時不會載入主 WebView 框架", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                webView.Source = gb.mainHomepage;
        }

        private void twitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webView.IsDisposed)
            {
                MessageBox.Show("使用 -noWebview 參數啟動時不會載入主 WebView 框架", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                webView.Source = new Uri("https://twitter.com/");
        }

        private void messengerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webView.IsDisposed)
            {
                MessageBox.Show("使用 -noWebview 參數啟動時不會載入主 WebView 框架", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                webView.Source = new Uri("https://www.messenger.com/");
        }

        private void instagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webView.IsDisposed)
            {
                MessageBox.Show("使用 -noWebview 參數啟動時不會載入 WebView 框架", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                webView.Source = new Uri("https://www.instagram.com/");
        }

        private void discordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webView.IsDisposed)
            {
                MessageBox.Show("使用 -noWebview 參數啟動時不會載入主 WebView 框架", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                webView.Source = new Uri("https://discord.com/channels/@me");
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void dataMenu_Click(object sender, EventArgs e)
        {
            if (webView.IsDisposed)
            {
                MessageBox.Show("使用 -noWebview 參數啟動時不會載入主 WebView 框架", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                webView.Source = new Uri("https://database.snkms.com/");
        }

        private void forumMenu_Click_1(object sender, EventArgs e)
        {
            if (webView.IsDisposed)
            {
                MessageBox.Show("使用 -noWebview 參數啟動時不會載入主 WebView 框架", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                webView.Source = new Uri("https://forum.snkms.com/");
        }

        private void accMenu_Click(object sender, EventArgs e)
        {
            if (webView.IsDisposed)
            {
                MessageBox.Show("使用 -noWebview 參數啟動時不會載入主 WebView 框架", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                webView.Source = new Uri("https://account.snkms.com/");
        }

        private void pixivMenu_Click(object sender, EventArgs e)
        {
            if (webView.IsDisposed)
            {
                MessageBox.Show("使用 -noWebview 參數啟動時不會載入主 WebView 框架", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                webView.Source = new Uri("https://www.pixiv.net/");
        }

        private void googleLoginMenu_Click(object sender, EventArgs e)
        {
            loginGoogleForm gl = new loginGoogleForm();
            gl.ShowDialog();
        }

        private void googleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri("https://www.google.com/");
        }

        private void nonDisplay_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("沒有畫面通常是您的電腦尚未安裝 Microsoft Edge WebView2\n是否要重新導向到下載頁面？", "說明", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                OpenUrl("https://developer.microsoft.com/zh-tw/microsoft-edge/webview2/");
            }
        }

        private void checkUpdate_Click(object sender, EventArgs e)
        {
            gb.checkForUpdate();
        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"使用 WebView2 框架載入多個社交媒體網站及附帶以 WebSocket 技術為基底的線上聊天室，同時擁有基礎的 Minecraft 啟動器功能" +
                System.Environment.NewLine +
                "此軟體僅支援安裝 .NET Framework 4.7.2 以上及 Windows 10 (1909) 以上之作業系統"
                , "說明", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        minecraftForm mf = null;
        private void minecraftMenu_Click(object sender, EventArgs e)
        {
            gb.readingSession();
            if (gb.azureToken.Length > 0 || gb.refreshToken.Length > 0)
            {

                if (mf == null || mf.IsDisposed)
                    mf = new minecraftForm();

                mf.Show();
                mf.Activate();
            }
            else
            {
                minecraftMenu_Click_1(sender, e);
                wantLaunch = true;
            }
        }

        private async void minecraftMenu_Click_1(object sender, EventArgs e)
        {
            loginMicrosoftForm lmf = new loginMicrosoftForm();
            var resultDialog = lmf.ShowDialog();

            if (resultDialog == DialogResult.Cancel)
                this.Close();
            else
            {
                Tasks.loginChallengeTask challenge = new Tasks.loginChallengeTask();
                var result = await challenge.start();

                if (result == DialogResult.OK)
                {
                    if (wantLaunch)
                    {
                        minecraftMenu_Click(sender, e);
                        wantLaunch = false;
                    }
                }
            }
        }


        private void systemSettingsMenu_Click(object sender, EventArgs e)
        {
            settingForm sf = new settingForm();
            sf.ShowDialog();
        }

        private void loadingPageMenu_Click(object sender, EventArgs e)
        {
            var result = Microsoft.VisualBasic.Interaction.InputBox("輸入網址...", "載入網頁到主框架");
            if (result.Length > 0)
            {
                try
                {
                    Uri url = new Uri(result);
                    webView.Source = url;
                }
                catch (UriFormatException ufe)
                {
                    Console.WriteLine(ufe.Message);
                    MessageBox.Show(ufe.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bahamutMenu_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri("https://www.gamer.com.tw/");
        }
    }
}
