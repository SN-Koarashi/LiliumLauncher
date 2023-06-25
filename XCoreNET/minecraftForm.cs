using Global;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCoreNET.Tasks;
using static XCoreNET.ClassModel.globalModel;
using static XCoreNET.ClassModel.launcherModel;

namespace XCoreNET
{
    public partial class minecraftForm : Form
    {
        bool checkFile = false;
        bool isWebViewDisposed = false;
        bool directStart = false;
        bool isClosed = false;
        string APPDATA_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + ".minecraft-xcorenet";
        string MAIN_PATH = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + ".minecraft-xcorenet";
        string DATA_FOLDER;
        string INSTALLED_PATH;

        Dictionary<string, DownloadListModel> downloadList = new Dictionary<string, DownloadListModel>();
        Dictionary<string, LibrariesModel> nativesList = new Dictionary<string, LibrariesModel>();
        Dictionary<string, LibrariesModel> librariesList = new Dictionary<string, LibrariesModel>();
        authificationTask authification;
        launcherTask launcher;
        JObject customVer;
        JArray version_manifest_v2;
        NotifyIcon trayIcon;

        List<string> downloadingPath;
        List<ConcurrentDownloadListModel> indexObj;
        Dictionary<string, ConcurrentDownloadListModel> concurrentNowSize;

        int concurrentTotalSizeTick;
        int concurrentTotalSize;
        int concurrentTotalCompleted;
        int concurrentTotalCompletedDisplay;
        string concurrentType;

        int maxMemory;
        int tryReload = 0;

