using Global;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace XCoreNET
{
    public partial class minecraftMultuAccount : Form
    {
        public minecraftMultuAccount()
        {
            InitializeComponent();
        }

        private void DrawingAccountList()
        {
            this.panel.Controls.Clear();

            int x = 5;
            int y = 5;
            int k = 0;
            foreach (var item in gb.account)
            {
                PictureBox avatar = new PictureBox();
                avatar.WaitOnLoad = false;
                avatar.LoadAsync($"https://cravatar.eu/helmavatar/{item.Key}");
                avatar.Location = new System.Drawing.Point(x, y + 40 * k);
                avatar.Width = 32;
                avatar.Height = 32;

                TextBox username = new TextBox();
                username.ReadOnly = true;
                username.Location = new System.Drawing.Point(x + 36, (int)(y * 2.5 + 40 * k));
                username.Text = item.Value.username;
                username.Font = new Font("Verdana", 10);
                username.Width = 130;
                username.BorderStyle = BorderStyle.None;
                toolTip.SetToolTip(username, item.Key);

                Button btnSwitch = new Button();
                btnSwitch.Text = "切換";
                btnSwitch.Width = 50;
                btnSwitch.Height = 24;
                btnSwitch.Location = new System.Drawing.Point(x + 170, y * 2 + 40 * k);

                Button btnDel = new Button();
                btnDel.Text = "刪除";
                btnDel.Width = 50;
                btnDel.Height = 24;
                btnDel.Location = new System.Drawing.Point(x + 225, y * 2 + 40 * k);

                this.panel.Controls.Add(avatar);
                this.panel.Controls.Add(btnSwitch);
                this.panel.Controls.Add(btnDel);
                this.panel.Controls.Add(username);

                if (item.Key.Equals(gb.minecraftUUID))
                {
                    btnDel.Enabled = false;
                    username.SelectionStart = username.TextLength;
                    username.SelectionLength = 0;

                    btnSwitch.Text = "刷新";
                    btnSwitch.Click += (senderx, ex) =>
                    {
                        gb.refreshToken = item.Value.refreshToken;
                        gb.launchToken = item.Value.accessToken;
                        gb.launchTokenExpiresAt = item.Value.expiresAt;
                        gb.minecraftUsername = item.Value.username;
                        gb.minecraftUUID = item.Key;

                        this.DialogResult = DialogResult.Abort;
                    };

                    toolTip.SetToolTip(btnSwitch, "刷新目前帳號的登入權杖，可以解決一些伺服器或服務無法登入的問題");
                }
                else
                {
                    btnSwitch.Click += (senderx, ex) =>
                    {
                        gb.refreshToken = item.Value.refreshToken;
                        gb.launchToken = item.Value.accessToken;
                        gb.launchTokenExpiresAt = item.Value.expiresAt;
                        gb.minecraftUsername = item.Value.username;
                        gb.minecraftUUID = item.Key;

                        this.DialogResult = DialogResult.OK;
                    };
                    btnDel.Click += (senderx, ex) =>
                    {
                        var reuslt = MessageBox.Show("確定刪除此帳戶的登入權杖嗎？", "說明", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (reuslt == DialogResult.Yes)
                        {
                            gb.resetTokens(item.Key);
                            gb.savingSession(true);
                            DrawingAccountList();
                        }
                    };

                    toolTip.SetToolTip(btnSwitch, "切換至此帳號並取得新的登入權杖");
                    toolTip.SetToolTip(btnDel, "從多帳號管理中刪除此帳號的紀錄");
                }

                k++;
            }


            if (k == 0) this.Close();
        }

        private void minecraftMultuAccount_Load(object sender, EventArgs e)
        {
            DrawingAccountList();
            this.Focus();
        }
    }
}
