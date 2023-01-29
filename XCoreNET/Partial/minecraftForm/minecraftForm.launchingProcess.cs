using Global;
using Microsoft.WindowsAPICodePack.Taskbar;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static XCoreNET.ClassModel.launcherModel;
using static XCoreNET.Tasks.launcherTask;

namespace XCoreNET
{
    public partial class minecraftForm
    {
        private void onVersionInfo()
        {
            if (!Directory.Exists(gb.mainFolder))
                createGameDefFolder();

            customVer = null;
            settingAllControl(false);
            progressBar.Value = 0;

            if (gb.versionNameList.Count == 0 || gb.lastVersionID.Length == 0 || textVersionSelected.Text.Length == 0)
            {
                MessageBox.Show("未找到有效的版本可供啟動", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                settingAllControl(true);
                return;
            }

            gb.resetStartupParms();
            gb.lastVersionID = textVersionSelected.Text;

            string selectVersion = null;
            string verURL = null;

            foreach (var oVlm in gb.versionListModels)
            {
                if (oVlm.version.Equals(gb.lastVersionID))
                {
                    selectVersion = oVlm.version;
                    verURL = oVlm.url;
                }
            }

            gb.savingSession(false);

            if (selectVersion != null && verURL != null)
            {
                onCreateIndexes(selectVersion, verURL);
            }
            else
            {
                // 非原版客戶端區塊

                var dir = gb.PathJoin(DATA_FOLDER, "versions", selectVersion, $"{selectVersion}.json");
                if (!File.Exists(dir))
                {
                    MessageBox.Show($"找不到客戶端版本資訊檔: {selectVersion}.json", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    output("ERROR", $"找不到客戶端版本資訊檔: {selectVersion}.json");
                    settingAllControl(true);
                    return;
                }

                var data = File.ReadAllText(dir);
                JObject obj = JsonConvert.DeserializeObject<JObject>(data);
                var vanillaInfo = (obj["inheritsFrom"] != null) ? obj["inheritsFrom"] : obj["jar"];

                if (File.Exists(gb.PathJoin(DATA_FOLDER, "versions", vanillaInfo.ToString(), $"{vanillaInfo.ToString()}.jar")))
                {
                    foreach (var item in gb.versionListModels)
                    {
                        if (item.version.Equals(vanillaInfo.ToString()))
                        {
                            verURL = item.url;
                        }
                    }
                }

                if (verURL != null && verURL.Length > 0)
                {
                    customVer = obj;
                    onCreateIndexes(selectVersion, verURL);
                }
                else
                {
                    string vanillaVersion = "";
                    if (vanillaInfo != null)
                    {
                        vanillaVersion = vanillaInfo.ToString();
                    }
                    MessageBox.Show($"找不到原生客戶端版本 {vanillaVersion}", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (vanillaVersion.Length > 0)
                    {
                        var result = MessageBox.Show($"是否要現在安裝原生 {vanillaVersion} 客戶端？", "說明", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            foreach (JObject item in version_manifest_v2)
                            {
                                if (item["id"].ToString().Equals(vanillaVersion))
                                {
                                    textVersionSelected.Text = item["id"].ToString();
                                    break;
                                }
                            }

                            checkFile = true;
                            onVersionInfo();
                            settingAllControl(false);
                        }
                        else
                            settingAllControl(true);
                    }
                    else
                        settingAllControl(true);
                }
            }
        }

        private async void onCreateIndexes(string version, string url)
        {
            if (isClosed) return;

            progressBar.Style = ProgressBarStyle.Marquee;
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate, Handle);
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
            var dir = gb.PathJoin(DATA_FOLDER, "assets/indexes");

            Directory.CreateDirectory(dir);
            Console.WriteLine(gb.PathJoin(dir, $"{id}.json"));
            File.WriteAllText(gb.PathJoin(dir, $"{id}.json"), body);

            onCreateGameData(version, obj["downloads"]["client"]["sha1"].ToString(), obj, client_url, body);
        }

        private async void onCreateGameData(string version, string hash, JObject gameNecessaryKit, string clientURL, string gameAssetJson)
        {
            output("INFO", "建立遊戲主程式");

            if (customVer == null)
            {
                var dir = gb.PathJoin(DATA_FOLDER, "versions", version);
                var dir_json = gb.PathJoin(dir, $"{version}.json");
                var dir_jar = gb.PathJoin(dir, $"{version}.jar");

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
                // 非原版客戶端區塊

                var dir_jar = gb.PathJoin(DATA_FOLDER, "versions", version, $"{version}.jar");
                if (File.Exists(dir_jar) && new FileInfo(dir_jar).Length == 0)
                {
                    output("INFO", "正在下載遊戲主程式");
                    await launcher.downloadResource(clientURL, dir_jar);
                }

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


            INSTALLED_PATH = gb.PathJoin(DATA_FOLDER, "versions", version, "installed.");


            // 舊版本沒有使用 log4j
            if (gameNecessaryKit["logging"] != null)
                onCreateLogger(gameNecessaryKit["logging"]["client"]["file"]["url"].ToString(), gameNecessaryKit["logging"]["client"]["file"]["id"].ToString());

            onJavaProgram(gameNecessaryKit, gameAssetJson);
        }

        private async void onCreateLogger(string url, string filename)
        {
            output("INFO", "建立記錄器規則");
            var dir = gb.PathJoin(DATA_FOLDER, "assets/log-configs");
            Directory.CreateDirectory(dir);

            await launcher.downloadResource(url, gb.PathJoin(dir, filename));

            gb.startupParms.loggerIndex = filename;
        }

        private async void onJavaProgram(JObject objKit, string gameAssetJson)
        {
            if (isClosed) return;
            downloadingPath = new List<string>();
            indexObj = new List<ConcurrentDownloadListModel>();
            concurrentTotalSize = 0;
            concurrentTotalCompletedDisplay = 0;
            concurrentType = " Java 執行環境";
            concurrentNowSize = new Dictionary<string, ConcurrentDownloadListModel>();

            progressBar.Style = ProgressBarStyle.Blocks;
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, Handle);
            output("INFO", "建立 Java 執行環境");
            var runtime = (objKit["javaVersion"] != null) ? objKit["javaVersion"]["component"].ToString() : "jre-legacy";

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
                if (isClosed) return;

                if (!checkFile)
                {
                    if (File.Exists(INSTALLED_PATH)) continue;
                }

                index++;
                if (list.Value["type"].ToString().Equals("directory"))
                {
                    var dir = gb.PathJoin(DATA_FOLDER, "runtimes", runtime, list.Key.ToString());
                    Directory.CreateDirectory(dir);
                }
                else
                {
                    var path = gb.PathJoin(DATA_FOLDER, "runtimes", runtime, list.Key.ToString());
                    var url = list.Value["downloads"]["raw"]["url"].ToString();
                    var sha_remote = list.Value["downloads"]["raw"]["sha1"].ToString();
                    var sha_local = (File.Exists(path)) ? gb.SHA1(File.ReadAllBytes(path)) : "";

                    if (!File.Exists(path) || sha_local != sha_remote)
                    {
                        if (sha_local.Length > 0 && sha_local != sha_remote) output("WARN", $"雜湊值驗證失敗 {list.Key} 將重新下載");
                        Directory.CreateDirectory(Path.GetDirectoryName(path + "."));


                        if (gb.isConcurrent)
                        {
                            ConcurrentDownloadListModel cdlm = new ConcurrentDownloadListModel();
                            cdlm.uid = list.Key;
                            cdlm.id = list.Key;
                            cdlm.url = url;
                            cdlm.path = path + ".";
                            cdlm.size = 0;
                            cdlm.totSize = int.Parse(list.Value["downloads"]["raw"]["size"].ToString());
                            indexObj.Add(cdlm);

                            if (!concurrentNowSize.ContainsKey(list.Key))
                                concurrentNowSize.Add(list.Key, cdlm);

                            concurrentTotalSize += int.Parse(list.Value["downloads"]["raw"]["size"].ToString());
                            output("INFO", $"索引 Java {obj["windows-x64"][runtime][0]["version"]["name"]} 執行環境... ({index}/{total}) {list.Key}");
                        }
                        else
                        {
                            output("INFO", $"下載 Java {obj["windows-x64"][runtime][0]["version"]["name"]} 執行環境... ({index}/{total}) {list.Key}");
                            await launcher.downloadResource(url, path + ".");
                        }
                    }
                    else
                    {
                        output("INFO", $"檢查 Java {obj["windows-x64"][runtime][0]["version"]["name"]} 執行環境... ({index}/{total}) {list.Key}");
                    }
                }

                progressBar.Value = index;

                if (!isClosed)
                    TaskbarManager.Instance.SetProgressValue(index, total, Handle);
                await Task.Delay(gb.runInterval);
            }

            if (indexObj.Count > 0)
            {
                output("INFO", $"準備並行下載 Java 執行環境...");

                progressBar.Value = 0;
                progressBar.Maximum = concurrentTotalSize;
                //timerConcurrent.Enabled = true;

                for (int i = 0; i < indexObj.Count; i += 200)
                {
                    Console.WriteLine($"indexing: {i}");
                    concurrentTotalCompleted = 0;

                    var indexList = indexObj.GetRange(i, (indexObj.Count - i < 200) ? indexObj.Count - i : 200);
                    foreach (var item in indexList)
                    {
                        onThreadDownloader(item.url, item.path, item.id, item.uid);
                    }



                    while (concurrentTotalCompleted != indexList.Count)
                    {
                        await Task.Delay(500);
                        Console.WriteLine($"while ticked: {concurrentTotalCompleted}/{indexList.Count}");
                    }
                }

                timerConcurrent.Enabled = false;
                await Task.Delay(100);
                UpdateDownloadState();
            }

            gb.startupParms.javaRuntime = runtime;
            onCreateLibraries(objKit, gameAssetJson);
        }

        private async void onCreateLibraries(JObject objKit, string gameAssetJson)
        {
            if (isClosed) return;
            downloadingPath = new List<string>();
            indexObj = new List<ConcurrentDownloadListModel>();
            concurrentTotalCompletedDisplay = 0;
            concurrentTotalSize = 0;
            concurrentType = "必要元件";
            concurrentNowSize = new Dictionary<string, ConcurrentDownloadListModel>();

            output("INFO", "建立必要元件");
            var dir = gb.PathJoin(DATA_FOLDER, "libraries");
            Directory.CreateDirectory(dir);

            var index = 0;
            JArray res = (JArray)JsonConvert.DeserializeObject(objKit["libraries"].ToString());
            int total = res.Count;
            progressBar.Maximum = total;

            foreach (var r in res)
            {
                if (isClosed) return;

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
                    if (r["name"].ToString().EndsWith("natives-windows"))
                    {
                        var classNameLen = r["name"].ToString().Split(':').Length;
                        xlm.path = r["downloads"]["artifact"]["path"].ToString();
                        xlm.sha1 = r["downloads"]["artifact"]["sha1"].ToString();
                        xlm.size = int.Parse(r["downloads"]["artifact"]["size"].ToString());
                        xlm.className = r["name"].ToString();
                        xlm.type = 2;
                        xlm.name = r["name"].ToString().Split(':')[classNameLen - 1];
                    }
                    else
                    {
                        xlm.path = r["downloads"]["artifact"]["path"].ToString();
                        xlm.size = int.Parse(r["downloads"]["artifact"]["size"].ToString());
                        xlm.sha1 = r["downloads"]["artifact"]["sha1"].ToString();
                        xlm.className = r["name"].ToString();
                        xlm.type = 0;
                        xlm.name = "default";
                    }

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
                            xlm.size = int.Parse(obj["size"].ToString());
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

                output("INFO", $"取得必要元件索引... ({index}/{total})");
                progressBar.Value = index;

                if (!isClosed)
                    TaskbarManager.Instance.SetProgressValue(index, total, Handle);
            }

            // 非原版客戶端內容
            if (customVer != null)
            {
                string indexVersionName = customVer["id"].ToString();
                string vanillaVersionName = objKit["id"].ToString();
                while (indexVersionName != vanillaVersionName)
                {
                    string data = File.ReadAllText(gb.PathJoin(DATA_FOLDER, "versions", indexVersionName, $"{indexVersionName}.json"));
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

                            if (Directory.Exists(gb.PathJoin(DATA_FOLDER, "libraries", cDir)) && Directory.GetFiles(gb.PathJoin(DATA_FOLDER, "libraries", cDir)).Count() > 0)
                            {
                                var cPathes = Directory.GetFiles(gb.PathJoin(DATA_FOLDER, "libraries", cDir));

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
                if (isClosed) return;

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
                var nameLen = full_name.Split(':').Length;
                var version = "";
                var className = "";

                if (full_name.Split(':')[nameLen - 1].Contains("natives-windows"))
                {
                    version = full_name.Split(':')[nameLen - 2];
                    className = full_name.Split(':')[nameLen - 3];
                }
                else
                {
                    version = full_name.Split(':')[nameLen - 1];
                    className = full_name.Split(':')[nameLen - 2];
                }

                var cPath = "";

                // natives 檔案 (動態函數庫)
                if (d.Value.type == 2)
                {
                    cFilename = cFilename.Replace("-natives-windows.jar", ".jar");
                    cDir = gb.PathJoin(dir, d.Value.name, cDir);

                    Directory.CreateDirectory(cDir);
                    cPath = gb.PathJoin(cDir, cFilename);

                    // 如果物件內沒有這個名字或是物件內的版本比較舊，則更新物件內容
                    LibrariesModel insideModel;

                    if (nativesList.TryGetValue(className, out insideModel))
                    {
                        //var nowVer = new Version(version);
                        //var compareVer = new Version(insideModel.version);
                        var nowVer = version;
                        var compareVer = insideModel.version;

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
                    cDir = gb.PathJoin(dir, cDir);
                    Directory.CreateDirectory(cDir);
                    cPath = gb.PathJoin(cDir, cFilename);

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
                if (!isClosed)
                    TaskbarManager.Instance.SetProgressValue(index, total, Handle);

                var sha_remote = d.Value.sha1;
                var sha_local = (File.Exists(cPath)) ? gb.SHA1(File.ReadAllBytes(cPath)) : "";

                if (d.Key.StartsWith("custom-"))
                {
                    output("INFO", $"檢查必要元件... ({index}/{total}) {d.Value.className}");
                }
                else
                {
                    if (!File.Exists(cPath) || sha_local != sha_remote || sha_remote.Length == 0)
                    {
                        if (sha_local.Length > 0 && sha_local != sha_remote) output("WARN", $"雜湊值驗證失敗 {cFilename} 將重新下載");


                        if (gb.isConcurrent)
                        {
                            ConcurrentDownloadListModel cdlm = new ConcurrentDownloadListModel();
                            cdlm.uid = d.Key;
                            cdlm.id = d.Value.className;
                            cdlm.url = d.Key;
                            cdlm.path = cPath;
                            cdlm.size = 0;
                            cdlm.totSize = d.Value.size;
                            indexObj.Add(cdlm);

                            if (!concurrentNowSize.ContainsKey(d.Key))
                                concurrentNowSize.Add(d.Key, cdlm);

                            concurrentTotalSize += d.Value.size;
                            output("INFO", $"索引必要元件... ({index}/{total}) {d.Value.className}");
                        }
                        else
                        {
                            output("INFO", $"下載必要元件... ({index}/{total}) {d.Value.className}");
                            await launcher.downloadResource(d.Key, cPath);
                        }
                    }
                    else
                    {
                        output("INFO", $"檢查必要元件... ({index}/{total}) {d.Value.className}");
                    }
                }

                await Task.Delay(gb.runInterval);
            }

            if (indexObj.Count > 0)
            {
                output("INFO", $"準備並行下載必要元件...");

                progressBar.Value = 0;
                progressBar.Maximum = concurrentTotalSize;
                //timerConcurrent.Enabled = true;

                for (int i = 0; i < indexObj.Count; i += 200)
                {
                    Console.WriteLine($"indexing: {i}");
                    concurrentTotalCompleted = 0;

                    var indexList = indexObj.GetRange(i, (indexObj.Count - i < 200) ? indexObj.Count - i : 200);
                    foreach (var item in indexList)
                    {
                        onThreadDownloader(item.url, item.path, item.id, item.uid);
                    }



                    while (concurrentTotalCompleted != indexList.Count)
                    {
                        await Task.Delay(500);
                        Console.WriteLine($"while ticked: {concurrentTotalCompleted}/{indexList.Count}");
                    }
                }

                timerConcurrent.Enabled = false;
                await Task.Delay(100);
                UpdateDownloadState();
            }

            output("INFO", "必要元件建立完成");
            onCreateObjects(gameAssetJson);
        }

        private async void onCreateObjects(string gameAssetJson)
        {
            if (isClosed) return;
            downloadingPath = new List<string>();
            indexObj = new List<ConcurrentDownloadListModel>();
            concurrentTotalCompletedDisplay = 0;
            concurrentTotalSize = 0;
            concurrentType = "遊戲資料";
            concurrentNowSize = new Dictionary<string, ConcurrentDownloadListModel>();

            output("INFO", "建立遊戲資料");
            var dir = gb.PathJoin(DATA_FOLDER, "assets/objects");
            Directory.CreateDirectory(dir);

            JObject obj = JsonConvert.DeserializeObject<JObject>(gameAssetJson);
            var _resource_url = "https://resources.download.minecraft.net/%hash_prefix%/%hash%";
            var index = 0;

            JObject res = (JObject)JsonConvert.DeserializeObject(obj["objects"].ToString());

            int total = res.Count;
            progressBar.Maximum = total;
            TaskbarManager.Instance.SetProgressValue(0, total, Handle);

            foreach (var r in res)
            {
                if (isClosed) return;

                if (!checkFile)
                {
                    if (File.Exists(INSTALLED_PATH)) continue;
                    if (customVer != null) continue;
                }

                index++;

                var hash_prefix = r.Value["hash"].ToString().Substring(0, 2);
                var hash = r.Value["hash"].ToString();
                var resource_url = _resource_url.Replace("%hash_prefix%", hash_prefix).Replace("%hash%", hash);

                var cPath = gb.PathJoin(dir, hash_prefix, hash);
                Directory.CreateDirectory(gb.PathJoin(dir, hash_prefix));

                var sha_remote = r.Value["hash"].ToString();
                var sha_local = (File.Exists(cPath)) ? gb.SHA1(File.ReadAllBytes(cPath)) : "";

                if (!File.Exists(cPath) || sha_local != sha_remote)
                {
                    if (sha_local.Length > 0 && sha_remote != sha_local) output("WARN", $"雜湊值驗證失敗 {r.Key}");

                    if (gb.isConcurrent)
                    {
                        ConcurrentDownloadListModel cdlm = new ConcurrentDownloadListModel();
                        cdlm.uid = r.Key;
                        cdlm.id = r.Key;
                        cdlm.url = resource_url;
                        cdlm.path = cPath;
                        cdlm.size = 0;
                        cdlm.totSize = int.Parse(r.Value["size"].ToString());
                        indexObj.Add(cdlm);

                        if (!concurrentNowSize.ContainsKey(r.Key))
                            concurrentNowSize.Add(r.Key, cdlm);

                        concurrentTotalSize += int.Parse(r.Value["size"].ToString());
                        output("INFO", $"索引遊戲資料... ({index}/{total}) {r.Key}");
                    }
                    else
                    {
                        output("INFO", $"下載遊戲資料... ({index}/{total}) {r.Key}");
                        await launcher.downloadResource(resource_url, cPath);
                    }
                }
                else
                {
                    output("INFO", $"檢查遊戲資料... ({index}/{total}) {r.Key}");
                }

                if (r.Key.StartsWith("icons/") && !chkConcurrent.Checked)
                {
                    Directory.CreateDirectory(gb.PathJoin(DATA_FOLDER, "assets", "icons"));
                    File.Copy(cPath, gb.PathJoin(DATA_FOLDER, "assets", r.Key), true);
                }

                progressBar.Value = index;

                if (!isClosed)
                    TaskbarManager.Instance.SetProgressValue(index, total, Handle);

                await Task.Delay(gb.runInterval);
            }

            if (indexObj.Count > 0)
            {
                output("INFO", $"準備並行下載遊戲資料...");
                var SortedIndexObj = indexObj.OrderByDescending(o => o.totSize).ToList();


                progressBar.Value = 0;
                progressBar.Maximum = concurrentTotalSize;
                //timerConcurrent.Enabled = true;

                for (int i = 0; i < SortedIndexObj.Count; i += 200)
                {
                    Console.WriteLine($"indexing: {i}");
                    concurrentTotalCompleted = 0;

                    var indexList = SortedIndexObj.GetRange(i, (SortedIndexObj.Count - i < 200) ? SortedIndexObj.Count - i : 200);
                    foreach (var item in indexList)
                    {
                        onThreadDownloader(item.url, item.path, item.id, item.uid);
                    }



                    while (concurrentTotalCompleted != indexList.Count)
                    {
                        await Task.Delay(500);
                        Console.WriteLine($"while ticked: {concurrentTotalCompleted}/{indexList.Count}");
                    }
                }

                timerConcurrent.Enabled = false;
                await Task.Delay(100);
                UpdateDownloadState();
            }

            if (!checkFile)
                onUnzipped();
            else
            {
                output("INFO", "檢查完畢");
                settingAllControl(true);

                if (!isClosed)
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress, Handle);
            }
        }
        private void onUnzipped()
        {
            if (isClosed) return;

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate, Handle);
            gb.startupParms.startupUID = Guid.NewGuid().ToString();
            output("INFO", "解壓縮動態函數庫");
            var dir = gb.PathJoin(DATA_FOLDER, "bin", gb.startupParms.startupUID);
            Directory.CreateDirectory(dir);

            var nativesPath = new List<string>();
            foreach (var n in nativesList)
            {
                nativesPath.Add(n.Value.dir);
            }

            var isException = false;
            var index = nativesPath.Count;
            foreach (var np in nativesPath)
            {
                if (isClosed) return;
                try
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
                }
                catch (Exception exx)
                {
                    output("ERROR", exx.Message);
                    isException = true;
                }

                index--;
            }

            if (isException)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error, Handle);

                MessageBox.Show("解壓縮過程發生例外狀況，請嘗試檢查資料完整性以解決此錯誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                settingAllControl(true);
                progressBar.Style = ProgressBarStyle.Blocks;
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress, Handle);
            }
            else
                preVersionSupport();
        }