        private void minecraftForm_Load(object sender, EventArgs e)
        {
            if (isWebViewDisposed)
            {
                webView.Dispose();
            }
            else
            {
                webView.Source = gb.launcherHomepage;
            }

            progressBar.Maximum = 60;
            progressBar.Value = 0;

            if (directStart)
                onStarter();
            else
            {
                minecraftMainForm mmf = new minecraftMainForm();
                var resultDialog = mmf.ShowDialog();

                if (resultDialog == DialogResult.OK)
                {
                    onStarter();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private void onStarter()
        {
            this.WindowState = FormWindowState.Normal;
            this.Activate();

            if (gb.launchToken.Length > 0 && gb.getNowMilliseconds() - gb.launchTokenExpiresAt < 0)
            {
                progressBar.Value = 0;
                loginSuccess(gb.minecraftUsername, gb.minecraftUUID);
            }
            else if (gb.refreshToken.Length > 0)
                onRefreshToken(gb.refreshToken);
            else
            {
                onAzureToken(gb.azureToken);
                gb.azureToken = "";
            }

            ////////////////////////
        }

        private void setSpecificInstance()
        {
            // 不選擇啟動實例
            if (gb.currentInstance.lastname == null || gb.currentInstance.lastname.Length == 0)
            {
                btnVersionSelector.Enabled = true;
            }
            else
            {
                // 選擇啟動實例
                if (File.Exists(gb.PathJoin(gb.currentInstance.lastname, "version.bin")))
                {

                    byte[] data = File.ReadAllBytes(gb.PathJoin(gb.currentInstance.lastname, "version.bin"));
                    string dataString = Encoding.Default.GetString(data);

                    Console.WriteLine(gb.versionNameList.IndexOf(dataString));
                    if (gb.versionNameList.IndexOf(dataString) != -1)
                    {
                        textVersionSelected.Text = dataString;
                        btnVersionSelector.Enabled = false;
                    }
                    else
                    {
                        btnVersionSelector.Enabled = true;
                    }
                }
                else
                {
                    btnVersionSelector.Enabled = true;
                }
            }

            if (btnVersionSelector.Enabled)
                textVersionSelected.Text = gb.lastVersionID;
        }
        private void onGetAllInstance()
        {
            instanceList.Items.Clear();
            instanceList.Items.Add(gb.lang.CONTENT_NONE);

            gb.instance = Directory.GetDirectories(gb.PathJoin(DATA_FOLDER, ".x-instance")).ToList<string>();

            if (gb.instance.Count > 0)
            {
                foreach (var item in gb.instance)
                {
                    var dirArr = item.Split(Path.DirectorySeparatorChar);
                    instanceList.Items.Add(dirArr.Last());
                }
            }

            if (gb.currentInstance.lastname == null || gb.currentInstance.lastname.Length == 0 || !Directory.Exists(gb.currentInstance.lastname))
            {
                instanceList.SelectedIndex = 0;
                gb.currentInstance.lastname = "";
            }
            else
            {
                instanceList.SelectedItem = gb.currentInstance.lastname.Split(Path.DirectorySeparatorChar).Last();
            }
        }
        private async void onGetAllVersion()
        {
            btnVersionSelector.Enabled = false;
            Directory.CreateDirectory(gb.PathJoin(DATA_FOLDER, "versions"));
            var folderName = Directory.GetDirectories(gb.PathJoin(DATA_FOLDER, "versions"));

            gb.versionListModels.Clear();
            gb.versionNameInstalledList.Clear();
            gb.versionNameList.Clear();

            foreach (var nameFull in folderName)
            {
                var name = nameFull.Split('\\').Last();
                gb.versionNameInstalledList.Add(name);
            }

            if (version_manifest_v2 == null)
                version_manifest_v2 = (JArray)(await launcher.getAllVersion())["versions"];

            foreach (var v in version_manifest_v2)
            {
                if (v["type"].ToString().Equals("release") || v["type"].ToString().Equals("snapshot"))
                {
                    VersionListModel vlm = new VersionListModel();
                    vlm.version = v["id"].ToString();
                    vlm.type = v["type"].ToString();
                    vlm.url = v["url"].ToString();
                    vlm.datetime = DateTime.Parse(v["releaseTime"].ToString());
                    vlm.isInstalled = (gb.versionNameInstalledList.IndexOf(vlm.version) != -1) ? true : false;

                    gb.versionListModels.Add(vlm);
                    gb.versionNameList.Add(vlm.version);
                }
            }


            foreach (var name in gb.versionNameInstalledList)
            {
                if (gb.versionNameList.IndexOf(name) == -1)
                {
                    VersionListModel vlm = new VersionListModel();
                    vlm.version = name;
                    vlm.type = "loader";
                    vlm.datetime = File.GetCreationTime(gb.PathJoin(DATA_FOLDER, "versions", name, $"{name}.json"));
                    vlm.isInstalled = true;

                    gb.versionListModels.Add(vlm);
                    gb.versionNameList.Add(name);
                }
            }
            setSpecificInstance();
        }

        private void avatar_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            avatar.Cursor = Cursors.Default;
            avatar.Visible = true;
            updateTrayAvatar();


            if (e.Error != null && tryReload < 10)
            {
                Console.WriteLine(e.Error);
                avatar.Visible = false;
                avatar.LoadAsync(avatar.ImageLocation);
                tryReload++;
                outputDebug("WARN", $"Avatar Loading Failed: {e.Error.Message}");
            }
        }
        private void avatar_Click(object sender, EventArgs e)
        {
            avatar.Cursor = Cursors.WaitCursor;
            avatar.Visible = false;
            avatar.LoadAsync($"https://cravatar.eu/helmavatar/{gb.minecraftUUID}");
        }

        private void minecraftForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isClosed = true;

            if (directStart) webView.Dispose();
        }

        private void minecraftForm_Resize(object sender, EventArgs e)
        {
            if (!btnLaunch.Enabled && !checkFile && this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                trayIcon.Visible = true;
            }

            if (this.WindowState == FormWindowState.Normal)
            {
                textStatus.Width = this.Width - 140;
            }
        }


        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = DATA_FOLDER,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + gb.lang.DIALOG_REPLACE_DEFAULT_PATH, gb.lang.DIALOG_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                createGameDefFolder();
                Task.Delay(1000).Wait();
                btnOpenFolder_Click(sender, e);
            }
        }


