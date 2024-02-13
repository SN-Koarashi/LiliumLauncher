using Global;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using static XCoreNET.ClassModel.globalModel;
using static XCoreNET.ClassModel.locateModel;

namespace XCoreNET
{
    public partial class settingForm : Form
    {
        bool onStarted = false;
        private string temp_login_method = "default";
        manifestListModel manifestListModel = new manifestListModel();

        public settingForm()
        {
            InitializeComponent();

            var settingsPath = Path.GetFullPath(Directory.GetCurrentDirectory() + "/settings/programs_settings.json");

            if (File.Exists(settingsPath))
            {
                var data = File.ReadAllText(settingsPath);
                var pm = JsonConvert.DeserializeObject<ProgramModel>(data);

                chkLauncherMain.Checked = pm.launcher;
                chkNoWebView.Checked = pm.noWevView;
                chkUpdates.Checked = (bool)(pm.checkForUpdates != null ? pm.checkForUpdates : true);
                chkSaveLog.Checked = pm.isSaveLogFile;
                temp_login_method = pm.loginMethod;

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

            var locatesPath = Path.GetFullPath(Directory.GetCurrentDirectory() + "/locates/manifest.json");

            if (File.Exists(locatesPath))
            {
                manifestListModel = JsonConvert.DeserializeObject<manifestListModel>(File.ReadAllText(locatesPath));

                foreach (var locate in manifestListModel.locates)
                {
                    comboBox1.Items.Add(locate.displayName);
                }


                for (int i = 0; i < manifestListModel.locates.Count; i++)
                {
                    if (manifestListModel.locates[i].name.Equals(gb.langCode))
                    {
                        comboBox1.SelectedIndex = i;
                    }
                }

                if (comboBox1.SelectedIndex == -1)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
            else
            {
                comboBox1.Enabled = false;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                bool notifyBox = false;
                bool langNotify = false;
                int langIndex = comboBox1.SelectedIndex;
                string langText = (manifestListModel.locates != null && manifestListModel.locates.Count > 0 && manifestListModel.locates.Count > langIndex) ? manifestListModel.locates[langIndex].name : null;


                if (textBox1.Text != String.Empty)
                    new Uri(textBox1.Text);

                if (textBox2.Text != String.Empty)
                    new Uri(textBox2.Text);

                if (langText != null && langText != gb.langCode)
                    langNotify = true;

                if (!gb.launcherHomepage.Equals(textBox2.Text) || !gb.mainHomepage.Equals(textBox1.Text))
                    notifyBox = true;

                ProgramModel pm = new ProgramModel();
                pm.checkForUpdates = chkUpdates.Checked;
                pm.launcher = chkLauncherMain.Checked;
                pm.noWevView = chkNoWebView.Checked;
                pm.isSaveLogFile = chkSaveLog.Checked;
                pm.loginMethod = temp_login_method;
                pm.mainURL = (textBox1.Text != String.Empty) ? textBox1.Text : "https://www.snkms.com/chat/webchat2/";
                pm.launcherURL = (textBox2.Text != String.Empty) ? textBox2.Text : "https://www.snkms.com/minecraftNews.html";
                pm.langCode = langText;

                gb.mainHomepage = new Uri(pm.mainURL);
                gb.launcherHomepage = new Uri(pm.launcherURL);
                gb.loginMethod = temp_login_method;
                gb.isSaveLogFile = chkSaveLog.Checked;

                Directory.CreateDirectory("settings");
                File.WriteAllText($"settings{Path.DirectorySeparatorChar}programs_settings.json", JsonConvert.SerializeObject(pm));


                if (notifyBox)
                {
                    var result = MessageBox.Show(gb.lang.DIALOG_PARMS_RESTART_CONFIRM, gb.lang.DIALOG_INFO, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Application.ExecutablePath);
                        Environment.Exit(0);
                    }
                }

                if (langNotify)
                {
                    var result = MessageBox.Show(gb.lang.DIALOG_LANG_RESTART_CONFIRM, gb.lang.DIALOG_INFO, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                }
                btnApply.Enabled = false;
                btnOK.Enabled = false;
            }
            catch (UriFormatException ufe)
            {
                MessageBox.Show(ufe.Message, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            btnApply_Click(sender, e);
            this.Close();
        }

        private void setTranslate()
        {
            this.Text = gb.lang.FORM_TITLE_SETTINGS;
            this.Font = new System.Drawing.Font(gb.lang.FONT_FAMILY_CHILD, gb.lang.FONT_SIZE_CHILD);
            groupBoxLauncherLang.Text = gb.lang.GROUP_LAUNCHER_LANGUAGE;
            groupBoxLauncherMethod.Text = gb.lang.GROUP_LAUNCHER_LOGIN_METHOD;
            groupBoxStaarupParms.Text = gb.lang.GROUP_STARTUP_PARMS;
            groupBoxWebview2Default.Text = gb.lang.GROUP_WEBVIEW2_DEFAULT;
            label1.Text = gb.lang.LAB_CUSTOM_HOME_URL;
            label2.Text = gb.lang.LAB_CUSTOM_LAUNCHER_URL;
            label3.Text = gb.lang.LAB_CHANGE_LANGUAGE_NOTICE;
            chkLauncherMain.Text = gb.lang.CHK_SETTING_MINECRAFT_TO_MAIN;
            chkNoWebView.Text = gb.lang.CHK_DISABLED_WEBVIEW2;
            chkUpdates.Text = gb.lang.CHK_CHECKING_UPDATES_WHEN_START_UP;
            chkSaveLog.Text = gb.lang.CHK_SAVE_LOG;
            radLauncherDef.Text = gb.lang.RAD_METHOD_DEFAULT;
            radLauncherWebView.Text = gb.lang.RAD_METHOD_WEBVIEW2;
            radLauncherBrowser.Text = gb.lang.RAD_METHOD_BROWSER;
            btnApply.Text = gb.lang.BTN_APPLY;
            btnOK.Text = gb.lang.BTN_OK;
        }
        private void settingForm_Load(object sender, EventArgs e)
        {
            setTranslate();

            textBox1.Text = gb.mainHomepage.ToString();
            textBox2.Text = gb.launcherHomepage.ToString();

            btnApply.Enabled = false;
            btnOK.Enabled = false;

            onStarted = true;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (onStarted)
            {
                btnApply.Enabled = true;
                btnOK.Enabled = true;
            }
        }

        private void chkSaveLog_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnOK.Enabled = true;
        }
    }
}