        private void preVersionSupport()
        {
            if (isClosed) return;

            // 舊版本(pre-1.6)會因為語言選項的大小寫問題導致遊戲崩潰
            output("INFO", "正在相容舊版本");
            CultureInfo ci = CultureInfo.CurrentUICulture;
            string lang = ci.Name;

            string dir;
            if (gb.currentInstance.lastname != null && gb.currentInstance.lastname.Length > 0)
            {
                dir = gb.PathJoin(gb.currentInstance.lastname, "options.txt");
            }
            else
            {
                dir = gb.PathJoin(DATA_FOLDER, "options.txt");
            }

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
            if (isClosed) return;

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate, Handle);
            progressBar.Style = ProgressBarStyle.Marquee;
            output("INFO", "啟動遊戲");

            var assetsDir = gb.PathJoin(DATA_FOLDER, "assets");
            var gameDir = (gb.currentInstance.lastname.Length == 0) ? DATA_FOLDER : gb.currentInstance.lastname;

            var cDir = gb.PathJoin(DATA_FOLDER, "versions", gb.startupParms.version, gb.startupParms.version + ".jar");
            if (customVer != null && !File.Exists(cDir))
            {
                // 非原版客戶端時，試圖尋找原版客戶端資訊
                if (customVer["jar"] != null)
                    cDir = gb.PathJoin(DATA_FOLDER, "versions", customVer["jar"].ToString(), customVer["jar"].ToString() + ".jar");
                else
                    cDir = gb.PathJoin(DATA_FOLDER, "versions", customVer["inheritsFrom"].ToString(), customVer["inheritsFrom"].ToString() + ".jar");
            }