        private delegate void DelSettingAllControl(bool isEnabled);
        private void settingAllControl(bool isEnabled)
        {
            btnVerifyFile.Enabled = isEnabled;
            btnChangeFolder.Enabled = isEnabled;
            btnLaunch.Enabled = isEnabled;
            textBoxAD.Enabled = isEnabled;
            textStatus.Enabled = isEnabled;
            textVersionSelected.Enabled = isEnabled;
            groupBoxDataFolder.Enabled = isEnabled;
            groupBoxMainProg.Enabled = isEnabled;
            groupBoxAccount.Enabled = isEnabled;
            groupBoxInterval.Enabled = isEnabled;
            groupBoxVersionReload.Enabled = isEnabled;
            groupBoxMemory.Enabled = isEnabled;
            groupBoxInstance.Enabled = isEnabled;
            panelVersion.Enabled = isEnabled;

            if (isEnabled)
            {
                progressBar.Value = 0;

                downloadList.Clear();
                nativesList.Clear();
                librariesList.Clear();
            }
        }
        private void settingAllControl(bool isEnabled, bool unlockOpenFolder)
        {
            settingAllControl(isEnabled);
            if (unlockOpenFolder)
            {
                groupBoxDataFolder.Enabled = !isEnabled;
            }
        }
        private void btnLaunch_Click(object sender, EventArgs e)
        {
            buttonVerReload_Click(sender, e);

            textBox.Text = "";

            checkFile = false;
            onVersionInfo();
        }

        private void btnVerifyFile_Click(object sender, EventArgs e)
        {
            buttonVerReload_Click(sender, e);

            textBox.Text = "";

            checkFile = true;
            onVersionInfo();
            tabControl1.SelectedIndex = 0;
        }

        /*
        private void textBoxInterval_KeyUp(object sender, KeyEventArgs e)
        {
            int result;
            if (int.TryParse(textBoxInterval.Text, out result))
            {
                if (result < 0)
                {
                    MessageBox.Show("數字必須大於等於零", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxInterval.Text = "0";
                    gb.runInterval = 0;
                }
                else
                {
                    textBoxInterval.Text = result.ToString();
                    gb.runInterval = result;
                }
                gb.savingSession(false);
            }
            else
            {
                MessageBox.Show("您只能輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxInterval.Text = "0";
                gb.runInterval = 0;
                gb.savingSession(false);
            }
        }
        */

        private void textVersionSelected_Click(object sender, EventArgs e)
        {
            textVersionSelected.SelectAll();
        }

        private void btnMainSetting_Click(object sender, EventArgs e)
        {
            settingForm sf = new settingForm();
            sf.ShowDialog();
        }

        private void btnChkUpdate_Click(object sender, EventArgs e)
        {
            gb.checkForUpdate(true);
        }

