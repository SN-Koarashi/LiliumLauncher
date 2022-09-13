using Global;
using System;
using System.Windows.Forms;

namespace XCoreNET
{
    public partial class minecraftMainForm : Form
    {
        public minecraftMainForm()
        {
            InitializeComponent();

            if (gb.account.Count > 0)
            {
                this.tableLayoutPanel1.SetColumnSpan(btnSetting, 1);


                Button btnSwitch = new Button();
                btnSwitch.Width = btnLogin.Width;
                btnSwitch.Text = "切換帳戶";
                btnSwitch.Font = btnLogin.Font;
                btnSwitch.Height = btnLogin.Height;
                this.tableLayoutPanel1.Controls.Add(btnSwitch, 2, 1);


                btnSwitch.Click += (senderx, ex) =>
                {
                    minecraftMultuAccount ma = new minecraftMultuAccount();
                    ma.Text = "切換至其他已登入帳戶";
                    var result = ma.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        gb.firstStart = false;
                        this.DialogResult = result;
                    }


                    ma.Dispose();
                };
            }
        }

        private async void btnLogin_ClickAsync(object sender, EventArgs e)
        {
            tableLayoutPanel1.Enabled = false;
            loginMicrosoftForm lmf = new loginMicrosoftForm();
            var resultDialog = lmf.ShowDialog();
            if (resultDialog != DialogResult.Cancel)
            {
                Tasks.loginChallengeTask challenge = new Tasks.loginChallengeTask();
                var result = await challenge.start();
                gb.firstStart = false;

                this.DialogResult = result;
            }

            tableLayoutPanel1.Enabled = true;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            settingForm sf = new settingForm();
            sf.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            gb.checkForUpdate();
        }

        private void minecraftMainForm_Load(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }
    }
}