            var librariesPath = new List<string>();


            // 將版本資訊寫入 launcher_profiles 目的是為了相容模組安裝程式的判斷式
            var hash = gb.SHA1(File.ReadAllBytes(cDir));
            var profiles_path = gb.PathJoin(DATA_FOLDER, "launcher_profiles.json");

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
            jvm.Add("-Djava.library.path=" + gb.PathJoin(DATA_FOLDER, "bin", gb.startupParms.startupUID));

            if (gb.usingMaxMemoryUsage && gb.maxMemoryUsage > 0)
                jvm.Add($"-Xmx{gb.maxMemoryUsage}m");

            if (gb.startupParms.loggerIndex != null)
                jvm.Add("-Dlog4j.configurationFile=" + gb.PathJoin(assetsDir, "log-configs", gb.startupParms.loggerIndex));

            replaceOptions.Add("${auth_player_name}", gb.startupParms.username);
            replaceOptions.Add("${version_name}", gb.startupParms.version);
            replaceOptions.Add("${game_directory}", gameDir);
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

            string javaPath = gb.PathJoin(DATA_FOLDER, "runtimes", gb.startupParms.javaRuntime, "bin", "java.exe");
            string startupParms = "";

            startupParms += String.Join(" ", jvm) + " ";

            if (gb.currentInstance.jvmParms != null && gb.currentInstance.jvmParms.Length > 0)
                startupParms += gb.currentInstance.jvmParms + " ";

