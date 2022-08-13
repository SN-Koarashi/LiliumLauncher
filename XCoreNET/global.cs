using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Global
{
    class gb
    {
        private static DateTime JanFirst1970 = new DateTime(1970, 1, 1);
        public static bool verOptRelease = true;
        public static bool verOptSnapshot = false;
        public static bool firstStart = false;
        public static bool isMainFolder = true;
        public static string azureToken = "";
        public static string launchToken = "";
        public static string refreshToken = "";
        public static long launchTokenExpiresAt = 0;
        public static string minecraftUUID = "";
        public static string minecraftUsername = "";
        public static string lastVersionID = "";
        public static Point windowSize = new Point(480, 360);
        public static int runInterval = 1;
        public static Uri mainHomepage = new Uri("https://www.snkms.com/chat/webchat2/");
        public static Uri launcherHomepage = new Uri("https://www.snkms.com/minecraftNews.html");
        public static int maxMemoryUsage = 0;
        public static bool usingMaxMemoryUsage = false;
        public static bool isConcurrent = false;

        public class startupParms
        {
            public static string main { get; set; }
            public static string username { get; set; }
            public static string uuid { get; set; }
            public static string accessToken { get; set; }
            public static string version { get; set; }
            public static string assetIndex { get; set; }
            public static string loggerIndex { get; set; }
            public static string javaRuntime { get; set; }
            public static string minecraftArguments { get; set; }
            public static string appUID { get; set; }
        }

        public readonly static string azureClientID = "c5a69008-2ee1-403f-aa2a-3d324e0213d7";


        public static string getMicrosoftOAuthURL()
        {
            string microsoftOAuthURL = "https://login.live.com/oauth20_authorize.srf?" +
                $"client_id={azureClientID}" +
                "&response_type=code&scope=XboxLive.signin%20offline_access" +
                "&redirect_uri=http%3A%2F%2Flocalhost%3A5026" +
                "&cobrandid=8058f65d-ce06-4c30-9559-473c9275a65d&prompt=select_account";

            return microsoftOAuthURL;
        }
        public static long getNowMilliseconds()
        {
            return (long)((DateTime.Now.ToUniversalTime() - JanFirst1970).TotalMilliseconds + 0.5);
        }
        public static void resetTokens()
        {
            azureToken = "";
            launchToken = "";
            refreshToken = "";
            launchTokenExpiresAt = 0;
            minecraftUUID = "";
            minecraftUsername = "";
        }
        public static void resetStartupParms()
        {
            startupParms.assetIndex = null;
            startupParms.minecraftArguments = null;
            startupParms.loggerIndex = null;
            startupParms.main = null;
            startupParms.version = null;
            startupParms.appUID = null;
        }
        public static void savingSession()
        {
            var content = new
            {
                launcher = new
                {
                    token = launchToken,
                    expires_at = launchTokenExpiresAt,
                    maxMemoryUsage = maxMemoryUsage,
                    usingMaxMemoryUsage = usingMaxMemoryUsage
                },
                minecraft = new
                {
                    username = minecraftUsername,
                    uuid = minecraftUUID
                },
                versionOptions = new
                {
                    release = verOptRelease,
                    snapshot = verOptSnapshot
                },
                refreshToken = refreshToken,
                isMainFolder = isMainFolder,
                lastVersionID = lastVersionID,
                windowSize = $"{windowSize.X},{windowSize.Y}",
                runInterval = runInterval,
                isConcurrent = isConcurrent
            };

            Directory.CreateDirectory("settings");
            File.WriteAllText($"settings{Path.DirectorySeparatorChar}launcher_settings.json", JsonConvert.SerializeObject(content));
            Console.WriteLine("儲存工作階段資料");
        }
        public static void readingSession()
        {
            string path = $"settings{Path.DirectorySeparatorChar}launcher_settings.json";
            if (File.Exists(path))
            {
                var content = File.ReadAllText(path);
                var result = JsonConvert.DeserializeObject<SessionModel>(content);

                isConcurrent = result.isConcurrent;
                isMainFolder = result.isMainFolder;
                refreshToken = result.refreshToken;
                launchToken = GetValueOrDefault<string, object, string>(result.launcher, "token", launchToken);
                launchTokenExpiresAt = GetValueOrDefault<string, object, long>(result.launcher, "expires_at", launchTokenExpiresAt);
                minecraftUsername = GetValueOrDefault<string, object, string>(result.minecraft, "username", minecraftUsername);
                minecraftUUID = GetValueOrDefault<string, object, string>(result.minecraft, "uuid", minecraftUUID);
                verOptRelease = GetValueOrDefault<string, object, bool>(result.versionOptions, "release", verOptRelease);
                verOptSnapshot = GetValueOrDefault<string, object, bool>(result.versionOptions, "snapshot", verOptSnapshot);

                maxMemoryUsage = Convert.ToInt32(GetValueOrDefault<string, object, long>(result.launcher, "maxMemoryUsage", long.Parse(maxMemoryUsage.ToString())));
                usingMaxMemoryUsage = GetValueOrDefault<string, object, bool>(result.launcher, "usingMaxMemoryUsage", usingMaxMemoryUsage);

                lastVersionID = result.lastVersionID;
                runInterval = (result.runInterval >= 0) ? result.runInterval : 1;

                if (result.windowSize != null) windowSize = new Point(int.Parse(result.windowSize.Split(',')[0]), int.Parse(result.windowSize.Split(',')[1]));

                Console.WriteLine("讀取工作階段資料");
            }
        }

        public static TOutput GetValueOrDefault<TKey, TValue, TOutput>(Dictionary<TKey, TValue> dictionary, TKey key, TOutput defaultValue)
        {
            if (dictionary != null && dictionary.ContainsKey(key))
            {
                if (typeof(TValue) is object)
                {
                    return TryGenericParse<TOutput>(dictionary[key], defaultValue);
                }
                else
                {
                    return TryGenericParse<TValue, TOutput>(dictionary[key], defaultValue);
                }
            }
            else
                return defaultValue;
        }

        // ref https://stackoverflow.com/questions/23547637/generic-parsing-with-default-value
        public static TOuput TryGenericParse<TOuput>(object input, TOuput outputDefault)
        {
            if (input == null)
                return outputDefault;

            return (TOuput)input;
        }
        public static TOuput TryGenericParse<TInput, TOuput>(TInput input, TOuput outputDefault)
        {
            var converter = TypeDescriptor.GetConverter(typeof(TInput));
            Console.WriteLine(input);

            if (!converter.CanConvertTo(typeof(TOuput)))
                return outputDefault;

            return (TOuput)converter.ConvertTo(input, typeof(TOuput));
        }


        public static async void checkForUpdate()
        {
            string hostUrl = "https://github.com/SN-Koarashi/XCoreNET/releases/latest";
            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = false
            };
            var httpClient = new HttpClient(handler);
            HttpRequestMessage request = new HttpRequestMessage
            {
                RequestUri = new Uri(hostUrl),
                Method = HttpMethod.Head
            };

            var result = await httpClient.SendAsync(request);
            string latestURL = result.Headers.Location.AbsoluteUri;
            string UpdaterPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            var versionInfo = FileVersionInfo.GetVersionInfo(@UpdaterPath + Path.DirectorySeparatorChar + "XCoreNET.exe");
            Version versionLocal = new Version(versionInfo.ProductVersion);
            Version versionRemote = new Version(latestURL.Split(new string[] { "/releases/tag/" }, StringSplitOptions.None)[1].Replace("v", string.Empty));


            Console.WriteLine($"本機應用程式版本: {versionLocal}");
            Console.WriteLine($"遠端應用程式版本: {versionRemote}");

            var compareResult = versionRemote.CompareTo(versionLocal);
            if (compareResult > 0)
            {
                var resultUpdate = MessageBox.Show("有新的應用程式版本可用，是否執行更新？", "說明", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultUpdate == DialogResult.Yes)
                {
                    var p = new Process();
                    p.StartInfo.FileName = UpdaterPath + Path.DirectorySeparatorChar + "XCoreNET-Updater.exe";  // just for example, you can use yours.
                    p.Start();
                    Application.Exit();
                }
            }
            else
            {
                if (!firstStart)
                {
                    firstStart = true;
                    string tempFileInstaller = UpdaterPath + Path.DirectorySeparatorChar + "XCoreNET-installer-temp.exe";
                    string tempFilePatcher = UpdaterPath + Path.DirectorySeparatorChar + "patcher.bat";
                    if (File.Exists(tempFileInstaller))
                        File.Delete(tempFileInstaller);
                    if (File.Exists(tempFilePatcher))
                        File.Delete(tempFilePatcher);
                }
                else
                    MessageBox.Show("應用程式已為最新版本", "說明", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static int CompareVersionStrings(string v1, string v2)
        {
            int rc = -1000;

            v1 = v1.ToLower();
            v2 = v2.ToLower();

            if (v1 == v2)
                return 0;

            string[] v1parts = v1.Split('.');
            string[] v2parts = v2.Split('.');

            for (int i = 0; i < v1parts.Length; i++)
            {
                if (v2parts.Length < i + 1)
                    break; // we're done here

                rc = String.Compare(v1parts[i], v2parts[i], StringComparison.Ordinal);
                if (rc != 0)
                    break;
            }

            if (rc == 0)
            {
                // catch this scenario: v1="1.0.1" v2="1.0"
                if (v1parts.Length > v2parts.Length)
                    rc = 1; // v1 is higher version than v2
                            // catch this scenario: v1="1.0" v2="1.0.1"
                else if (v2parts.Length > v1parts.Length)
                    rc = -1; // v1 is lower version than v2
            }

            if (rc == 0 || rc == -1000)
                return rc;
            else
                return rc < 0 ? -1 : 1;
        }
        private class SessionModel
        {
            public Dictionary<string, object> launcher { get; set; }
            public Dictionary<string, object> minecraft { get; set; }
            public Dictionary<string, object> versionOptions { get; set; }
            public string refreshToken { get; set; }
            public bool isMainFolder { get; set; }
            public string lastVersionID { get; set; }
            public string windowSize { get; set; }
            public int runInterval { get; set; }
            public bool isConcurrent { get; set; }

        }
        public class ProgramModel
        {
            public bool noWevView { get; set; }
            public bool launcher { get; set; }
            public string mainURL { get; set; }
            public string launcherURL { get; set; }
        }
        public static string SHA1(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString().ToLower();
            }
        }
        public static string SHA1(byte[] input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(input);
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString().ToLower();
            }
        }
    }
    static class Instance_Method
    {
        // ref https://stackoverflow.com/questions/4335878/c-sharp-trimstart-with-string-parameter
        public static string TrimStart(this string target, string trimString)
        {
            if (string.IsNullOrEmpty(trimString)) return target;

            string result = target;
            while (result.StartsWith(trimString))
            {
                result = result.Substring(trimString.Length);
            }

            return result;
        }
        public static string TrimEnd(this string target, string trimString)
        {
            if (string.IsNullOrEmpty(trimString)) return target;

            string result = target;
            while (result.EndsWith(trimString))
            {
                result = result.Substring(0, result.Length - trimString.Length);
            }

            return result;
        }
    }
}
