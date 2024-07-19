using Global;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static LiliumLauncher.ClassModel.globalModel;

namespace LiliumLauncher
{
    public partial class minecraftActionInstance : Form
    {
        string DATA_FOLDER;
        string currentInstance;
        private void setTranslate()
        {
            this.Text = gb.lang.FORM_TITLE_ADD_INSTANCE;
            this.Font = new System.Drawing.Font(gb.lang.FONT_FAMILY, gb.lang.FONT_SIZE_CHILD);
            label1.Text = gb.lang.LAB_INSTANCE_INTRO;
            label2.Text = gb.lang.LAB_JAVA_PATH_INTRO;
            btnIntro.Text = gb.lang.BTN_INTRO;
            btnOK.Text = gb.lang.BTN_OK;

            groupBox2.Text = gb.lang.GROUP_INSTANCE_NAME;
            groupBox1.Text = gb.lang.GROUP_LAUNCH_BY_SPECIFIC_VERSION;
            groupBox3.Text = gb.lang.GROUP_CUSTOM_JAVA_PATH;
            groupBox4.Text = gb.lang.GROUP_CUSTOM_JVM;

            chkOpenSpecific.Text = gb.lang.CHK_OPEN;
        }
        public minecraftActionInstance()
        {
            InitializeComponent();
            setTranslate();
        }

        public minecraftActionInstance(string mainFolder, string instance)
        {
            InitializeComponent();
            setTranslate();

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
            MessageBox.Show(gb.lang.DIALOG_INSTANCE_INTRO, gb.lang.DIALOG_INFO, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show(gb.lang.DIALOG_INSTANCE_EXIST, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show($"{gb.lang.DIALOG_CREATE_UNEXPECTED}{exx.Message}", gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textInstanceName.Text = "";
                }
            }
            else
            {
                MessageBox.Show(gb.lang.DIALOG_INSTANCE_NO_NAME, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void minecraftAddInstance_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnJava_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = gb.lang.DIALOG_JAVA_PATH_INTRO;
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
                        MessageBox.Show(gb.lang.DIALOG_NO_JAVA_EXIST, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                this.Text = gb.lang.FORM_TITLE_EDIT_INSTANCE.Replace("%INSTANCE_NAME%", dirArr.Last());

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
                    MessageBox.Show(gb.lang.DIALOG_CANT_EDIT_INSTANCE, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
