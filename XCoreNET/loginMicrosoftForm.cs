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
            this.Text = gb.lang.FORM_TITLE_MICROSOFT_OAUTH;
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
                if (gb.loginMethod.Equals("browser"))
                {
                    askBrowserLogin(true);
                }
            }
            else
            {
                Console.WriteLine($"框架核心版本尚未找到: {availableVersion}");
                if (gb.loginMethod.Equals("webview2"))
                {
                    WebView2CoreNotFound();
                    askWebViewDownload(true);
                }
                else if (gb.loginMethod.Equals("browser"))
                {
                    askBrowserLogin(true);
                }
                else
                {
                    WebView2CoreNotFound();
                    if (!askWebViewDownload(false))
                    {
                        askBrowserLogin(false);
                    }
                }

                this.Close();
            }
        }
        private void askBrowserLogin(bool ignoreAsk)
        {
            if (ignoreAsk)
            {
                //OpenUrl(gb.getMicrosoftOAuthURL());
                this.DialogResult = DialogResult.Ignore;
            }
            else
            {

                var openOrigin = MessageBox.Show(gb.lang.DIALOG_BROWSER_CONFIRM, gb.lang.DIALOG_INFO, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (openOrigin == DialogResult.Yes)
                {
                    //OpenUrl(gb.getMicrosoftOAuthURL());
                    this.DialogResult = DialogResult.Ignore;
                }
                else
                {
                    MessageBox.Show(gb.lang.DIALOG_CANT_LOGIN_MICROSOFT, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void WebView2CoreNotFound()
        {
            MessageBox.Show(gb.lang.DIALOG_NO_WEBVIEW2, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private bool askWebViewDownload(bool showError)
        {
            var result = MessageBox.Show(gb.lang.DIALOG_REDIRECT_WEBVIEW2_CONFIRM, gb.lang.DIALOG_INFO, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                OpenUrl("https://developer.microsoft.com/zh-tw/microsoft-edge/webview2/");
                return true;
            }
            else if (result == DialogResult.No && showError)
            {
                MessageBox.Show(gb.lang.DIALOG_CANT_LOGIN_MICROSOFT, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
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
