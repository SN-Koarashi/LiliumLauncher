using Global;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace XCoreNET
{
    public partial class minecraftAddInstance : Form
    {
        string DATA_FOLDER;

        public minecraftAddInstance()
        {
            InitializeComponent();
        }

        public minecraftAddInstance(ComboBox.ObjectCollection args, string mainFolder)
        {
            InitializeComponent();


            foreach (var item in args)
            {
                specificVersionList.Items.Add(item);
            }

            DATA_FOLDER = mainFolder;
        }

        private void chkOpenSpecific_CheckedChanged(object sender, EventArgs e)
        {
            specificVersionList.Enabled = chkOpenSpecific.Checked;
            textBoxNowVersion.Enabled = chkOpenSpecific.Checked;

            if (!chkOpenSpecific.Checked)
                specificVersionList.SelectedIndex = -1;

            specificVersionList.DropDownWidth = (gb.DropDownWidth(specificVersionList) + 25 > 300) ? 300 : gb.DropDownWidth(specificVersionList) + 25;
        }

        private void minecraftAddInstance_Load(object sender, EventArgs e)
        {

        }

        private void btnIntro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("請將「實例名稱」輸入您自身可辨識的自訂名稱。\n而「以指定版本啟動」之設定若為開啟，將會在您選擇此實例時自動以指定版本啟動遊戲，藉此省去頻繁修改版本的動作。", "說明", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var result = textInstanceName.Text;
            if (result != null && result.Trim().Length > 0)
            {
                try
                {
                    var path = gb.PathJoin(DATA_FOLDER, ".x-instance", result.Trim());
                    if (Directory.Exists(path))
                    {
                        MessageBox.Show($"建立失敗: 此實例名稱已存在", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textInstanceName.Text = "";
                    }
                    else
                    {
                        Directory.CreateDirectory(path);

                        if (chkOpenSpecific.Checked && specificVersionList.SelectedIndex != -1)
                        {
                            byte[] data = Encoding.ASCII.GetBytes(specificVersionList.SelectedItem.ToString());
                            File.WriteAllBytes(gb.PathJoin(path, "version.bin"), data);
                        }


                        gb.instance.Add(path);
                        gb.lastInstance = path;

                        gb.savingSession(false);

                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception exx)
                {
                    MessageBox.Show($"建立失敗: {exx.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textInstanceName.Text = "";
                }
            }
            else
            {
                MessageBox.Show($"建立失敗: 請輸入實例名稱", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void minecraftAddInstance_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void specificVersionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (specificVersionList.SelectedIndex != -1)
                textBoxNowVersion.Text = specificVersionList.SelectedItem.ToString();
            else
                textBoxNowVersion.Text = "";
        }
    }
}
