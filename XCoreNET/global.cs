using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static XCoreNET.ClassModel.globalModel;
using static XCoreNET.ClassModel.launcherModel;
using static XCoreNET.ClassModel.locateModel;

namespace Global
{
    class gb
    {
        private static DateTime JanFirst1970 = new DateTime(1970, 1, 1);
        public readonly static string azureClientID = "c5a69008-2ee1-403f-aa2a-3d324e0213d7";
        public readonly static string appUID = Guid.NewGuid().ToString();
        public readonly static long startUnixTime = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
        public static bool isCheckUpdate = true;
        public static bool httpUsing = false;
        public static bool verOptRelease = true;
        public static bool verOptSnapshot = false;
        public static bool verOptLoader = false;
        public static bool firstStart = false;
        public static bool? verStatusFilter = null;
        public static List<string> instance = new List<string>();
        public static string loginMethod = "default";
        public static string mainFolderName = ".minecraft-xcorenet";
        public static string mainFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + mainFolderName;
        public static readonly string mainFolderDefault = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + mainFolderName;
        public static string azureToken = "";
        public static string launchToken = "";
        public static string refreshToken = "";
        public static long launchTokenExpiresAt = 0;
        public static string minecraftUUID = "";
        public static string minecraftUsername = "";
        public static string lastVersionID = "";
        public static string langCode = "";
        public static int runInterval = 0;
        public static Uri mainHomepage = new Uri("https://www.snkms.com/chat/webchat2/");
        public static Uri launcherHomepage = new Uri("https://www.snkms.com/minecraftNews.html");
        public static int maxMemoryUsage = 0;
        public static bool usingMaxMemoryUsage = false;
        public static bool isConcurrent = true;
        public static bool isSaveLogFile = false;
        public static Dictionary<string, AccountModel> account = new Dictionary<string, AccountModel>();
        public static Dictionary<string, InstanceModel> allInstance = new Dictionary<string, InstanceModel>();
        public static startupParmsModel startupParms = new startupParmsModel();
        public static InstanceModel currentInstance = new InstanceModel();
        public static List<VersionListModel> versionListModels = new List<VersionListModel>();
        public static List<string> versionNameList = new List<string>();
        public static List<string> versionNameInstalledList = new List<string>();
        public static translateModel lang = new translateModel();
        public static TabPage hideTabPage = null;

