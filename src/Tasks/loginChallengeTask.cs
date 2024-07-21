using Global;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LiliumLauncher.ClassModel.globalModel;

namespace LiliumLauncher.Tasks
{
    class loginChallengeTask
    {
        public loginChallengeTask()
        {
            gb.resetTokens();
        }
        public loginChallengeTask(bool isSwitching)
        {
            if (!isSwitching)
                gb.resetTokens();
        }

        public async Task<DialogResult> start()
        {
            HttpListener http = new HttpListener();
            // Creates a redirect URI using an available port on the loopback address.
            string redirectURI = string.Format("http://{0}:{1}/", "localhost", 5026);
            output("Redirect URI: " + redirectURI);
            try
            {
                // Creates an HttpListener to listen for requests on that redirect URI.
                http.Prefixes.Add(redirectURI);
                output("Listening...");
                http.Start();
                gb.httpUsing = true;



                // Waits for the OAuth authorization response.
                var context = await http.GetContextAsync();

                // Sends an HTTP response to the browser.
                var response = context.Response;
                //string responseString = string.Format("<html><head></head><body>Please return to the app.</body></html>");
                //string responseString = "<html><head><meta charset=\"utf-8\" /></head><body><div align=\"center\"><h1>工作階段已結束，請關閉此視窗並回到應用程式。</h1></div></body></html>";
                string responseString = gb.getBrowserLoginHTML();
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                var responseOutput = response.OutputStream;
                Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
                {
                    responseOutput.Close();
                    http.Stop();
                    gb.httpUsing = false;
                    Console.WriteLine("HTTP server stopped.");
                });

                if (context.Request.QueryString.Get("code") != null)
                {
                    output(context.Request.QueryString.Get("code"));
                    gb.azureToken = context.Request.QueryString.Get("code");

                    return DialogResult.OK;
                }
                else
                {
                    output($"登入失敗: {context.Request.QueryString.Get("error")}");
                    MessageBox.Show($"{gb.lang.DIALOG_LOGIN_FAILED}{context.Request.QueryString.Get("error")}\n{context.Request.QueryString.Get("error_description")}", gb.lang.DIALOG_INFO, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return DialogResult.None;
                }
            }
            catch (Exception exx)
            {
                output($"登入失敗: {exx.Message}");
                MessageBox.Show($"{gb.lang.DIALOG_LOGIN_FAILED}{exx.Message}", gb.lang.DIALOG_INFO, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return DialogResult.None;
            }
        }

        public static bool SupportBrowser(BrowserInfoModel bim)
        {
            return bim.name.Equals("MSEdgeHTM") || bim.name.Equals("ChromeHTML");
        }
        public static ProcessStartInfo BrowserStartInfo(BrowserInfoModel bim, string profile)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = bim.path;
            startInfo.Arguments = $"--inprivate --private --incognito --new-window {profile} {gb.getMicrosoftOAuthURL()}";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            return startInfo;
        }
        public static void BrowserClosed(string path)
        {
            Console.WriteLine("瀏覽器已關閉");
            if (gb.httpUsing)
            {
                WebClient client = new WebClient();
                client.DownloadString("http://localhost:5026/?type=cancel&error=BrowserClosed");
            }
            Task.Delay(500).Wait();
            Directory.Delete(Path.GetFullPath(path + "/Default/Network"), true);
        }
        public static BrowserInfoModel DeterminePath()
        {
            string path = String.Empty;
            string prodID = String.Empty;
            RegistryKey regKey = null;
            string ErrorMessage = null;

            try
            {
                //set the registry key we want to open
                regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice", false);

                //get rid of the enclosing quotes
                prodID = regKey.GetValue("Progid").ToString().Replace("" + (char)34, "");
                Console.WriteLine($"Prod Name: {prodID}");

                regKey = Registry.ClassesRoot.OpenSubKey(prodID + @"\shell\open\command", false);

                path = regKey.GetValue(null).ToString().Replace("" + (char)34, "");

                if (!path.EndsWith("exe"))
                    path = path.Substring(0, path.LastIndexOf(".exe") + 4);
            }
            catch (Exception ex)
            {
                ErrorMessage = string.Format("ERROR: An exception of type: {0} occurred in method: {1} in the following module", ex.GetType(), ex.TargetSite);
                Console.WriteLine(ErrorMessage);
            }
            finally
            {
                //check and see if the key is still open, if so
                //then close it
                if (regKey != null)
                    regKey.Close();
            }

            BrowserInfoModel bim = new BrowserInfoModel();
            bim.name = prodID;
            bim.path = path;
            return bim;
        }
        private void output(string output)
        {
            Console.WriteLine(output);
        }
    }
}
