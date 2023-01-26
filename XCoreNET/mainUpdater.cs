using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XCoreNET
{
    public partial class mainUpdater : Form
    {
        int NowSize = 0;
        int TotalSize = 0;
        bool isClosed = false;
        static string UpdaterPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

        public mainUpdater()
        {
            InitializeComponent();
            checkUpdating();
        }

        private async void checkUpdating()
        {
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

                var versionInfo = FileVersionInfo.GetVersionInfo(@UpdaterPath + Path.DirectorySeparatorChar + "XCoreNET.exe");
                Version versionLocal = new Version(versionInfo.ProductVersion);
                Version versionRemote = new Version(latestURL.Split(new string[] { "/releases/tag/" }, StringSplitOptions.None)[1].Replace("v", string.Empty));
                Console.WriteLine($"更新檔網路位址: {latestURL}");
                Console.WriteLine($"自我更新程式位址: {UpdaterPath}");
                Console.WriteLine($"本機應用程式版本: {versionLocal} \t 遠端應用程式版本: {versionRemote}");

                label2.Text = "初始化下載...";
                progressBar1.Style = ProgressBarStyle.Continuous;

                var compareResult = versionRemote.CompareTo(versionLocal);
                if (compareResult > 0)
                {
                    string downloadURL = $"https://github.com/SN-Koarashi/XCoreNET/releases/download/v{versionRemote}/XCoreNET-SFXInstaller.exe";
                    Console.WriteLine($"準備下載更新檔案，請勿關閉程式");
                    Console.WriteLine($"下載位址: {downloadURL}");

                    label2.Text = "準備下載...";

                    WebClient client = new WebClient();

                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler((s, e) => client_DownloadProgressChanged(s, e));
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler((s, e) => client_DownloadFileCompleted(s, e));
                    client.DownloadFileAsync(new Uri(downloadURL), "XCoreNET-installer-temp.exe");
                }
                else
                {
                    isClosed = true;

                    label2.Text = "應用程式已為最新版本";
                    progressBar1.Value = 100;

                    await Task.Delay(1000);
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }
            }
            catch (Exception exx)
            {
                isClosed = true;

                label2.Text = "錯誤";
                MessageBox.Show(exx.ToString(), "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (isClosed) return;

            this.BeginInvoke((MethodInvoker)delegate
            {
                TotalSize = int.Parse(e.TotalBytesToReceive.ToString());
                NowSize = int.Parse(e.BytesReceived.ToString());

                label2.Text = $"正在下載... {NowSize}/{TotalSize} Bytes";

                // https://stackoverflow.com/questions/49507984/e-progresspercentage-returns-0-50
                //progressBar1.Value = e.ProgressPercentage;
                progressBar1.Value = (int)(e.BytesReceived / e.TotalBytesToReceive * 100);
                Application.DoEvents();
            });
        }
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (isClosed) return;

            this.BeginInvoke((MethodInvoker)delegate
            {
                if (e.Error == null && !e.Cancelled)
                {
                    outputDebug("INFO", $"下載完成，準備安裝...");
                    label2.Text = "準備安裝...";
                    progressBar1.Style = ProgressBarStyle.Marquee;

                    List<string> cmdLine = new List<string>();
                    cmdLine.Add("@echo off");
                    cmdLine.Add($"CD {UpdaterPath}");
                    cmdLine.Add($"start /wait XCoreNET-installer-temp.exe /S /D={UpdaterPath}");
                    cmdLine.Add("start XCoreNET.exe");
                    File.WriteAllLines(Path.GetFullPath(UpdaterPath + "/patcher.bat"), cmdLine);

                    Process p = new Process();
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.FileName = "patcher.bat";
                    p.Start();
                    Environment.Exit(0);
                }
                else
                {
                    if (e.Cancelled)
                    {
                        outputDebug("INFO", $"下載已取消");
                    }
                    else if (e.Error != null)
                    {
                        outputDebug("INFO", $"下載失敗: {e.Error}");
                        MessageBox.Show(e.Error.ToString(), "下載失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }
            });
        }

        private void outputDebug(string type, string content)
        {
            Console.WriteLine($"[{type}] {content}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isClosed = true;
            Environment.Exit(0);
        }

        private void mainUpdater_FormClosed(object sender, FormClosedEventArgs e)
        {
            isClosed = true;
        }
    }
}