            startupParms += String.Join(" ", classPath) + " ";


            // 非原版客戶端的JVM啟動參數，附加於主要類別載入之前、ClassPath 之後
            if (customVer != null && customVer["arguments"] != null && customVer["arguments"]["jvm"] != null)
            {
                List<string> cJvmList = new List<string>();
                JObject replaceOptionsCustom = new JObject();
                JArray customJvm = (JArray)customVer["arguments"]["jvm"];
                replaceOptionsCustom.Add("${version_name}", customVer["inheritsFrom"].ToString());
                replaceOptionsCustom.Add("${library_directory}", gb.PathJoin(DATA_FOLDER, "libraries"));
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

                    if (cJvm.Split('=').Length > 1 && cJvm.Split('=')[1].StartsWith(" ") && cJvm.EndsWith(" "))
                        cJvmList.Add('"' + cJvm + '"');
                    else
                        cJvmList.Add(cJvm);
                }


                startupParms += String.Join(" ", cJvmList) + " ";
            }


            startupParms += gb.startupParms.main + " ";
            startupParms += builder.ToString();

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = (gb.currentInstance.javaPath != null && gb.currentInstance.javaPath.Length > 0) ? gb.currentInstance.javaPath : javaPath;
            startInfo.Arguments = startupParms;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.WorkingDirectory = gameDir;
            startInfo.StandardOutputEncoding = Encoding.UTF8;

            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.EnableRaisingEvents = true;