        public static void setTranslate()
        {
            try
            {
                string path = $"locates{Path.DirectorySeparatorChar}translate{Path.DirectorySeparatorChar}{langCode}.json";
                if (File.Exists(path))
                {
                    var data = File.ReadAllText(path);
                    var result = JsonConvert.DeserializeObject<translateModel>(data);
                    lang = result;
                }
                else
                {
                    path = $"locates{Path.DirectorySeparatorChar}translate{Path.DirectorySeparatorChar}en-US.json";
                    var data = File.ReadAllText(path);
                    var result = JsonConvert.DeserializeObject<translateModel>(data);
                    lang = result;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Locate Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

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

        public static void resetTokens(string uuid)
        {
            if (account.ContainsKey(uuid))
                account.Remove(uuid);
        }
        public static void resetTokens()
        {
            if (account.ContainsKey(minecraftUUID))
                account.Remove(minecraftUUID);

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
            startupParms.startupUID = null;
        }
        public static void savingSession(bool isSync)
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
                    snapshot = verOptSnapshot,
                    loader = verOptLoader
                },
                verStatusFilter = verStatusFilter,
                currentInstance = currentInstance,
                allInstance = allInstance,
                account = account,
                refreshToken = refreshToken,
                mainFolder = mainFolder,
                lastVersionID = lastVersionID,
                runInterval = runInterval,
                isConcurrent = isConcurrent
            };

            Directory.CreateDirectory("settings");

            var tasker = Task.Run(() =>
            {
                try
                {
                    var jsonData = JsonConvert.SerializeObject(content);
                    byte[] Key = Encoding.ASCII.GetBytes(SHA256(getWMIC("csproduct get UUID")).Substring(0, 32));
                    byte[] IV = Encoding.ASCII.GetBytes(SHA256(getWMIC("baseboard get serialnumber")).Substring(32, 16));
                    byte[] encrypted = EncryptToAES(jsonData, Key, IV);

                    File.WriteAllBytes($"settings{Path.DirectorySeparatorChar}launcher_settings.bin", encrypted);
                    Console.WriteLine("儲存工作階段資料: Done");
                }
                catch (Exception exx)
                {
                    Console.WriteLine(exx.Message);
                }
            });

            if (isSync)
                tasker.Wait();

            Console.WriteLine("儲存工作階段資料");
        }
        public static void readingSession()
        {
            string path = $"settings{Path.DirectorySeparatorChar}launcher_settings.bin";
            if (File.Exists(path))
            {
                try
                {
                    byte[] byteData = File.ReadAllBytes(path);
                    byte[] Key = Encoding.ASCII.GetBytes(SHA256(getWMIC("csproduct get UUID")).Substring(0, 32));
                    byte[] IV = Encoding.ASCII.GetBytes(SHA256(getWMIC("baseboard get serialnumber")).Substring(32, 16));
                    string decrypted = DecryptFromAES(byteData, Key, IV);

                    var result = JsonConvert.DeserializeObject<SessionModel>(decrypted);

                    isConcurrent = result.isConcurrent;
                    verStatusFilter = result.verStatusFilter;
                    mainFolder = (result.mainFolder != null) ? result.mainFolder : mainFolder;
                    refreshToken = result.refreshToken;
                    launchToken = GetValueOrDefault<string, object, string>(result.launcher, "token", launchToken);
                    launchTokenExpiresAt = GetValueOrDefault<string, object, long>(result.launcher, "expires_at", launchTokenExpiresAt);
                    minecraftUsername = GetValueOrDefault<string, object, string>(result.minecraft, "username", minecraftUsername);
                    minecraftUUID = GetValueOrDefault<string, object, string>(result.minecraft, "uuid", minecraftUUID);
                    verOptRelease = GetValueOrDefault<string, object, bool>(result.versionOptions, "release", verOptRelease);
                    verOptSnapshot = GetValueOrDefault<string, object, bool>(result.versionOptions, "snapshot", verOptSnapshot);
                    verOptLoader = GetValueOrDefault<string, object, bool>(result.versionOptions, "loader", verOptLoader);
                    currentInstance = (result.currentInstance != null) ? result.currentInstance : currentInstance;
                    allInstance = (result.allInstance != null) ? result.allInstance : allInstance;

                    maxMemoryUsage = Convert.ToInt32(GetValueOrDefault<string, object, long>(result.launcher, "maxMemoryUsage", long.Parse(maxMemoryUsage.ToString())));
                    usingMaxMemoryUsage = GetValueOrDefault<string, object, bool>(result.launcher, "usingMaxMemoryUsage", usingMaxMemoryUsage);
                    account = (result.account != null) ? result.account : account;

                    lastVersionID = result.lastVersionID;
                    runInterval = (result.runInterval >= 0) ? result.runInterval : 1;



                    if (!account.ContainsKey(minecraftUUID) && minecraftUUID.Length > 0)
                    {
                        AccountModel am = new AccountModel();
                        am.username = minecraftUsername;
                        am.refreshToken = refreshToken;
                        am.accessToken = launchToken;
                        am.expiresAt = launchTokenExpiresAt;
                        am.lastUsed = new DateTime().ToString("yyyy-MM-dd HH:mm:ss");
                        account.Add(minecraftUUID, am);
                    }
                }
                catch (Exception exx)
                {
                    Console.WriteLine(exx.Message);
                }
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


        public static async void checkForUpdate(bool isForce)
        {
            if (!isCheckUpdate && !isForce)
            {
                Console.WriteLine("不執行更新檢查");
                firstStart = true;
                cleanTempFiles();
                return;
            }

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

            try
            {

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
                    var resultUpdate = MessageBox.Show(lang.DIALOG_APPLICATION_UPDATE_CONFIRM, lang.DIALOG_INFO, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultUpdate == DialogResult.Yes)
                    {
                        var p = new Process();
                        p.StartInfo.FileName = UpdaterPath + Path.DirectorySeparatorChar + "XCoreNET.exe";  // just for example, you can use yours.
                        p.StartInfo.Arguments = "-updater";
                        p.Start();
                        Application.Exit();
                    }
                }
                else
                {
                    if (!firstStart)
                    {
                        firstStart = true;
                        cleanTempFiles();
                    }
                    else
                        MessageBox.Show(lang.DIALOG_APPLICATION_LATEST, lang.DIALOG_INFO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show($"{lang.DIALOG_APPLICATION_CHECKING_UPDATE_ERROR}{exx.Message}", lang.DIALOG_INFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void cleanTempFiles()
        {
            string UpdaterPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string tempFileInstaller = UpdaterPath + Path.DirectorySeparatorChar + "XCoreNET-installer-temp.exe";
            string tempFilePatcher = UpdaterPath + Path.DirectorySeparatorChar + "patcher.bat";
            if (File.Exists(tempFileInstaller))
                File.Delete(tempFileInstaller);
            if (File.Exists(tempFilePatcher))
                File.Delete(tempFilePatcher);
        }

        public static string PathJoin(params string[] args)
        {
            string[] result = args.Select(x => x.Replace('/', Path.DirectorySeparatorChar)).ToArray();
            return Path.GetFullPath(String.Join(Path.DirectorySeparatorChar.ToString(), result));
        }

        // 取得作業系統名稱
        public static string getPlatform(bool isNative)
        {
            return isNative ? "natives-windows" : "windows-x64";
        }

        // 取得作業系統名稱
        public static string getPlatformFriendly()
        {
            return "windows";
        }

        public static int DropDownWidth(ComboBox myCombo)
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

        public static string getBrowserLoginHTML()
        {
            string html =
                "<html>" +
                    "<head>" +
                        "<title>OAuth Window</title>" +
                        "<meta charset=\"utf-8\" />" +
                        "<style>div{position: fixed;top: 40%;transform: translateY(-50%);left: 0px;right: 0px;}h1{margin: 0px;}</style>" +
                        "<script>window.history.pushState(null, document.title, \" /? type = session_closed\");" +
                        "setTimeout(()=>{location.replace(\"about: blank\");},1500);" +
                        "</script>" +
                    "</head>" +
                    "<body>" +
                        "<div align=\"center\">" +
                            $"<h1>{lang.HTML_OAUTH_COMPLETE}</h1>" +
                        "</div>" +
                    "</body>" +
                "</html>";

            return html;
        }

        public static string getDateTimeWithAD()
        {
            DateTime utcDateTime = DateTime.UtcNow;
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, localTimeZone);

            return localDateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        // https://stackoverflow.com/questions/7568147/compare-version-numbers-without-using-split-function
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

                string v1Token = v1parts[i];
                string v2Token = v2parts[i];

                int x;
                bool v1Numeric = int.TryParse(v1Token, out x);
                bool v2Numeric = int.TryParse(v2Token, out x);

                // handle scenario {"2" versus "20"} by prepending zeroes, e.g. it would become {"02" versus "20"}
                if (v1Numeric && v2Numeric)
                {
                    while (v1Token.Length < v2Token.Length)
                        v1Token = "0" + v1Token;
                    while (v2Token.Length < v1Token.Length)
                        v2Token = "0" + v2Token;
                }

                rc = String.Compare(v1Token, v2Token, StringComparison.Ordinal);
                //Console.WriteLine("v1Token=" + v1Token + " v2Token=" + v2Token + " rc=" + rc);
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

        public static bool CheckForInternetConnection(int timeoutMs = 2000, string url = null)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = SHA1(Guid.NewGuid().ToString()).Substring(0, 32);
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 3;

            try
            {
                PingReply reply = pingSender.Send("8.8.8.8", timeout, buffer, options);
                return reply.Status == IPStatus.Success;
            }
            catch (Exception exx)
            {
                Console.WriteLine(exx.Message);
                return false;
            }
        }
        public static string getWMIC(string command)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "wmic.exe",
                    Arguments = command,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            string line = "";
            while (!proc.StandardOutput.EndOfStream)
            {
                line += (line.Length > 0 ? "-----" : "") + proc.StandardOutput.ReadLine();
            }

            proc.WaitForExit();

            return line;
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

        public static string SHA256(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] hash = System.Security.Cryptography.SHA256.Create().ComputeHash(bytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }

            return builder.ToString();
        }

        public static byte[] EncryptToAES(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public static string DecryptFromAES(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
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
