using Global;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using static XCoreNET.ClassModel.globalModel;

namespace XCoreNET
{
    public partial class settingForm : Form
    {
        private string temp_login_method = "default";
        public settingForm()
        {
            InitializeComponent();

            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + "/settings/programs_settings.json");

            if (File.Exists(path))
            {
                var data = File.ReadAllText(path);
                var pm = JsonConvert.DeserializeObject<ProgramModel>(data);

                chkLauncherMain.Checked = pm.launcher;
                chkNoWebView.Checked = pm.noWevView;
                chkUpdates.Checked = (bool) (pm.checkForUpdates != null ? pm.checkForUpdates : true);

                if (pm.loginMethod != null)
                {
                    if (pm.loginMethod.Equals("webview2"))
                    {
                        radLauncherWebView.Checked = true;
                    }
                    else if (pm.loginMethod.Equals("browser"))
                    {
                        radLauncherBrowser.Checked = true;
                    }
                    else
                    {
                        radLauncherDef.Checked = true;
                    }
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                bool notifyBox = false;

                if (textBox1.Text != String.Empty)
                    new Uri(textBox1.Text);

                if (textBox2.Text != String.Empty)
                    new Uri(textBox2.Text);

                if (!gb.launcherHomepage.Equals(textBox2.Text) || !gb.mainHomepage.Equals(textBox1.Text))
                    notifyBox = true;


                ProgramModel pm = new ProgramModel();
                pm.checkForUpdates = chkUpdates.Checked;
                pm.launcher = chkLauncherMain.Checked;
                pm.noWevView = chkNoWebView.Checked;
                pm.loginMethod = temp_login_method;
                pm.mainURL = (textBox1.Text != String.Empty) ? textBox1.Text : "https://www.snkms.com/chat/webchat2/";
                pm.launcherURL = (textBox2.Text != String.Empty) ? textBox2.Text : "https://www.snkms.com/minecraftNews.html";

                gb.mainHomepage = new Uri(pm.mainURL);
                gb.launcherHomepage = new Uri(pm.launcherURL);
                gb.loginMethod = temp_login_method;

                Directory.CreateDirectory("settings");
                File.WriteAllText($"settings{Path.DirectorySeparatorChar}programs_settings.json", JsonConvert.SerializeObject(pm));


                if (notifyBox)
                {
                    var result = MessageBox.Show("變更啟動參數需要重新啟動程式才能生效，要現在重新啟動嗎？", "說明", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Application.ExecutablePath);
                        Environment.Exit(0);
                    }
                }


                btnApply.Enabled = false;
                btnOK.Enabled = false;
            }
            catch (UriFormatException ufe)
            {
                MessageBox.Show(ufe.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            btnApply_Click(sender, e);
            this.Close();
        }

        private void settingForm_Load(object sender, EventArgs e)
        {
            btnApply.Enabled = false;
            btnOK.Enabled = false;

            textBox1.Text = gb.mainHomepage.ToString();
            textBox2.Text = gb.launcherHomepage.ToString();
        }

        private void chkNoWebView_Click(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnOK.Enabled = true;
        }

        private void chkLauncherMain_Click(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnOK.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnOK.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnOK.Enabled = true;
        }

        private void radLauncherDef_Click(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnOK.Enabled = true;

            temp_login_method = "default";
        }

        private void radLauncherWebView_Click(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnOK.Enabled = true;

            temp_login_method = "webview2";
        }

        private void radLauncherBrowser_Click(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnOK.Enabled = true;

            temp_login_method = "browser";
        }

        private void chkUpdates_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnOK.Enabled = true;
        }
    }
}
