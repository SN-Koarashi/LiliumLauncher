using Global;
using System;
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
            string microsoftOAuthURL = "https://login.live.com/oauth20_authorize.srf?" +
                $"client_id={gb.azureClientID}" +
                "&response_type=code&scope=XboxLive.signin%20offline_access" +
                "&redirect_uri=http%3A%2F%2Flocalhost%3A5026" +
                "&cobrandid=8058f65d-ce06-4c30-9559-473c9275a65d&prompt=select_account";

            webView.Source = new Uri(microsoftOAuthURL);
        }

        private void webView_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            if (e.Uri.StartsWith("http://localhost:5026/"))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
