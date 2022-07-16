using Global;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCoreNET.Tasks;
using static XCoreNET.Tasks.launcherTask;

namespace XCoreNET
{
    public partial class minecraftForm : Form
    {
        bool checkFile = false;
        bool isWebViewDisposed = false;
        bool firstStartForm = false;
        bool directStart = false;
        bool isClosed = false;
        string APPDATA_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + ".minecraft-xcorenet";
        string MAIN_PATH = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + ".minecraft-xcorenet";
        string DATA_FOLDER;
        string INSTALLED_PATH;

        Dictionary<string, string> releaseList = new Dictionary<string, string>();
        Dictionary<string, DateTime> releaseListDateTime = new Dictionary<string, DateTime>();

        Dictionary<string, DownloadListModel> downloadList = new Dictionary<string, DownloadListModel>();
        Dictionary<string, LibrariesModel> nativesList = new Dictionary<string, LibrariesModel>();
        Dictionary<string, LibrariesModel> librariesList = new Dictionary<string, LibrariesModel>();
        authificationTask authification;
        launcherTask launcher;
        JObject customVer;
        JArray version_manifest_v2;

        private class DownloadListModel
        {
            public string path { get; set; }
            public string sha1 { get; set; }
            public string className { get; set; }
            public int type { get; set; }
            public string name { get; set; }

        }
        private class LibrariesModel
        {
            public string dir { get; set; }
            public string version { get; set; }
        }

        public minecraftForm()
        {
            directStart = true;
            initializeMain();
        }
        public minecraftForm(string[] args)
        {
            gb.readingSession();

            if (gb.azureToken.Length > 0 || gb.refreshToken.Length > 0)
            {
                directStart = true;
                initializeMain();
            }
            else
            {
                initializeMain(args);
            }

            foreach (var arg in args)
            {
                if (arg.ToLower().Equals("-nowebview"))
                {
                    isWebViewDisposed = true;
                }
            }
        }

        private void initializeMain()
        {
            InitializeComponent();

            this.SetStyle(
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);

            authification = new authificationTask();
            launcher = new launcherTask();

            textBoxAD.Text = APPDATA_PATH;
            textBoxMain.Text = MAIN_PATH;
            textBoxInterval.Text = gb.runInterval.ToString();
            toolTip.SetToolTip(textBoxAD, APPDATA_PATH);
            toolTip.SetToolTip(textBoxMain, MAIN_PATH);


            if (gb.isMainFolder == true)
                radBtnMain.Checked = true;
            else
                radBtnAD.Checked = true;

            chkBoxRelease.Checked = gb.verOptRelease;
            chkBoxSnapshot.Checked = gb.verOptSnapshot;

            firstStartForm = true;
            this.Width = gb.windowSize.X;
            this.Height = gb.windowSize.Y;
        }

        private void initializeMain(string[] args)
        {
            initializeMain();
        }

        private void setDataFolder()
        {
            if (gb.isMainFolder == true)
                DATA_FOLDER = MAIN_PATH;
            else
                DATA_FOLDER = APPDATA_PATH;

            Directory.CreateDirectory(DATA_FOLDER);
        }

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

            setDataFolder();

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

        // 宣告方法委派(用以將 onStarter 轉交由主執行緒執行)
        private delegate void DelStarter();

        private void onStarter()
        {
            this.Activate();
            if (!gb.firstStart) gb.checkForUpdate();

            if (gb.launchToken.Length > 0 && gb.getNowMilliseconds() - gb.launchTokenExpiresAt < 0)
            {
                progressBar.Value = 60;
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

            onGetAllVersion();
        }


        private async void onGetAllVersion()
        {
            bool hasTakeManifesst = false;

            textVersionSelected.Text = "";
            releaseList.Clear();
            versionList.Items.Clear();

            if (version_manifest_v2 == null)
                version_manifest_v2 = (JArray)(await launcher.getAllVersion())["versions"];

            foreach (var v in version_manifest_v2)
            {
                if (v["type"].ToString().Equals("release") && gb.verOptRelease)
                {
                    releaseList.Add(v["id"].ToString(), v["url"].ToString());
                    hasTakeManifesst = true;
                }
                if (v["type"].ToString().Equals("snapshot") && gb.verOptSnapshot)
                {
                    releaseList.Add(v["id"].ToString(), v["url"].ToString());
                    hasTakeManifesst = true;
                }

                if (!releaseListDateTime.ContainsKey(v["id"].ToString()))
                    releaseListDateTime.Add(v["id"].ToString(), DateTime.Parse(v["releaseTime"].ToString()));
            }

            foreach (var r in releaseList)
            {
                versionList.Items.Add(r.Key);

                //if (r.Key.Equals("1.7.2")) break;
                //if (r.Key.Equals("1.7")) break;
            }

            Directory.CreateDirectory(PathJoin(DATA_FOLDER, "versions"));

            var folderName = Directory.GetDirectories(PathJoin(DATA_FOLDER, "versions"));
            var installedName = new List<string>();
            foreach (var nameFull in folderName)
            {
                var name = nameFull.Split('\\').Last();
                installedName.Add(name);
            }

            foreach (var nowName in installedName)
            {
                foreach (var v in version_manifest_v2)
                {
                    if (v["id"].ToString().Equals(nowName) && !releaseList.ContainsKey(nowName))
                        releaseList.Add(nowName, v["url"].ToString());
                }

                if (!versionList.Items.Contains(nowName))
                {
                    versionList.Items.Add(nowName);
                }
            }

            // 沒有提取任何發布版本的話，對已安裝在本機的版本列表進行排序
            if (!hasTakeManifesst)
            {
                var items = versionList.Items;
                var customVersion = new List<string>();
                var vanillaVersion = new List<string>();

                foreach (var item in items)
                {
                    if (releaseList.ContainsKey(item.ToString()))
                        vanillaVersion.Add(item.ToString());
                    else
                        customVersion.Add(item.ToString());
                }


                vanillaVersion.Sort((x, y) => -DateTime.Compare(releaseListDateTime[x], releaseListDateTime[y]));
                customVersion.Sort();

                versionList.Items.Clear();
                versionList.Items.AddRange(vanillaVersion.ToArray());
                versionList.Items.AddRange(customVersion.ToArray());
            }

            versionList.DropDownWidth = (DropDownWidth(versionList) + 25 > 300) ? 300 : DropDownWidth(versionList) + 25;

            foreach (var item in versionList.Items)
            {
                if (item.ToString().Equals(gb.lastVersionID))
                    versionList.SelectedItem = item;
            }

            if (versionList.Items.Count > 0 && versionList.SelectedItem != null)
                textVersionSelected.Text = versionList.SelectedItem.ToString();
            else if (versionList.SelectedItem == null && versionList.Items.Count > 0)
            {
                textVersionSelected.Text = versionList.Items[0].ToString();
                versionList.SelectedIndex = 0;
            }

            groupBoxVersion.Enabled = true;
        }

        private int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0, temp = 0;
            foreach (var obj in myCombo.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), myCombo.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            return maxWidth;
        }

