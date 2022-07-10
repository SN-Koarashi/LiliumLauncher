using Global;
using Microsoft.Web.WebView2.Core;
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
            webView.Source = new Uri(gb.getMicrosoftOAuthURL());
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
