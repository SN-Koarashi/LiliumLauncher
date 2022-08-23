using Global;
using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace XCoreNET
{
    public partial class loginMicrosoftForm : Form
    {
        public loginMicrosoftForm()
        {
            InitializeComponent();
        }

        private void loginMicrosoftForm_Load(object sender, EventArgs e)
        {
            webView.Source = new Uri(gb.getMicrosoftOAuthURL());

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
                MessageBox.Show("找不到 WebView2 核心框架，因此無法透過 Microsoft OAuth 登入您的帳戶", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                var result = MessageBox.Show("是否要重新導向到下載頁面以下載 Microsoft Edge WebView2？", "說明", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    OpenUrl("https://developer.microsoft.com/zh-tw/microsoft-edge/webview2/");
                }

                this.Close();
            }
        }

        private async void webView_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            if (e.Uri.StartsWith("http://localhost:5026/"))
            {
                // 清除在 WebView2 中的 Cookies
                var cookies = await webView.CoreWebView2.CookieManager.GetCookiesAsync(gb.getMicrosoftOAuthURL());
                foreach (var cookie in cookies)
                {
                    webView.CoreWebView2.CookieManager.DeleteCookie(cookie);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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
    }
}
