using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Global;

namespace XCoreNET
{
    public partial class minecraftMainForm : Form
    {
        public minecraftMainForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_ClickAsync(object sender, EventArgs e)
        {
            loginMicrosoftForm lmf = new loginMicrosoftForm();
            var resultDialog = lmf.ShowDialog();
            if (resultDialog != DialogResult.Cancel)
            {
                Tasks.loginChallengeTask challenge = new Tasks.loginChallengeTask();
                var result = await challenge.start();
                gb.firstStart = false;

                this.DialogResult = result;
            }
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
            btnUpdate_Click(sender,e);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
