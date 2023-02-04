using Global;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XCoreNET
{
    public partial class minecraftForm
    {
        private void onThreadDownloader(string url, string path, string filename, string UID)
        {
            if (isClosed) return;

            if (downloadingPath.IndexOf(path) != -1)
            {
                Console.WriteLine($"目標檔案正在下載，無須重複執行: {path}");
                FileWriteCompleted(UID);
            }
            else
            {
                downloadingPath.Add(path);
                Task.Run(() =>
                {
                    WebClient client = new WebClient();
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler((s, e) => client_DownloadProgressChanged(s, e, UID));
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler((s, e) => client_DownloadFileCompleted(s, e, UID, path, url, filename));
                    client.DownloadFileAsync(new Uri(url), @path);
                });
            }


            /*
            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                //client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler((s,e) => client_DownloadProgressChanged(s, e, UID));
                //client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler((s, e) => client_DownloadFileCompleted(s, e, UID, path, fileID));
                client.DownloadFileAsync(new Uri(url), @path);
            });
            thread.Start();
            */
        }
        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e, string UID)
        {
            if (isClosed) return;

            this.BeginInvoke((MethodInvoker)delegate
            {
                concurrentNowSize[UID].size = int.Parse(e.BytesReceived.ToString());
            });
        }
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e, string UID, string path, string url, string filename)
        {
            if (isClosed) return;

            this.BeginInvoke((MethodInvoker)delegate
            {
                if (e.Error == null && !e.Cancelled)
                {
                    outputDebug("INFO", $"{gb.lang.LOGGER_DOWNLOAD_COMPLETE}{filename}");

                    if (filename.StartsWith("icons/"))
                    {
                        Directory.CreateDirectory(gb.PathJoin(DATA_FOLDER, "assets", "icons"));
                        File.Copy(path, gb.PathJoin(DATA_FOLDER, "assets", filename), true);
                    }

                    FileWriteCompleted(UID);
                }
                else
                {
                    if (e.Cancelled)
                    {
                        outputDebug("INFO", $"{gb.lang.LOGGER_DOWNLOAD_CANCELED}{filename}");
                    }
                    else if (e.Error != null)
                    {
                        outputDebug("INFO", $"{gb.lang.LOGGER_DOWNLOAD_FAILED}{filename} {e.Error}");
                    }

                    //Task.Delay(250).Wait();
                    if (!(e.Error.InnerException is IOException))
                    {
                        while (!gb.CheckForInternetConnection())
                            //Thread.Sleep(1000);
                            Task.Delay(1000).Wait();
                    }

                    onThreadDownloader(url, path, filename, UID);
                }
            });
        }

        private void FileWriteCompleted(string UID)
        {
            concurrentNowSize[UID].size = concurrentNowSize[UID].totSize;
            concurrentTotalCompleted++;
            concurrentTotalCompletedDisplay++;

            UpdateDownloadState();
        }

        private void UpdateDownloadState()
        {
            if (!isClosed && concurrentNowSize != null && concurrentNowSize.Count > 0)
            {
                int tempSize = 0;

                foreach (var item in concurrentNowSize)
                {
                    tempSize += item.Value.size;
                }

                progressBar.Value = tempSize;
                output("INFO", $"{gb.lang.LOGGER_PARALLEL_DOWNLOADING.Replace("%TYPE%", concurrentType)} {SizeFormatter(concurrentTotalSize, tempSize)} ({concurrentTotalCompletedDisplay}/{indexObj.Count})");
                TaskbarManager.Instance.SetProgressValue(tempSize, concurrentTotalSize, Handle);
            }
        }
    }
}