            var installedPath = gb.PathJoin(DATA_FOLDER, "versions", textVersionSelected.Text, "installed.");
            if (!File.Exists(installedPath))
            {
                File.WriteAllText(installedPath, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            }

            try
            {
                GC.Collect();

                bool readyToExited = false;
                progressBar.Value = progressBar.Maximum;

                EventHandler handler = null;
                handler = (o, e) =>
                {
                    var result = MessageBox.Show("將遊戲立即強制結束，確定要繼續？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        proc.Kill();
                        trayIcon.ContextMenuStrip.Items[trayIcon.ContextMenuStrip.Items.Count - 2].Enabled = false;
                        trayIcon.ContextMenuStrip.Items[trayIcon.ContextMenuStrip.Items.Count - 2].Click -= handler;
                    }
                };


                proc.Exited += (sender, e) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        if (!this.IsDisposed)
                            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress, Handle);

                        progressBar.Style = ProgressBarStyle.Blocks;
                        output("INFO", "關閉遊戲");
                        Directory.Delete(gb.PathJoin(DATA_FOLDER, "bin", gb.startupParms.startupUID), true);
                        settingAllControl(true);

                        this.ShowInTaskbar = true;
                        this.WindowState = FormWindowState.Normal;
                        this.Activate();
                        trayIcon.Visible = false;
                        trayIcon.ContextMenuStrip.Items[trayIcon.ContextMenuStrip.Items.Count - 2].Enabled = false;
                        trayIcon.ContextMenuStrip.Items[trayIcon.ContextMenuStrip.Items.Count - 2].Click -= handler;
                    }));
                    GC.Collect();
                };


                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                proc.OutputDataReceived += OutputDataReceivedHandler;
                proc.ErrorDataReceived += ErrorDataReceivedHandler;

                trayIcon.ContextMenuStrip.Items[trayIcon.ContextMenuStrip.Items.Count - 2].Enabled = true;
                trayIcon.ContextMenuStrip.Items[trayIcon.ContextMenuStrip.Items.Count - 2].Click += handler;

                settingAllControl(false, true);

                // 舊版本(pre-1.6)會在遊戲關閉時依附於啟動器之下，導致無法完全關閉，此時需要強制結束處理程序
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

                // 當要關閉啟動器時且遊戲仍在執行時的提醒
                this.FormClosing += (sender, e) =>
                {
                    if (!proc.HasExited)
                    {
                        var result = MessageBox.Show("關閉啟動器會導致遊戲結束時不會自動清除暫存檔案，您確定要關閉嗎？", "說明", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            if (trayIcon != null)
                            {
                                this.ShowInTaskbar = true;
                                this.WindowState = FormWindowState.Normal;
                                trayIcon.Visible = false;
                            }
                        }
                    }
                };


                // 取得JVM啟動例外狀況訊息，並在處理程序結束後跳出視窗提醒
                string JVMErr = "";
                proc.ErrorDataReceived += (sender, e) =>
                {
                    if (e.Data != null && gb.startupParms.loggerIndex != null)
                    {
                        var data = e.Data.Trim();
                        JVMErr += data + Environment.NewLine;
                    };
                };

                proc.Exited += (sender, e) =>
                {
                    if (JVMErr.Length > 0)
                    {
                        MessageBox.Show(JVMErr, "JVM 啟動過程發生錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        private void ErrorDataReceivedHandler(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
            {
                var data = args.Data.Trim();

                this.Invoke(new Action(() =>
                {
                    outputDebug("JVM", data);
                }));
            }
        }

        private void OutputDataReceivedHandler(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
            {
                var data = args.Data.Trim();
                if (data == null || data.Length == 0) return;

                data = Regex.Replace(data, @"<log4j:(.*?)>(.*?)", "$2");
                data = Regex.Replace(data, @"(.*?)</log4j:(.*?)>", "$1");
                data = Regex.Replace(data, @"<!\[CDATA\[(.*?)\]\]>", "$1");

                if (!data.StartsWith("[CHAT]"))
                {
                    data = Regex.Replace(data, @"<!\[CDATA\[(.*?)", "$1");
                    data = Regex.Replace(data, @"(.*?)\]\]>", "$1");
                }

                if (data != null && data.Length > 0 && !data.Contains(gb.startupParms.accessToken))
                {
                    this.Invoke(new Action(() =>
                    {
                        outputDebug("GAME", data);
                    }));
                }

                if (progressBar.Style != ProgressBarStyle.Blocks)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.WindowState = FormWindowState.Minimized;
                        this.ShowInTaskbar = false;
                        trayIcon.Visible = true;
                        progressBar.Style = ProgressBarStyle.Blocks;

                        if (!this.IsDisposed)
                            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress, Handle);
                    }));
                }
            }
            else
            {
                Console.WriteLine(args.Data);
            }
        }
    }
}
