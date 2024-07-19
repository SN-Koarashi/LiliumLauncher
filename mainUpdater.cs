using Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiliumLauncher
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
                string hostUrl = "https://github.com/SN-Koarashi/LiliumLauncher/releases/latest";
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

                var versionInfo = FileVersionInfo.GetVersionInfo(@UpdaterPath + Path.DirectorySeparatorChar + "LiliumLauncher.exe");
                Version versionLocal = new Version(versionInfo.ProductVersion);
                Version versionRemote = new Version(latestURL.Split(new string[] { "/releases/tag/" }, StringSplitOptions.None)[1].Replace("v", string.Empty));
                Console.WriteLine($"更新檔網路位址: {latestURL}");
                Console.WriteLine($"自我更新程式位址: {UpdaterPath}");
                Console.WriteLine($"本機應用程式版本: {versionLocal} \t 遠端應用程式版本: {versionRemote}");

                label2.Text = gb.lang.LAB_INITIALIZING_DOWNLOAD;
                progressBar1.Style = ProgressBarStyle.Continuous;

                var compareResult = versionRemote.CompareTo(versionLocal);
                if (compareResult > 0)
                {
                    string downloadURL = $"https://github.com/SN-Koarashi/LiliumLauncher/releases/download/v{versionRemote}/LiliumLauncher-SFXInstaller.exe";
                    Console.WriteLine($"準備下載更新檔案，請勿關閉程式");
                    Console.WriteLine($"下載位址: {downloadURL}");

                    label2.Text = gb.lang.LAB_PREPARING_DOWNLOAD;

                    WebClient client = new WebClient();

                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler((s, e) => client_DownloadProgressChanged(s, e));
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler((s, e) => client_DownloadFileCompleted(s, e));
                    client.DownloadFileAsync(new Uri(downloadURL), "LiliumLauncher-installer-temp.exe");
                }
                else
                {
                    isClosed = true;

                    label2.Text = gb.lang.LAB_APPLICATION_LATEST;
                    progressBar1.Value = 100;

                    await Task.Delay(1000);
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }
            }
            catch (Exception exx)
            {
                isClosed = true;

                label2.Text = gb.lang.LAB_ERROR;
                MessageBox.Show(exx.ToString(), gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                label2.Text = $"{gb.lang.LAB_DOWNLOADING} {NowSize}/{TotalSize} Bytes";
                Console.WriteLine($"正在下載... {NowSize}/{TotalSize} Bytes");

                // https://stackoverflow.com/questions/49507984/e-progresspercentage-returns-0-50
                //progressBar1.Value = e.ProgressPercentage;
                double percent = (double)NowSize / (double)TotalSize * 100;

                progressBar1.Value = (int)Math.Floor(percent);
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
                    StartInstalling();
                }
                else
                {
                    if (e.Cancelled)
                    {
                        outputDebug("INFO", gb.lang.LOGGER_DOWNLOAD_CANCELED);
                    }
                    else if (e.Error != null)
                    {
                        outputDebug("INFO", $"{gb.lang.LOGGER_DOWNLOAD_FAILED}{e.Error}");
                        MessageBox.Show(e.Error.ToString(), gb.lang.LOGGER_DOWNLOAD_FAILED, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }
            });
        }

        private async void StartInstalling()
        {
            outputDebug("INFO", $"下載完成，準備安裝...");
            label2.Text = gb.lang.LAB_DOWNLOADED;
            await Task.Delay(650);
            label2.Text = gb.lang.LAB_PREPARING_INSTALL;
            progressBar1.Style = ProgressBarStyle.Marquee;

            await Task.Delay(1000);

            List<string> cmdLine = new List<string>();
            cmdLine.Add("@echo off");
            cmdLine.Add($"CD {UpdaterPath}");
            cmdLine.Add($"timeout 2");
            cmdLine.Add($"start /wait LiliumLauncher-installer-temp.exe /S /D={UpdaterPath}");
            cmdLine.Add("start LiliumLauncher.exe");
            File.WriteAllLines(Path.GetFullPath(UpdaterPath + "/patcher.bat"), cmdLine);

            Process p = new Process();
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = "patcher.bat";

            p.Start();
            Environment.Exit(0);
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

        private void mainUpdater_Load(object sender, EventArgs e)
        {
            this.Text = gb.lang.FORM_TITLE_UPDATER;
            button1.Text = gb.lang.BTN_CANCEL;
            label1.Text = gb.lang.LAB_UPDATING;
            label2.Text = gb.lang.LAB_INITIALIZING;
        }
    }
}
