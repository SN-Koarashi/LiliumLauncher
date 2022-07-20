using Global;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using static Global.gb;

namespace XCoreNET
{
    public partial class settingForm : Form
    {
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
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != String.Empty)
                    new Uri(textBox1.Text);

                if (textBox2.Text != String.Empty)
                    new Uri(textBox2.Text);


                ProgramModel pm = new ProgramModel();
                pm.launcher = chkLauncherMain.Checked;
                pm.noWevView = chkNoWebView.Checked;
                pm.mainURL = (textBox1.Text != String.Empty) ? textBox1.Text : "https://www.snkms.com/chat/webchat2/";
                pm.launcherURL = (textBox2.Text != String.Empty) ? textBox2.Text : "https://www.snkms.com/minecraftNews.html";

                gb.mainHomepage = new Uri(pm.mainURL);
                gb.launcherHomepage = new Uri(pm.launcherURL);

                Directory.CreateDirectory("settings");
                File.WriteAllText($"settings{Path.DirectorySeparatorChar}programs_settings.json", JsonConvert.SerializeObject(pm));


                var result = MessageBox.Show("變更需要重新啟動程式才能生效，要現在重新啟動嗎？", "說明", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
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
    }
}
