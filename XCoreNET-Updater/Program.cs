using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace xcorenet_updater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("載入自我更新程式...");
            getVersion().Wait();
        }
        static async Task getVersion() {
            try
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
                string UpdaterPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

                var versionInfo = FileVersionInfo.GetVersionInfo(@UpdaterPath + Path.DirectorySeparatorChar + "XCoreNET.exe");
                Version versionLocal = new Version(versionInfo.ProductVersion);
                Version versionRemote = new Version(latestURL.Split(new string[] { "/releases/tag/" }, StringSplitOptions.None)[1].Replace("v", string.Empty));

                Console.WriteLine($"更新檔網路位址: {latestURL}");
                Console.WriteLine($"自我更新程式位址: {UpdaterPath}");
                Console.WriteLine($"本機應用程式版本: {versionLocal} \t 遠端應用程式版本: {versionRemote}");

                var compareResult = versionRemote.CompareTo(versionLocal);

                if (compareResult > 0)
                {
                    string downloadURL = $"https://github.com/SN-Koarashi/XCoreNET/releases/download/v{versionRemote}/XCoreNET-SFXInstaller.exe";
                    Console.WriteLine($"準備下載更新檔案，請勿關閉程式");
                    Console.WriteLine($"下載位址: {downloadURL}");
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(downloadURL, "XCoreNET-installer-temp.exe");
                    }

                    Console.WriteLine($"下載完成，準備安裝...");
                    List<string> cmdLine = new List<string>();
                    cmdLine.Add("@echo off");
                    cmdLine.Add($"CD {UpdaterPath}");
                    cmdLine.Add($"start /wait XCoreNET-installer-temp.exe /S /D={UpdaterPath}");
                    cmdLine.Add("start XCoreNET.exe");
                    File.WriteAllLines(Path.GetFullPath(UpdaterPath + "/patcher.bat"), cmdLine);

                    System.Diagnostics.Process.Start("patcher.bat");
                    Environment.Exit(0);
                }

            }
            catch (Exception exx) {
                Console.WriteLine($"程式於執行階段發生錯誤: {exx.ToString()}");
                Console.WriteLine($"按下任意鍵關閉程式");
                Console.ReadKey();
            }
        }

    }
}
