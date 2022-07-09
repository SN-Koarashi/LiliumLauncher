using Global;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XCoreNET.Tasks
{
    class loginChallengeTask
    {
        public loginChallengeTask()
        {
            gb.resetTokens();
        }
        public loginChallengeTask(bool isSwitching)
        {
            if(!isSwitching)
                gb.resetTokens();
        }

        public async Task<DialogResult> start()
        {
            HttpListener http = new HttpListener();
            // Creates a redirect URI using an available port on the loopback address.
            string redirectURI = string.Format("http://{0}:{1}/", "localhost", 5026);
            output("Redirect URI: " + redirectURI);

            // Creates an HttpListener to listen for requests on that redirect URI.
            http.Prefixes.Add(redirectURI);
            output("Listening...");
            http.Start();



            // Waits for the OAuth authorization response.
            var context = await http.GetContextAsync();

            // Sends an HTTP response to the browser.
            var response = context.Response;
            string responseString = string.Format("<html><head></head><body>Please return to the app.</body></html>");
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
            {
                responseOutput.Close();
                http.Stop();
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
                MessageBox.Show($"登入失敗: {context.Request.QueryString.Get("error")}\n{context.Request.QueryString.Get("error_description")}", "說明", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return DialogResult.None;
            }
        }

        private void output(string output)
        {
            Console.WriteLine(output);
        }
    }
}
