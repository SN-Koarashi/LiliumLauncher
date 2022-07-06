using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Global;
using System.Net.Http;
using System.IO;

namespace webchat
{
    public partial class main : Form
    {
        bool firstStart = false;
        public main()
        {
            Console.WriteLine("初始化程式進入點");
            InitialzeMain();
            InitializeComponent();
        }

        public void InitialzeMain() {
            this.DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkUpdate_Click(sender,e);
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
                System.Console.WriteLine($"找到框架核心版本: {availableVersion}");
            }
            else
            {
                System.Console.WriteLine($"框架核心版本尚未找到: {availableVersion}");
                nonDisplay_Click(sender,e);
            }
        }

        private void mainMenu_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri("https://www.snkms.com/chat/webchat2/");
        }

        private void twitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri("https://twitter.com/");
        }

        private void messengerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri("https://www.messenger.com/");
        }

        private void instagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri("https://www.instagram.com/");
        }

        private void discordToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            webView.Source = new Uri("https://database.snkms.com/");
        }

        private void forumMenu_Click_1(object sender, EventArgs e)
        {
            webView.Source = new Uri("https://forum.snkms.com/");
        }

        private void accMenu_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri("https://account.snkms.com/");
        }

        private void pixivMenu_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri("https://www.pixiv.net/");
        }

        private void googleLoginMenu_Click(object sender, EventArgs e)
        {
            loginGoogleForm gl = null;
            if (gl == null || gl.IsDisposed)
                gl = new loginGoogleForm();

            gl.Show();
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

        private async void checkUpdate_Click(object sender, EventArgs e)
        {
            string hostUrl = "https://github.com/SN-Koarashi/WebChat/releases/latest";
            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = false
            };
            var httpClient = new HttpClient(handler);
            HttpRequestMessage request = new HttpRequestMessage
            {
                RequestUri = new Uri(hostUrl),
                Method = HttpMethod.Head
            };

            var result = await httpClient.SendAsync(request);
            string latestURL = result.Headers.Location.AbsoluteUri;
            string UpdaterPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            var versionInfo = FileVersionInfo.GetVersionInfo(@UpdaterPath + Path.DirectorySeparatorChar + "webchat.exe");
            Version versionLocal = new Version(versionInfo.ProductVersion);
            Version versionRemote = new Version(latestURL.Split(new string[] { "/releases/tag/" }, StringSplitOptions.None)[1].Replace("v", string.Empty));


            Console.WriteLine($"本機應用程式版本: {versionLocal}");
            Console.WriteLine($"遠端應用程式版本: {versionRemote}");

            var compareResult = versionRemote.CompareTo(versionLocal);
            if (compareResult > 0)
            {
                var resultUpdate = MessageBox.Show("偵測到更新的應用程式版本，是否執行更新？", "說明", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultUpdate == DialogResult.Yes) {
                    var p = new Process();
                    p.StartInfo.FileName = UpdaterPath + Path.DirectorySeparatorChar + "webchat-updater.exe";  // just for example, you can use yours.
                    p.Start();
                    Application.Exit();
                }
            }
            else
            {
                if (!firstStart) {
                    firstStart = true;
                    string tempFile = UpdaterPath + Path.DirectorySeparatorChar + "webchat-installer-temp.exe";
                    if (File.Exists(tempFile))
                        File.Delete(tempFile);
                }
                else
                    MessageBox.Show("應用程式已為最新版本", "說明",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"使用 WebView2 框架載入多個社交媒體網站及附帶以WebSocket技術為基底的線上聊天室" + 
                System.Environment.NewLine + 
                "此軟體僅支援安裝 .NET Framework 4.7.2 以上及 Windows 10 (1909) 以上之作業系統"
                ,"說明",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
