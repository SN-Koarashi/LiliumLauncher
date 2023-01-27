using Global;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static XCoreNET.ClassModel.globalModel;

namespace XCoreNET
{
    public partial class minecraftActionInstance : Form
    {
        string DATA_FOLDER;
        string currentInstance;

        public minecraftActionInstance()
        {
            InitializeComponent();
        }

        public minecraftActionInstance(string mainFolder, string instance)
        {
            InitializeComponent();

            /*
            foreach (var item in args)
            {
                specificVersionList.Items.Add(item);
            }
            */

            DATA_FOLDER = mainFolder;
            currentInstance = instance;
        }

        private void chkOpenSpecific_CheckedChanged(object sender, EventArgs e)
        {
            btnVersionSelector.Enabled = chkOpenSpecific.Checked;
            textBoxNowVersion.Enabled = chkOpenSpecific.Checked;
        }


        private void btnIntro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("請將「實例名稱」輸入您自身可辨識的自訂名稱。\n而「以指定版本啟動」之設定若為開啟，將會在您選擇此實例時自動「鎖定」為指定版本，藉此省去頻繁修改版本的動作。", "說明", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var result = textInstanceName.Text;
            if (result != null && result.Trim().Length > 0)
            {
                try
                {
                    if (currentInstance != null)
                    {
                        var newPath = gb.PathJoin(DATA_FOLDER, ".x-instance", result.Trim());
                        var oldPath = currentInstance;
                        string destPath;

                        InstanceModel im = new InstanceModel();
                        im.lastname = newPath;
                        im.javaPath = textJava.Text;
                        im.jvmParms = textJVM.Text.Trim();

                        gb.instance.Remove(oldPath);
                        gb.allInstance.Remove(oldPath);

                        gb.currentInstance = im;
                        gb.allInstance.Add(newPath, im);
                        gb.instance.Add(newPath);

                        gb.savingSession(true);

                        if (!oldPath.Equals(newPath))
                        {
                            destPath = newPath;
                            Directory.Move(oldPath, newPath);
                        }
                        else
                        {
                            destPath = oldPath;
                        }

                        if (chkOpenSpecific.Checked && textBoxNowVersion.Text.Length > 0)
                        {
                            byte[] data = Encoding.ASCII.GetBytes(textBoxNowVersion.Text);
                            File.WriteAllBytes(gb.PathJoin(destPath, "version.bin"), data);
                        }
                        else if (File.Exists(gb.PathJoin(destPath, "version.bin")))
                        {
                            File.Delete(gb.PathJoin(destPath, "version.bin"));
                        }

                        this.DialogResult = DialogResult.OK;
                    }
                    else
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

                            if (chkOpenSpecific.Checked && textBoxNowVersion.Text.Length > 0)
                            {
                                byte[] data = Encoding.ASCII.GetBytes(textBoxNowVersion.Text);
                                File.WriteAllBytes(gb.PathJoin(path, "version.bin"), data);
                            }

                            InstanceModel im = new InstanceModel();
                            im.lastname = path;
                            im.javaPath = textJava.Text;
                            im.jvmParms = textJVM.Text.Trim();

                            gb.currentInstance = im;
                            gb.allInstance.Add(path, im);
                            gb.instance.Add(path);

                            gb.savingSession(true);

                            this.DialogResult = DialogResult.OK;
                        }
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

        private void btnJava_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "選擇一個新的 Java 路徑作為啟動依據。";
                fbd.SelectedPath = Environment.ExpandEnvironmentVariables("%ProgramW6432%");

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string tempPath = gb.PathJoin(fbd.SelectedPath, "java.exe");
                    if (File.Exists(tempPath))
                    {
                        textJava.Text = tempPath;
                    }
                    else
                    {
                        MessageBox.Show("您選擇的目錄中並未含有 Java 應用程式(java.exe)。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textJava.Text = "";
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    textJava.Text = "";
                }
            }
        }

        private void minecraftAddInstance_Load_1(object sender, EventArgs e)
        {
            if (currentInstance != null)
            {
                InstanceModel im = null;
                string[] dirArr = currentInstance.Split(Path.DirectorySeparatorChar);
                textInstanceName.Text = dirArr.Last();
                string tempPath = gb.PathJoin(DATA_FOLDER, ".x-instance", dirArr.Last());

                this.Text = $"編輯實例: {dirArr.Last()}";

                if (gb.allInstance.TryGetValue(tempPath, out im))
                {
                    textJava.Text = im.javaPath;
                    textJVM.Text = im.jvmParms;


                    if (File.Exists(gb.PathJoin(currentInstance, "version.bin")))
                    {
                        string data = File.ReadAllText(gb.PathJoin(currentInstance, "version.bin"));

                        foreach (var item in gb.versionListModels)
                        {
                            if (item.version.Equals(data))
                            {
                                textBoxNowVersion.Text = item.version;
                                chkOpenSpecific.Checked = true;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"無法編輯此實例，該名稱並未存在於啟動器設定檔中。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void btnVersionSelector_Click(object sender, EventArgs e)
        {
            minecraftVersionSelector form = new minecraftVersionSelector();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxNowVersion.Text = gb.lastVersionID;
            }

            form.Dispose();
        }
    }
}