        private async void onAzureToken(string azureToken)
        {
            if (isClosed) return;
            settingAllControl(false);
            progressBar.Style = ProgressBarStyle.Marquee;

            output("INFO", $"正在取得 Azure 驗證");
            var bearer = await authification.Code2Token(azureToken);
            if (!bearer.ContainsKey("error"))
            {
                output("INFO", "Azure 驗證完成");


                gb.refreshToken = bearer["refresh_token"].ToString();

                onXBLToken(bearer["access_token"].ToString());
                progressBar.Value += 10;
            }
            else
            {
                MessageBox.Show(bearer["error_description"].ToString(), "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void onRefreshToken(string refresh_token)
        {
            if (isClosed) return;
            settingAllControl(false);
            progressBar.Style = ProgressBarStyle.Marquee;

            output("INFO", "正在取得刷新權杖");
            var result = await authification.refreshToken(gb.refreshToken);
            output("INFO", "已取得取得刷新權杖");
            progressBar.Value += 10;

            if (result.ContainsKey("error"))
            {
                MessageBox.Show(result["error_description"].ToString(), "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                var access_token = result["access_token"].ToString();
                gb.refreshToken = result["refresh_token"].ToString();

                onXBLToken(access_token);
            }
        }

        private async void onXBLToken(string access_token)
        {
            if (isClosed) return;
            output("INFO", "正在取得 XBL 權杖");
            var token = await authification.getXBLToken(access_token);
            output("INFO", "已取得 XBL 權杖");
            progressBar.Value += 10;

            var Token = token["Token"].ToString();
            onXSTSToken(Token);
        }
        private async void onXSTSToken(string XBLToken)
        {
            if (isClosed) return;
            output("INFO", "正在取得 XSTS 權杖");
            var token = await authification.getXSTSToken(XBLToken);
            output("INFO", "已取得 XSTS 權杖");
            progressBar.Value += 10;

            if (token.ContainsKey("XErr"))
            {
                string type = token["XErr"].ToString();

                switch (type)
                {
                    case "2148916233":
                        MessageBox.Show("此帳號沒有 Xbox 帳號", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "2148916235":
                        MessageBox.Show("此帳號來自 Xbox Live 無法使用或是被禁止的國家/地區", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "2148916238":
                        MessageBox.Show("此帳號設定的年齡為兒童（18 歲以下），除非該帳戶由成人添加到家庭，否則無法繼續操作", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                this.Close();
            }
            else
            {
                var DisplayClaims = token["DisplayClaims"].ToString();
                var XM = JsonConvert.DeserializeObject<authificationTask.XUIModel>(DisplayClaims);

                var UserHash = XM.xui[0]["uhs"].ToString();
                var XSTSToken = token["Token"].ToString();
                onMinecraftAuth(XSTSToken, UserHash);
            }
        }

        private async void onMinecraftAuth(string XSTSToken, string UserHash)
        {
            if (isClosed) return;

            output("INFO", "正在取得 Minecraft 認證權杖");
            var token = await authification.getMinecraftAuth(XSTSToken, UserHash);
            output("INFO", "已取得 Minecraft 認證權杖");
            progressBar.Value += 10;

            var access_token = token["access_token"].ToString();
            var token_type = token["token_type"].ToString();
            int expires_in = int.Parse(token["expires_in"].ToString());

            gb.launchToken = access_token;
            gb.launchTokenExpiresAt = gb.getNowMilliseconds() + expires_in * 1000;

            onCheckGameOwnership(access_token, token_type);
        }

        private async void onCheckGameOwnership(string accessToken, string type)
        {
            if (isClosed) return;

            output("INFO", "正在確認遊戲所有權");
            var auth = await authification.checkGameOwnership(accessToken, type);
            output("INFO", "這個帳戶已擁有 Minecraft");
            progressBar.Value += 10;

            if (auth["items"].ToString().Length < 10)
            {
                MessageBox.Show("此帳號沒有購買 Minecraft", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                onMinecraftProfile(accessToken, type);
            }
        }
        private async void onMinecraftProfile(string accessToken, string type)
        {
            if (isClosed) return;

            output("INFO", "正在取得 Minecraft 個人資料");
            var result = await authification.getMinecraftProfile(accessToken, type);
            output("INFO", "已成功取得 Minecraft 個人資料");
            progressBar.Value += 10;

            if (result.ContainsKey("errorType"))
            {
                MessageBox.Show("此帳號沒有購買 Minecraft", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                string uuid = result["id"].ToString();
                string username = result["name"].ToString();
                gb.minecraftUsername = username;
                gb.minecraftUUID = uuid;

                loginSuccess(username, uuid);
            }
        }

        private void loginSuccess(string username, string uuid)
        {
            progressBar.Style = ProgressBarStyle.Blocks;
            output("INFO", $"登入使用者 -{username} -{uuid}");

            textUser.Text = username;

            avatar.WaitOnLoad = false;
            avatar.LoadAsync($"https://cravatar.eu/helmavatar/{uuid}/32.png");

            textUser.Visible = true;

            gb.startupParms.username = username;
            gb.startupParms.uuid = uuid;
            gb.startupParms.accessToken = gb.launchToken;
            gb.savingSession();

            settingAllControl(true);
        }

        int tryReload = 0;
        private void avatar_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            avatar.Visible = true;

            if (e.Error != null && tryReload < 10)
            {
                Console.WriteLine(e.Error);
                avatar.Visible = false;
                avatar.LoadAsync(avatar.ImageLocation);
                tryReload++;
                outputDebug("WARN", $"使用者頭像載入失敗: {e.Error.Message}");
            }
        }
        private void avatar_Click(object sender, EventArgs e)
        {
            avatar.Visible = false;
            avatar.LoadAsync($"https://cravatar.eu/helmavatar/{gb.minecraftUUID}/32.png");
        }

        private void output(string type, string sOutput)
        {
            if (this.IsDisposed) return;

            textStatus.Text = sOutput;
            Application.DoEvents();

            outputDebug(type, sOutput);
        }
        private void outputDebug(string type, string output)
        {
            if (this.IsDisposed) return;

            DateTime dateTime = System.DateTime.Now;

            string time = $"{dateTime.Hour.ToString("00")}:{dateTime.Minute.ToString("00")}:{dateTime.Second.ToString("00")}.{dateTime.Millisecond.ToString("000")} ";
            textBox.AppendText($"{time} [{type}] {output}" + Environment.NewLine);

            Console.WriteLine(output);
        }

        private void minecraftForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isClosed = true;

            if (directStart) webView.Dispose();
        }

        private void minecraftForm_Resize(object sender, EventArgs e)
        {
            windowResize();
        }

        private void windowResize()
        {
            textStatus.Width = panelFooter.Width - 110;
            groupBoxDataFolder.Width = panelSettingsTop.Width - 16;
            panelSettingsInsideLeft.Width = panelSettingsLeft.Width / 2;
            panelSettingsInsideRight.Width = panelSettingsLeft.Width / 2;
            textBoxAD.Width = panelSettingsInsideLeft.Width - 36;
            textBoxMain.Width = panelSettingsInsideRight.Width - 36;

            gb.windowSize = new System.Drawing.Point(this.Width, this.Height);
        }

        private void radioChanged(string clicked)
        {
            if (!firstStartForm) return;

            if (clicked.Equals("change") && radBtnAD.Checked != radBtnMain.Checked)
            {
                gb.isMainFolder = radBtnMain.Checked;

                gb.savingSession();
                setDataFolder();
                onGetAllVersion();
            }
            else
            {

                if (clicked.Equals("appdata"))
                {
                    radBtnAD.Checked = true;
                    radBtnMain.Checked = false;
                }
                else if (clicked.Equals("main"))
                {
                    radBtnAD.Checked = false;
                    radBtnMain.Checked = true;
                }
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = DATA_FOLDER,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        private void radBtnMain_Click(object sender, EventArgs e)
        {
            radioChanged("main");
        }

        private void radBtnAD_Click(object sender, EventArgs e)
        {
            radioChanged("appdata");
        }

        private void radBtnAD_CheckedChanged(object sender, EventArgs e)
        {
            radioChanged("change");
        }

        private void radBtnMain_CheckedChanged(object sender, EventArgs e)
        {
            radioChanged("change");
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            windowResize();
        }

        private delegate void DelSettingAllControl(bool isEnabled);
        private void settingAllControl(bool isEnabled)
        {
            btnLaunch.Enabled = isEnabled;
            versionList.Enabled = isEnabled;
            textStatus.Enabled = isEnabled;
            textVersionSelected.Enabled = isEnabled;
            groupBoxMainProg.Enabled = isEnabled;
            groupBoxAccount.Enabled = isEnabled;
            groupBoxVersion.Enabled = isEnabled;
            groupBoxDataFolder.Enabled = isEnabled;
            groupBoxInterval.Enabled = isEnabled;
            groupBoxVersionReload.Enabled = isEnabled;

            if (isEnabled)
            {
                progressBar.Value = 0;

                downloadList.Clear();
                nativesList.Clear();
                librariesList.Clear();
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            checkFile = false;
            onVersionInfo();
        }

        private void btnVerifyFile_Click(object sender, EventArgs e)
        {
            checkFile = true;
            onVersionInfo();
        }

        private void onVersionInfo()
        {
            customVer = null;
            settingAllControl(false);
            progressBar.Value = 0;

            if (versionList.Items.Count == 0)
            {
                MessageBox.Show("未找到有效的版本可供啟動", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                settingAllControl(true);
                return;
            }

            gb.resetStartupParms();

            gb.lastVersionID = versionList.SelectedItem.ToString();

            string selectVersion = versionList.Items[versionList.SelectedIndex].ToString();
            string verURL;

            gb.savingSession();

            if (releaseList.TryGetValue(selectVersion, out verURL))
            {
                onCreateIndexes(selectVersion, verURL);
            }
            else
            {
                var dir = PathJoin(DATA_FOLDER, "versions", selectVersion, $"{selectVersion}.json");
                var data = File.ReadAllText(dir);
                JObject obj = JsonConvert.DeserializeObject<JObject>(data);


                if (releaseList.TryGetValue(obj["inheritsFrom"].ToString(), out verURL))
                {

                }
                else
                {
                    verURL = releaseList[obj["jar"].ToString()];
                }

                customVer = obj;
                onCreateIndexes(selectVersion, verURL);
            }
        }

        private async void onCreateIndexes(string version, string url)
        {
            output("INFO", "建立索引資料");
            var obj = await launcher.createIndexes(url);

            string indexUrl = obj["assetIndex"]["url"].ToString();
            string id = obj["assetIndex"]["id"].ToString();
            string client_url = obj["downloads"]["client"]["url"].ToString();

            gb.startupParms.assetIndex = id;
            if (customVer != null)
                gb.startupParms.main = customVer["mainClass"].ToString();
            else
                gb.startupParms.main = obj["mainClass"].ToString();

            var body = await new HttpClient().GetStringAsync(indexUrl);
            var dir = PathJoin(DATA_FOLDER, "assets/indexes");

            Directory.CreateDirectory(dir);
            Console.WriteLine(PathJoin(dir, $"{id}.json"));
            File.WriteAllText(PathJoin(dir, $"{id}.json"), body);

            onCreateGameData(version, obj["downloads"]["client"]["sha1"].ToString(), obj, client_url, body);
        }

        private async void onCreateGameData(string version, string hash, JObject gameNecessaryKit, string clientURL, string gameAssetJson)
        {
            output("INFO", "建立遊戲主程式");

            if (customVer == null)
            {
                var dir = PathJoin(DATA_FOLDER, "versions", version);
                var dir_json = PathJoin(dir, $"{version}.json");
                var dir_jar = PathJoin(dir, $"{version}.jar");

                Directory.CreateDirectory(dir);

                var sha_local = (File.Exists(dir_jar)) ? gb.SHA1(File.ReadAllBytes(dir_jar)) : "";

                if (!File.Exists(dir_json))
                    File.WriteAllText(dir_json, JsonConvert.SerializeObject(gameNecessaryKit));

                if (!File.Exists(dir_jar) || sha_local != hash)
                {
                    if (sha_local.Length > 0 && sha_local != hash) output("WARN", "遊戲主程式雜湊值驗證失敗");

                    output("INFO", "正在下載遊戲主程式");
                    await launcher.downloadResource(clientURL, dir_jar);
                }


                if ((gameNecessaryKit["minecraftArguments"] != null))
                {
                    gb.startupParms.minecraftArguments = gameNecessaryKit["minecraftArguments"].ToString();
                }
                else
                {
                    JArray tempArr = JsonConvert.DeserializeObject<JArray>(gameNecessaryKit["arguments"]["game"].ToString());
                    JArray finalArr = new JArray();
                    foreach (var arr in tempArr)
                    {
                        //if (arr.ToString().StartsWith("--") || arr.ToString().StartsWith("${") && arr.ToString().EndsWith("}"))
                        if (arr.Type == JTokenType.String)
                            finalArr.Add(arr);
                    }
                    gb.startupParms.minecraftArguments = String.Join(" ", finalArr);
                }
            }
            else
            {
                if ((customVer["minecraftArguments"] != null))
                {
                    gb.startupParms.minecraftArguments = customVer["minecraftArguments"].ToString();
                }
                else
                {
                    JArray tempArr = JsonConvert.DeserializeObject<JArray>(customVer["arguments"]["game"].ToString());
                    JArray tempVanillaArr = JsonConvert.DeserializeObject<JArray>(gameNecessaryKit["arguments"]["game"].ToString());
                    JArray finalArr = new JArray();
                    foreach (var arr in tempVanillaArr)
                    {
                        if (arr.Type == JTokenType.String)
                            finalArr.Add(arr);
                    }

                    foreach (var arr in tempArr)
                    {
                        var repeatList = finalArr.Where(x => x.ToString().Equals(arr.ToString())).ToList();
                        if (arr.Type == JTokenType.String && repeatList.Count == 0)
                            finalArr.Add(arr);
                    }
                    gb.startupParms.minecraftArguments = String.Join(" ", finalArr);
                }
            }

            output("INFO", "遊戲主程式建立完成");

            gb.startupParms.version = version;


            INSTALLED_PATH = PathJoin(DATA_FOLDER, "versions", version, "installed.");


            if (gameNecessaryKit["logging"] != null)
                onCreateLogger(gameNecessaryKit["logging"]["client"]["file"]["url"].ToString(), gameNecessaryKit["logging"]["client"]["file"]["id"].ToString());

            onJavaProgram(gameNecessaryKit, gameAssetJson);
        }

        private async void onCreateLogger(string url, string filename)
        {
            output("INFO", "建立記錄器規則");
            var dir = PathJoin(DATA_FOLDER, "assets/log-configs");
            Directory.CreateDirectory(dir);

            await launcher.downloadResource(url, PathJoin(dir, filename));

            gb.startupParms.loggerIndex = filename;
        }

        private async void onJavaProgram(JObject objKit, string gameAssetJson)
        {
            output("INFO", "建立 Java 執行環境");
            var runtime = objKit["javaVersion"]["component"].ToString();

            var obj = await launcher.getJavaRuntime();
            var resource_url = obj["windows-x64"][runtime][0]["manifest"]["url"].ToString();

            var dwObj = await launcher.getJavaDownloadObject(resource_url);
            var fileList = JsonConvert.DeserializeObject<JObject>(dwObj["files"].ToString());

            progressBar.Maximum = fileList.Count;
            progressBar.Value = 0;
            int total = fileList.Count;
            int index = 0;

            foreach (var list in fileList)
            {
                if (!checkFile)
                {
                    if (File.Exists(INSTALLED_PATH)) continue;
                }

                index++;
                if (list.Value["type"].ToString().Equals("directory"))
                {
                    var dir = PathJoin(DATA_FOLDER, "runtimes", runtime, list.Key.ToString());
                    Directory.CreateDirectory(dir);
                }
                else
                {
                    var path = PathJoin(DATA_FOLDER, "runtimes", runtime, list.Key.ToString());
                    var url = list.Value["downloads"]["raw"]["url"].ToString();
                    var sha_remote = list.Value["downloads"]["raw"]["sha1"].ToString();
                    var sha_local = (File.Exists(path)) ? gb.SHA1(File.ReadAllBytes(path)) : "";

                    if (!File.Exists(path) || sha_local != sha_remote)
                    {
                        if (sha_local.Length > 0 && sha_local != sha_remote) output("WARN", $"雜湊值驗證失敗 {list.Key} 將重新下載");
                        Directory.CreateDirectory(Path.GetDirectoryName(path + "."));


                        output("INFO", $"下載 Java {obj["windows-x64"][runtime][0]["version"]["name"]} 執行環境... ({index}/{total}) {list.Key}");
                        await launcher.downloadResource(url, path + ".");
                    }
                    else
                    {
                        output("INFO", $"檢查 Java {obj["windows-x64"][runtime][0]["version"]["name"]} 執行環境... ({index}/{total}) {list.Key}");
                    }
                }

                progressBar.Value = index;
                await Task.Delay(gb.runInterval);
            }

            gb.startupParms.javaRuntime = runtime;
            onCreateLibraries(objKit, gameAssetJson);
        }

        private async void onCreateLibraries(JObject objKit, string gameAssetJson)
        {
            output("INFO", "建立必要元件");
            var dir = PathJoin(DATA_FOLDER, "libraries");
            Directory.CreateDirectory(dir);

            var index = 0;
            JArray res = (JArray)JsonConvert.DeserializeObject(objKit["libraries"].ToString());
            int total = res.Count;
            progressBar.Maximum = total;

            foreach (var r in res)
            {
                index++;
                var canDownload = false;

                // 主目錄檔案下載規則判定
                var rules = r["rules"];
                if (rules != null)
                {
                    foreach (var item in r["rules"])
                    {
                        if (item["action"].ToString().Equals("allow"))
                        {
                            if (item["os"] == null || item["os"]["name"].ToString().Equals("windows"))
                            {
                                canDownload = true;
                            }
                        }

                        if (item["action"].ToString().Equals("disallow"))
                        {
                            if (item["os"] != null && item["os"]["name"].ToString().Equals("windows"))
                            {
                                canDownload = false;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    canDownload = true;
                }

                // 如果符合規則，下載主目錄中的檔案
                if (canDownload && r["downloads"]["artifact"] != null)
                {
                    DownloadListModel xlm = new DownloadListModel();
                    xlm.path = r["downloads"]["artifact"]["path"].ToString();
                    xlm.sha1 = r["downloads"]["artifact"]["sha1"].ToString();
                    xlm.className = r["name"].ToString();
                    xlm.type = 0;
                    xlm.name = "default";

                    var url = r["downloads"]["artifact"]["url"].ToString();

                    if (!downloadList.ContainsKey(url))
                        downloadList.Add(url, xlm);
                }

                var child = r["downloads"]["classifiers"];
                if (child != null)
                {
                    // 僅下載符合作業系統的檔案以及其他通用檔案
                    Dictionary<string, object> cObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(child.ToString());

                    foreach (var c in cObj)
                    {
                        if (c.Key.Equals("natives-windows") || !c.Key.StartsWith("natives-"))
                        {
                            DownloadListModel xlm = new DownloadListModel();
                            var obj = JsonConvert.DeserializeObject<JObject>(c.Value.ToString());
                            xlm.path = obj["path"].ToString();
                            xlm.sha1 = obj["sha1"].ToString();
                            xlm.className = r["name"].ToString();
                            xlm.name = c.Key;
                            string url = obj["url"].ToString();

                            if (c.Key.Equals("natives-windows"))
                            {
                                xlm.type = 2;
                            }
                            else if (!c.Key.StartsWith("natives-"))
                            {
                                xlm.type = 1;

                            }

                            if (!downloadList.ContainsKey(url))
                                downloadList.Add(url, xlm);
                        }
                    }
                }

                output("INFO", $"取得必要元件索引: ({index}/{total})");
                progressBar.Value = index;
            }

            // 非原版客戶端內容
            if (customVer != null)
            {
                string indexVersionName = customVer["id"].ToString();
                string vanillaVersionName = objKit["id"].ToString();
                while (indexVersionName != vanillaVersionName)
                {
                    string data = File.ReadAllText(PathJoin(DATA_FOLDER, "versions", indexVersionName, $"{indexVersionName}.json"));
                    JObject nowLib = JsonConvert.DeserializeObject<JObject>(data);
                    foreach (var item in nowLib["libraries"])
                    {
                        if (item["downloads"] != null)
                        {
                            DownloadListModel xlm = new DownloadListModel();
                            xlm.path = item["downloads"]["artifact"]["path"].ToString();
                            xlm.sha1 = item["downloads"]["artifact"]["sha1"].ToString();
                            xlm.className = item["name"].ToString();
                            xlm.type = 0;
                            xlm.name = "default";

                            string url = item["downloads"]["artifact"]["url"].ToString();

                            if (!downloadList.ContainsKey(url))
                                downloadList.Add(url, xlm);
                        }
                        else
                        {
                            var firstName = (item["name"].ToString().Split(':')[0]).Replace(".", "/");
                            var lastName = item["name"].ToString().Split(':').Skip(1).ToArray();
                            var cDir = firstName + "/" + String.Join("/", lastName);

                            if (Directory.Exists(PathJoin(DATA_FOLDER, "libraries", cDir)) && Directory.GetFiles(PathJoin(DATA_FOLDER, "libraries", cDir)).Count() > 0)
                            {
                                var cPathes = Directory.GetFiles(PathJoin(DATA_FOLDER, "libraries", cDir));

                                foreach (var cPath in cPathes)
                                {
                                    DownloadListModel xlm = new DownloadListModel();
                                    xlm.path = cDir + "/" + Path.GetFileName(cPath);
                                    xlm.sha1 = "";
                                    xlm.className = item["name"].ToString();
                                    xlm.type = 0;
                                    xlm.name = "default";

                                    var hash = $"custom-{gb.SHA1(cPath)}";

                                    if (!downloadList.ContainsKey(hash))
                                        downloadList.Add(hash, xlm);

                                    output("INFO", $"取得必要元件索引(自訂客戶端): {xlm.path}");
                                }
                            }
                            else
                            {
                                string url = "https://repo1.maven.org/maven2/" + cDir;
                                string[] dirArr = cDir.Split('/');
                                string fileName = dirArr[dirArr.Length - 2] + "-" + dirArr[dirArr.Length - 1] + ".jar";
                                url += "/" + fileName;

                                DownloadListModel xlm = new DownloadListModel();
                                xlm.path = cDir + "/" + fileName;
                                xlm.sha1 = "";
                                xlm.className = item["name"].ToString();
                                xlm.type = 0;
                                xlm.name = "default";

                                if (!downloadList.ContainsKey(url))
                                    downloadList.Add(url, xlm);

                                output("INFO", $"取得必要元件索引(自訂客戶端): {xlm.path}");
                            }
                        }
                    }
                    indexVersionName = nowLib["inheritsFrom"].ToString();
                }
            }

            index = 0;
            total = downloadList.Count;
            progressBar.Value = 0;
            progressBar.Maximum = total;

            foreach (var d in downloadList)
            {
                index++;
                var path = d.Value.path;

                var test = path.Split('/');
                var len = test.Length;

                string cDir = "";
                string cFilename = "";
                for (int i = 0; i < len; i++)
                {
                    if (len - 1 == i)
                    {
                        cFilename = test[i];
                    }
                    else
                    {
                        cDir += test[i] + "/";
                    }
                }

                var full_name = d.Value.className;
                var full_nameArr = full_name.Split(':');
                var version = full_nameArr.Last().Replace("natives-", "").Replace("-", ".");

                var className = String.Join(".", full_nameArr.Take(full_nameArr.Length - 1));
                var cPath = "";

                // natives 檔案 (動態函數庫)
                if (d.Value.type == 2)
                {
                    cFilename = cFilename.Replace("-natives-windows.jar", ".jar");
                    cDir = PathJoin(dir, d.Value.name, cDir);

                    Directory.CreateDirectory(cDir);
                    cPath = PathJoin(cDir, cFilename);
                    // 如果物件內沒有這個名字或是物件內的版本比較舊，則更新物件內容
                    LibrariesModel insideModel;

                    if (nativesList.TryGetValue(className, out insideModel))
                    {
                        //var nowVer = new Version(version);
                        //var compareVer = new Version(insideModel.version);
                        var nowVer = version;
                        var compareVer = insideModel.version;
                        Console.WriteLine($"{nativesList[className].dir} , {insideModel.dir}");
                        Console.WriteLine($"{nowVer} , {compareVer}");

                        if (gb.CompareVersionStrings(nowVer, compareVer) > 0)
                        {
                            insideModel.version = version;
                            insideModel.dir = cPath;

                            nativesList.Remove(className);
                            nativesList.Add(className, insideModel);
                        }
                    }
                    else
                    {
                        insideModel = new LibrariesModel();
                        insideModel.dir = cPath;
                        insideModel.version = version;
                        nativesList.Add(className, insideModel);
                    }
                }
                // 其他通用檔案 (依賴關係庫)
                else
                {
                    cDir = PathJoin(dir, cDir);
                    Directory.CreateDirectory(cDir);
                    cPath = PathJoin(cDir, cFilename);

                    // 如果物件內沒有這個名字或是物件內的版本比較舊，則更新物件內容
                    LibrariesModel insideModel;

                    if (librariesList.TryGetValue(className, out insideModel))
                    {
                        //var nowVer = new Version(version);
                        //var compareVer = new Version(insideModel.version);
                        var nowVer = version;
                        var compareVer = insideModel.version;
                        if (gb.CompareVersionStrings(nowVer, compareVer) > 0)
                        {
                            insideModel.version = version;
                            insideModel.dir = cPath;

                            librariesList.Remove(className);
                            librariesList.Add(className, insideModel);
                        }
                    }
                    else
                    {
                        insideModel = new LibrariesModel();
                        insideModel.dir = cPath;
                        insideModel.version = version;
                        librariesList.Add(className, insideModel);
                    }
                }
                if (!checkFile)
                {
                    if (File.Exists(INSTALLED_PATH)) continue;
                }

                progressBar.Value = index;

                var sha_remote = d.Value.sha1;
                var sha_local = (File.Exists(cPath)) ? gb.SHA1(File.ReadAllBytes(cPath)) : "";

                if (d.Key.StartsWith("custom-"))
                {
                    output("INFO", $"檢查必要元件... ({index}/{total}) {cPath}");
                }
                else
                {
                    if (!File.Exists(cPath) || sha_local != sha_remote || sha_remote.Length == 0)
                    {
                        if (sha_local.Length > 0 && sha_local != sha_remote) output("WARN", $"雜湊值驗證失敗 {cFilename} 將重新下載");

                        output("INFO", $"下載必要元件... ({index}/{total}) {cPath}");
                        await launcher.downloadResource(d.Key, cPath);
                    }
                    else
                    {
                        output("INFO", $"檢查必要元件... ({index}/{total}) {cPath}");
                    }
                }

                await Task.Delay(gb.runInterval);
            }

            output("INFO", "必要元件建立完成");
            onCreateObjects(gameAssetJson);
        }

        private async void onCreateObjects(string gameAssetJson)
        {
            output("INFO", "建立遊戲資料");
            var dir = PathJoin(DATA_FOLDER, "assets/objects");
            Directory.CreateDirectory(dir);

            JObject obj = JsonConvert.DeserializeObject<JObject>(gameAssetJson);
            var _resource_url = "https://resources.download.minecraft.net/%hash_prefix%/%hash%";
            var index = 0;

            JObject res = (JObject)JsonConvert.DeserializeObject(obj["objects"].ToString());

            int total = res.Count;
            progressBar.Maximum = total;

            foreach (var r in res)
            {
                if (!checkFile)
                {
                    if (File.Exists(INSTALLED_PATH)) continue;
                    if (customVer != null) continue;
                }

                index++;

                var hash_prefix = r.Value["hash"].ToString().Substring(0, 2);
                var hash = r.Value["hash"].ToString();
                var resource_url = _resource_url.Replace("%hash_prefix%", hash_prefix).Replace("%hash%", hash);

                var cPath = PathJoin(dir, hash_prefix, hash);
                Directory.CreateDirectory(PathJoin(dir, hash_prefix));

                var sha_remote = r.Value["hash"].ToString();
                var sha_local = (File.Exists(cPath)) ? gb.SHA1(File.ReadAllBytes(cPath)) : "";

                if (!File.Exists(cPath) || sha_local != sha_remote)
                {
                    if (sha_local.Length > 0 && sha_remote != sha_local) output("WARN", $"雜湊值驗證失敗 {r.Key}");

                    output("INFO", $"下載遊戲資料... ({index}/{total}) {r.Key}");
                    await launcher.downloadResource(resource_url, cPath);
                }
                else
                {
                    output("INFO", $"檢查遊戲資料... ({index}/{total}) {r.Key}");
                }

                if (r.Key.StartsWith("icons/"))
                {
                    Directory.CreateDirectory(PathJoin(DATA_FOLDER, "assets", "icons"));
                    File.Copy(cPath, PathJoin(DATA_FOLDER, "assets", r.Key), true);
                }

                progressBar.Value = index;
                await Task.Delay(gb.runInterval);
            }

            if (!checkFile)
                onUnzipped();
            else
            {
                output("INFO", "檢查完畢");
                settingAllControl(true);
            }
        }
        private void onUnzipped()
        {
            output("INFO", "解壓縮動態函數庫");
            gb.startupParms.appUID = Guid.NewGuid().ToString();
            var dir = PathJoin(DATA_FOLDER, "bin", gb.startupParms.appUID);
            Directory.CreateDirectory(dir);

            var nativesPath = new List<string>();
            foreach (var n in nativesList)
            {
                nativesPath.Add(n.Value.dir);
            }

            var index = nativesPath.Count;
            foreach (var np in nativesPath)
            {
                using (ZipArchive source = ZipFile.Open(np, ZipArchiveMode.Read, null))
                {
                    foreach (ZipArchiveEntry entry in source.Entries)
                    {
                        string fullPath = Path.GetFullPath(Path.Combine(dir, entry.FullName));

                        if (Path.GetFileName(fullPath).Length != 0)
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                            // The boolean parameter determines whether an existing file that has the same name as the destination file should be overwritten
                            entry.ExtractToFile(fullPath, true);
                        }
                    }
                }

                index--;

                if (index == 0)
                {
                    Directory.Delete(PathJoin(dir, "META-INF"), true);
                }
            }


            preVersionSupport();
        }

        private void preVersionSupport()
        {
            output("INFO", "正在相容舊版本");
            CultureInfo ci = CultureInfo.CurrentUICulture;
            string lang = ci.Name;

            var dir = PathJoin(DATA_FOLDER, "options.txt");
            if (File.Exists(dir))
            {
                if (gb.startupParms.loggerIndex == null)
                {
                    var data = File.ReadAllLines(dir);
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i].StartsWith("lang:"))
                        {
                            var fileLang = data[i].Split(':')[1].Split('_');
                            data[i] = $"lang:{fileLang[0]}_{fileLang[1].ToUpper()}";
                        }
                    }

                    File.WriteAllLines(dir, data);
                }
            }
            else
            {
                var optionArr = new List<string>();
                optionArr.Add($"lang:{lang.Replace("-", "_").ToLower()}");
                optionArr.Add($"lang:{lang.Replace("-", "_")}");
                optionArr.Add($"guiScale:2");

                File.WriteAllText(dir, String.Join(Environment.NewLine, optionArr));
            }

            onLaunchGame();
        }

        private void onLaunchGame()
        {
            progressBar.Style = ProgressBarStyle.Marquee;
            output("INFO", "啟動遊戲");

            var assetsDir = PathJoin(DATA_FOLDER, "assets");
            var cDir = PathJoin(DATA_FOLDER, "versions", gb.startupParms.version, gb.startupParms.version + ".jar");
            if (customVer != null && !File.Exists(cDir))
            {
                if (customVer["jar"] != null)
                    cDir = PathJoin(DATA_FOLDER, "versions", customVer["jar"].ToString(), customVer["jar"].ToString() + ".jar");
                else
                    cDir = PathJoin(DATA_FOLDER, "versions", customVer["inheritsFrom"].ToString(), customVer["inheritsFrom"].ToString() + ".jar");
            }

            var librariesPath = new List<string>();

            var hash = gb.SHA1(File.ReadAllBytes(cDir));
            var profiles_path = PathJoin(DATA_FOLDER, "launcher_profiles.json");

            LauncherProfilesModelChild lpmc = new LauncherProfilesModelChild();
            lpmc.created = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            lpmc.lastUsed = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            lpmc.lastVersionId = gb.startupParms.version;
            lpmc.name = gb.startupParms.version;
            lpmc.type = "custom";
            lpmc.icon = "Furnace";

            if (File.Exists(profiles_path))
            {
                var data = File.ReadAllText(profiles_path);
                var obj = JsonConvert.DeserializeObject<LauncherProfilesModel>(data);

                if (obj.profiles.ContainsKey(hash))
                {
                    obj.profiles[hash].lastUsed = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                }
                else
                    obj.profiles.Add(hash, lpmc);

                File.WriteAllText(profiles_path, JsonConvert.SerializeObject(obj));
            }
            else
            {
                LauncherProfilesModel lpm = new LauncherProfilesModel();
                lpm.profiles = new Dictionary<string, LauncherProfilesModelChild>();
                lpm.profiles.Add(hash, lpmc);

                File.WriteAllText(profiles_path, JsonConvert.SerializeObject(lpm));
            }





            foreach (var lb in librariesList)
            {
                librariesPath.Add(lb.Value.dir);
            }
            librariesPath.Add(cDir);

            string launchOptions = gb.startupParms.minecraftArguments;
            string jarPath = String.Join(";", librariesPath);
            List<string> jvm = new List<string>();
            JObject replaceOptions = new JObject();

            jvm.Add("-Xms512m");
            jvm.Add("-Dminecraft.launcher.brand=XCoreNET");
            jvm.Add("-Dminecraft.launcher.version=" + Application.ProductVersion);
            jvm.Add("-Djava.library.path=" + PathJoin(DATA_FOLDER, "bin", gb.startupParms.appUID));

            if (gb.startupParms.loggerIndex != null)
                jvm.Add("-Dlog4j.configurationFile=" + PathJoin(assetsDir, "log-configs", gb.startupParms.loggerIndex));

            replaceOptions.Add("${auth_player_name}", gb.startupParms.username);
            replaceOptions.Add("${version_name}", gb.startupParms.version);
            replaceOptions.Add("${game_directory}", DATA_FOLDER);
            replaceOptions.Add("${assets_root}", assetsDir);
            replaceOptions.Add("${game_assets}", assetsDir);
            replaceOptions.Add("${assets_index_name}", gb.startupParms.assetIndex);
            replaceOptions.Add("${auth_uuid}", gb.startupParms.uuid);
            replaceOptions.Add("${auth_access_token}", gb.startupParms.accessToken);
            replaceOptions.Add("${auth_session}", gb.startupParms.accessToken);
            replaceOptions.Add("${user_type}", "msa");
            replaceOptions.Add("${version_type}", "release");
            replaceOptions.Add("${user_properties}", "{}");

            StringBuilder builder = new StringBuilder(launchOptions);

            foreach (var rp in replaceOptions)
            {
                builder.Replace(rp.Key, rp.Value.ToString());
            }

            var classPath = new string[]
            {
                "-cp",
                jarPath
            };

            string javaPath = PathJoin(DATA_FOLDER, "runtimes", gb.startupParms.javaRuntime, "bin", "java.exe");
            string startupParms = "";

            startupParms += String.Join(" ", jvm) + " ";
            startupParms += String.Join(" ", classPath) + " ";


            if (customVer != null && customVer["arguments"] != null && customVer["arguments"]["jvm"] != null)
            {
                List<string> cJvmList = new List<string>();
                JObject replaceOptionsCustom = new JObject();
                JArray customJvm = (JArray)customVer["arguments"]["jvm"];
                replaceOptionsCustom.Add("${version_name}", customVer["inheritsFrom"].ToString());
                replaceOptionsCustom.Add("${library_directory}", PathJoin(DATA_FOLDER, "libraries"));
                replaceOptionsCustom.Add("${classpath_separator}", ";");

                foreach (var jvmArr in customJvm)
                {
                    string cJvm = jvmArr.ToString();
                    foreach (var rp in replaceOptionsCustom)
                    {
                        StringBuilder cBuilder = new StringBuilder(cJvm);
                        cBuilder.Replace(rp.Key, rp.Value.ToString());
                        cJvm = cBuilder.ToString();
                    }


                    cJvmList.Add(cJvm);
                }


                startupParms += String.Join(" ", cJvmList) + " ";
            }


            startupParms += gb.startupParms.main + " ";
            startupParms += builder.ToString();

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = javaPath;
            startInfo.Arguments = startupParms;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.WorkingDirectory = DATA_FOLDER;
            startInfo.StandardOutputEncoding = Encoding.UTF8;

            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.EnableRaisingEvents = true;

            var installedPath = PathJoin(DATA_FOLDER, "versions", versionList.SelectedItem.ToString(), "installed.");
            if (!File.Exists(installedPath))
            {
                File.WriteAllText(installedPath, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            }

            try
            {
                GC.Collect();

                bool readyToExited = false;
                progressBar.Value = progressBar.Maximum;

                proc.Exited += (sender, e) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        progressBar.Style = ProgressBarStyle.Blocks;
                        output("INFO", "關閉遊戲");
                        Directory.Delete(PathJoin(DATA_FOLDER, "bin", gb.startupParms.appUID), true);
                        settingAllControl(true);
                        this.Activate();
                    }));
                    GC.Collect();
                };



                proc.Start();
                proc.BeginOutputReadLine();
                proc.OutputDataReceived += OutputDataReceivedHandler;



                proc.OutputDataReceived += (sender, args) =>
                {
                    if (args.Data == null) return;

                    var data = args.Data.Trim();
                    if (data.Equals("Stopping!"))
                        readyToExited = true;

                    if (data.Equals("SoundSystem shutting down...") && readyToExited)
                    {
                        Task.Delay(2000).ContinueWith(t =>
                        {
                            if (!proc.HasExited)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    outputDebug("WARN", "偵測到程式未完全關閉，已強制結束處理程序");
                                }));
                                proc.Kill();
                            }
                        });
                    }
                };

                this.FormClosing += (sender, e) =>
                {
                    if (!proc.HasExited)
                    {
                        var result = MessageBox.Show("關閉啟動器會導致遊戲結束時不會自動清除暫存檔案，您確定要關閉嗎？", "說明", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                    }
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void OutputDataReceivedHandler(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
            {
                var data = args.Data.Trim();
                if (data == null || data.Length == 0) return;

                if (data.StartsWith("<log4j:Message><![CDATA[") && data.EndsWith("]]></log4j:Message>"))
                {
                    data = data.TrimStart("<log4j:Message><![CDATA[").TrimEnd("]]></log4j:Message>");

                    this.Invoke(new Action(() =>
                    {
                        if (!data.Contains(gb.startupParms.accessToken))
                            outputDebug("GAME", data);
                    }));
                }
                else
                {
                    if (!data.EndsWith("</log4j:Event>") && !data.StartsWith("<log4j:Event"))
                    {
                        this.Invoke(new Action(() =>
                        {
                            outputDebug("GAME", args.Data);
                        }));
                    }
                }


                if (progressBar.Style != ProgressBarStyle.Blocks)
                {
                    this.Invoke(new Action(() =>
                    {
                        progressBar.Style = ProgressBarStyle.Blocks;
                    }));
                }
            }
            else
            {
                Console.WriteLine(args.Data);
            }
        }

        private string PathJoin(params string[] args)
        {
            string[] result = args.Select(x => x.Replace('/', Path.DirectorySeparatorChar)).ToArray();
            return Path.GetFullPath(String.Join(Path.DirectorySeparatorChar.ToString(), result));
        }

        private void textBoxInterval_KeyUp(object sender, KeyEventArgs e)
        {
            int result;
            if (int.TryParse(textBoxInterval.Text, out result))
            {
                if (result < 0)
                {
                    MessageBox.Show("數字必須大於等於零", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxInterval.Text = "1";
                    gb.runInterval = 1;
                }
                else
                {
                    textBoxInterval.Text = result.ToString();
                    gb.runInterval = result;
                }
                gb.savingSession();
            }
            else
            {
                MessageBox.Show("您只能輸入數字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxInterval.Text = "1";
                gb.runInterval = 1;
                gb.savingSession();
            }
        }

        private void textVersionSelected_Click(object sender, EventArgs e)
        {
            textVersionSelected.SelectAll();
        }

        private void versionList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textVersionSelected.Text = versionList.SelectedItem.ToString();
        }

        private void btnMainSetting_Click(object sender, EventArgs e)
        {
            settingForm sf = new settingForm();
            sf.ShowDialog();
        }

        private void btnChkUpdate_Click(object sender, EventArgs e)
        {
            gb.checkForUpdate();
        }

        private async void btnSwitchAcc_Click(object sender, EventArgs e)
        {
            loginMicrosoftForm lmf = new loginMicrosoftForm();
            var resultDialog = lmf.ShowDialog();
            if (resultDialog != DialogResult.Cancel)
            {
                Tasks.loginChallengeTask challenge = new Tasks.loginChallengeTask(true);
                var result = await challenge.start();

                if (result == DialogResult.OK)
                {
                    progressBar.Maximum = 60;
                    progressBar.Value = 0;
                    onAzureToken(gb.azureToken);
                    gb.azureToken = "";
                    gb.savingSession();
                }
            }

            lmf.Dispose();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            gb.resetTokens();
            gb.savingSession();

            FormCollection fc = Application.OpenForms;

            if (fc[0].Name == this.Name)
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                Environment.Exit(0);
            }
            else
            {
                this.Close();
            }
        }

        private void chkBoxRelease_Click(object sender, EventArgs e)
        {
            groupBoxVersion.Enabled = false;
            gb.verOptRelease = chkBoxRelease.Checked;
            gb.savingSession();
            onGetAllVersion();
        }

        private void chkBoxSnapshot_Click(object sender, EventArgs e)
        {
            groupBoxVersion.Enabled = false;
            gb.verOptSnapshot = chkBoxSnapshot.Checked;
            gb.savingSession();
            onGetAllVersion();
        }

        private async void btnLogoutAll_Click(object sender, EventArgs e)
        {
            settingAllControl(false);

            var result = MessageBox.Show("這會清除在此啟動器中儲存的所有登入資料並且將您登出，是否繼續？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Microsoft.Web.WebView2.WinForms.WebView2 tempWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
                await tempWebView.EnsureCoreWebView2Async(null);

                var cookies = await tempWebView.CoreWebView2.CookieManager.GetCookiesAsync(gb.getMicrosoftOAuthURL());

                foreach (var cookie in cookies)
                {
                    tempWebView.CoreWebView2.CookieManager.DeleteCookie(cookie);
                }

                tempWebView.Dispose();

                btnLogout_Click(sender, e);
            }
            else
            {
                settingAllControl(true);
            }
        }

        private void textBoxInterval_Click(object sender, EventArgs e)
        {
            textBoxInterval.SelectAll();
        }

        private void buttonVerReload_Click(object sender, EventArgs e)
        {
            onGetAllVersion();
        }
    }
}