        private async void btnSwitchAcc_Click(object sender, EventArgs e)
        {
            settingAllControl(false);
            Process proc = null;
            loginMicrosoftForm lmf = new loginMicrosoftForm();
            var resultDialog = lmf.ShowDialog();
            if (resultDialog != DialogResult.Cancel)
            {
                if (resultDialog == DialogResult.Ignore)
                {
                    BrowserInfoModel bim = Tasks.loginChallengeTask.DeterminePath();
                    if (Tasks.loginChallengeTask.SupportBrowser(bim))
                    {
                        try
                        {
                            string profilePath = Path.GetFullPath(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/browser_profile/" + bim.name);
                            string profileArgs = $"--user-data-dir=\"{profilePath}\"";

                            Console.WriteLine(bim.path);
                            Console.WriteLine($"Profile: {profilePath}");
                            proc = new Process();
                            proc.StartInfo = Tasks.loginChallengeTask.BrowserStartInfo(bim, profileArgs);
                            proc.EnableRaisingEvents = true;
                            proc.Start();

                            proc.Exited += (bSender, ve) =>
                            {
                                Tasks.loginChallengeTask.BrowserClosed(profilePath);
                                this.Invoke(new Action(() =>
                                {
                                    if(!progressBar.Style.Equals(ProgressBarStyle.Marquee))
                                        settingAllControl(true);
                                }));
                            };
                        }
                        catch (Exception exx)
                        {
                            Console.WriteLine(exx);
                            outputDebug("ERROR", exx.StackTrace);
                            MessageBox.Show(exx.Message, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            settingAllControl(true);
                            return;
                        }
                    }
                    else
                    {
                        Process.Start(gb.getMicrosoftOAuthURL());
                    }
                }

                Tasks.loginChallengeTask challenge = new Tasks.loginChallengeTask(true);
                var result = await challenge.start();
                // 讓視窗置頂，而不是聚焦在瀏覽器或其他地方
                this.TopMost = true;
                if (result == DialogResult.OK)
                {
                    progressBar.Maximum = 60;
                    progressBar.Value = 0;
                    onAzureToken(gb.azureToken);
                    gb.azureToken = "";
                    gb.savingSession(false);

                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    settingAllControl(true);
                }

                if (proc != null && !proc.HasExited)
                    proc.Kill();

                // 取消置頂，才不會擋到其他視窗
                this.TopMost = false;
            }
            else
            {
                settingAllControl(true);
            }

            lmf.Dispose();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            settingAllControl(false);
            var result = MessageBox.Show(gb.lang.DIALOG_LOGOUT, gb.lang.DIALOG_INFO, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                gb.resetTokens();
                gb.savingSession(true);

                FormCollection fc = Application.OpenForms;

                if (fc != null && fc.Count > 0 && fc[0].Name == this.Name)
                {
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }
                else
                {
                    this.Close();
                }
            }
            else
                settingAllControl(true);
        }

        private void buttonVerReload_Click(object sender, EventArgs e)
        {
            onGetAllVersion();
            onGetAllInstance();
        }

        private void trackBarMiB_Scroll(object sender, EventArgs e)
        {
            double multiplier = (trackBarMiB.Value == 0) ? 0.5 : trackBarMiB.Value;
            textBoxMiB.Text = (multiplier * 1024).ToString();
            gb.maxMemoryUsage = int.Parse(textBoxMiB.Text);
        }

        private void textBoxMiB_KeyUp(object sender, KeyEventArgs e)
        {
            double memoryMiB;

            if (double.TryParse(textBoxMiB.Text, out memoryMiB))
            {
                if (memoryMiB > maxMemory)
                {
                    trackBarMiB.Value = trackBarMiB.Maximum;
                }
                else if (memoryMiB < 512)
                {
                    trackBarMiB.Value = trackBarMiB.Minimum;
                }
                else
                {
                    int memoryGiB = Convert.ToInt32(memoryMiB / 1024);
                    trackBarMiB.Value = (memoryGiB > trackBarMiB.Maximum) ? trackBarMiB.Maximum : memoryGiB;
                }

                gb.maxMemoryUsage = int.Parse(textBoxMiB.Text);
            }
            else
            {
                textBoxMiB.Text = "";
                gb.maxMemoryUsage = 0;
            }
        }

        private void textBoxMiB_Leave(object sender, EventArgs e)
        {
            double memoryMiB;

            if (double.TryParse(textBoxMiB.Text, out memoryMiB))
            {
                if (memoryMiB > maxMemory)
                {
                    textBoxMiB.Text = maxMemory.ToString();
                }
                else if (memoryMiB < 512)
                {
                    textBoxMiB.Text = "512";
                }
                gb.maxMemoryUsage = int.Parse(textBoxMiB.Text);
            }
            else
            {
                textBoxMiB.Text = "";
                gb.maxMemoryUsage = 0;
            }
            gb.savingSession(false);
        }

        private void checkBoxMaxMem_CheckedChanged(object sender, EventArgs e)
        {
            trackBarMiB.Enabled = checkBoxMaxMem.Checked;
            textBoxMiB.Enabled = checkBoxMaxMem.Checked;
            gb.usingMaxMemoryUsage = checkBoxMaxMem.Checked;
        }

        private void trackBarMiB_MouseUp(object sender, MouseEventArgs e)
        {
            gb.savingSession(false);
        }

        private async void btnVerRecache_Click(object sender, EventArgs e)
        {
            settingAllControl(false);
            version_manifest_v2 = (JArray)(await launcher.getAllVersion())["versions"];
            onGetAllVersion();
            onGetAllInstance();
            settingAllControl(true);
        }

        private string SizeFormatter(int totBytes, int nowBytes)
        {
            var KiB = totBytes / 1024;

            if (totBytes < 1024)
            {
                return $"{nowBytes} / {totBytes} Bytes";
            }
            else if (KiB < 1024 && totBytes > 1024)
            {
                var totalFormat = Math.Round((double)totBytes / 1024, 3);
                var nowFormat = Math.Round((double)nowBytes / 1024, 3);
                return $"{nowFormat} / {totalFormat} KiB";
            }
            else
            {
                var totalFormat = Math.Round((double)totBytes / 1024 / 1024, 3);
                var nowFormat = Math.Round((double)nowBytes / 1024 / 1024, 3);
                return $"{nowFormat} / {totalFormat} MiB";
            }
        }

        private void timerConcurrent_Tick(object sender, EventArgs e)
        {
            if (concurrentTotalSizeTick != CountDownloadProgress())
            {
                Console.WriteLine("timer ticked");
                UpdateDownloadState();
                concurrentTotalSizeTick = CountDownloadProgress();
            }
        }

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = gb.lang.DIALOG_CHOOSE_NEW_MINECRAFT_PATH;
                fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (fbd.SelectedPath.EndsWith(gb.mainFolderName))
                        gb.mainFolder = Path.GetFullPath(fbd.SelectedPath);
                    else
                        gb.mainFolder = Path.GetFullPath(fbd.SelectedPath + Path.DirectorySeparatorChar + gb.mainFolderName);

                    DATA_FOLDER = gb.mainFolder;
                    textBoxAD.Text = DATA_FOLDER;

                    Directory.CreateDirectory(DATA_FOLDER);
                    Directory.CreateDirectory(gb.PathJoin(DATA_FOLDER, ".x-instance"));
                    gb.savingSession(true);


                    onGetAllVersion();
                    onGetAllInstance();

                    instanceList.SelectedIndex = 0;
                    gb.currentInstance.lastname = "";
                }
            }
        }

        private void btnInstanceAdd_Click(object sender, EventArgs e)
        {
            minecraftActionInstance ai = new minecraftActionInstance(DATA_FOLDER, null);
            var result = ai.ShowDialog();
            if (result == DialogResult.OK)
            {
                onGetAllInstance();
            }

            ai.Dispose();
        }
        private void btnInstanceEdit_Click(object sender, EventArgs e)
        {
            minecraftActionInstance ai = new minecraftActionInstance(DATA_FOLDER, gb.currentInstance.lastname);
            var result = ai.ShowDialog();
            if (result == DialogResult.OK)
            {
                onGetAllInstance();
            }

            ai.Dispose();
        }

        private void btnInstanceDel_Click(object sender, EventArgs e)
        {
            if (instanceList.SelectedIndex == 0)
            {
                MessageBox.Show(gb.lang.DIALOG_CANT_DELETE_INSTANCE, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(gb.lang.DIALOG_DELETE_INSTANCE_CONFIRM.Replace("%INSTANCE_NAME%", instanceList.SelectedItem.ToString()), gb.lang.DIALOG_ERROR, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var name = instanceList.SelectedItem.ToString();
                var idx = instanceList.SelectedIndex;

                instanceList.Items.Remove(name);
                instanceList.SelectedIndex = (instanceList.Items.Count - 1 > idx - 1) ? instanceList.Items.Count - 1 : idx - 1;

                string tempPath = gb.PathJoin(DATA_FOLDER, ".x-instance", name);

                if (gb.allInstance.ContainsKey(tempPath))
                {
                    gb.allInstance.Remove(tempPath);
                }

                Directory.Delete(gb.PathJoin(DATA_FOLDER, ".x-instance", name), true);
            }
        }

        private void instanceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (instanceList.SelectedIndex <= 0)
            {
                gb.currentInstance = new InstanceModel();
                btnInstanceEdit.Enabled = false;
                btnInstanceDel.Enabled = false;
            }
            else
            {
                btnInstanceEdit.Enabled = true;
                btnInstanceDel.Enabled = true;

                InstanceModel cIns = null;
                string tempPath = gb.PathJoin(DATA_FOLDER, ".x-instance", instanceList.SelectedItem.ToString());

                if (gb.allInstance.TryGetValue(tempPath, out cIns))
                {
                    gb.currentInstance = cIns;
                }
                else
                {
                    MessageBox.Show(gb.lang.DIALOG_CANT_FIND_INSTANCE.Replace("%PATH%", tempPath), gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    instanceList.SelectedIndex = 0;
                    textBoxInstance.Text = instanceList.SelectedItem.ToString();
                    onGetAllInstance();
                    return;
                }
            }

            textBoxInstance.Text = instanceList.SelectedItem.ToString();
            instanceList.DropDownWidth = (gb.DropDownWidth(instanceList) + 25 > 300) ? 300 : gb.DropDownWidth(instanceList) + 25;

            setSpecificInstance();
            gb.savingSession(false);
        }

        private void textBoxInstance_Click(object sender, EventArgs e)
        {
            textBoxInstance.SelectAll();
        }

        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3)
            {
                if (textBoxUpdateNote.Lines.Length > 0) return;

                try
                {
                    textBoxUpdateNote.Text = gb.lang.LAB_LOADING;

                    // https://api.rss2json.com/v1/api.json?rss_url=https://github.com/SN-Koarashi/XCoreNET/releases.atom
                    JObject obj = await launcher.getUpdateNotes("https://api.rss2json.com/v1/api.json?rss_url=https://github.com/SN-Koarashi/XCoreNET/releases.atom");

                    textBoxUpdateNote.Text = "";
                    foreach (JObject item in obj["items"])
                    {
                        string title = item["title"].ToString();
                        string date = item["pubDate"].ToString();
                        string content = item["content"].ToString();
                        DateTime dateTime = DateTime.Parse(date).ToLocalTime();

                        content = content.Replace("\n", "");
                        content = content.Replace("<br>", Environment.NewLine + " ");
                        content = Regex.Replace(content, @"<p>v(.*?)</p>", "");
                        content = Regex.Replace(content, @"<(.*?)>", "");
                        content = Regex.Replace(content, @"</(.*?)>", "");

                        string data = $" [{title}] {dateTime.ToString(gb.lang.LAB_CHANGELOG_DATE_FORMAT)} ({TimeZone.CurrentTimeZone.StandardName}){Environment.NewLine} {content}{Environment.NewLine}{Environment.NewLine}";
                        textBoxUpdateNote.AppendText(data);
                    }
                }
                catch (Exception exx)
                {
                    Console.WriteLine(exx.Message);
                    textBoxUpdateNote.Text = $"{gb.lang.LAB_CHANGELOG_RSS_ERROR} {exx.Message}";
                }
            }
        }

        private void btnMultiAcc_Click(object sender, EventArgs e)
        {
            minecraftMultuAccount ma = new minecraftMultuAccount();

            var result = ma.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (gb.launchToken != null && gb.launchToken.Length > 0 && gb.getNowMilliseconds() - gb.launchTokenExpiresAt < 0)
                {
                    loginSuccess(gb.minecraftUsername, gb.minecraftUUID);
                }
                else
                {
                    onRefreshToken(gb.refreshToken);
                }
                tabControl1.SelectedIndex = 0;
            }
            else if (result == DialogResult.Abort)
            {
                onRefreshToken(gb.refreshToken);
                tabControl1.SelectedIndex = 0;
            }

            ma.Dispose();
        }

        private void btnVersionSelector_Click(object sender, EventArgs e)
        {
            minecraftVersionSelector form = new minecraftVersionSelector();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                textVersionSelected.Text = gb.lastVersionID;
            }

            form.Dispose();
        }

        private void radConcurrent_Click(object sender, EventArgs e)
        {
            gb.isConcurrent = radConcurrent.Checked;
            gb.savingSession(false);
        }

        private void radSingle_Click(object sender, EventArgs e)
        {
            gb.isConcurrent = radConcurrent.Checked;
            gb.savingSession(false);
        }
    }
}
