using Global;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using static XCoreNET.ClassModel.globalModel;

namespace XCoreNET
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            CultureInfo ci = CultureInfo.CurrentUICulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ProgramModel pm = null;
            CoreWebView2Environment.LoaderDllFolderPath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "/runtimes/win-x86/native");

            string path = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "/settings/programs_settings.json");
            if (File.Exists(path))
            {
                var data = File.ReadAllText(path);
                pm = JsonConvert.DeserializeObject<ProgramModel>(data);
                gb.launcherHomepage = (pm.launcherURL != null) ? new Uri(pm.launcherURL) : gb.launcherHomepage;
                gb.mainHomepage = (pm.mainURL != null) ? new Uri(pm.mainURL) : gb.mainHomepage;
                gb.loginMethod = (pm.loginMethod != null) ? pm.loginMethod : gb.loginMethod;
                gb.isCheckUpdate = (bool)(pm.checkForUpdates != null ? pm.checkForUpdates : true);
                gb.langCode = (pm.langCode != null) ? pm.langCode : ci.Name;
            }
            else
            {
                pm = new ProgramModel();
                pm.launcher = true;
                pm.noWevView = false;
                pm.launcherURL = gb.launcherHomepage.ToString();
                pm.mainURL = gb.mainHomepage.ToString();
                pm.loginMethod = gb.loginMethod;
                pm.checkForUpdates = true;
                pm.langCode = ci.Name;

                var data = JsonConvert.SerializeObject(pm);
                Directory.CreateDirectory(Path.GetFullPath(Directory.GetCurrentDirectory() + "/settings"));
                File.WriteAllText(path, data);
            }

            gb.setTranslate();

            if (args.Length == 0)
            {
                if (pm != null)
                {
                    var nowArgs = new List<string>();
                    if (pm.launcher)
                        nowArgs.Add("-launcher");
                    if (pm.noWevView)
                        nowArgs.Add("-noWebView");

                    if (pm.launcher)
                    {
                        Console.WriteLine("初始化啟動器進入點");
                        Application.Run(new minecraftForm(nowArgs.ToArray()));
                    }
                    else
                    {
                        Application.Run(new main(nowArgs.ToArray()));
                    }
                }
                else
                {
                    Application.Run(new main());
                }
            }
            else
            {
                bool isUpdater = false;
                bool onlyLauncher = false;
                bool forceWebChat = false;
                foreach (var arg in args)
                {
                    if (arg.ToLower().Equals("-launcher"))
                    {
                        Console.WriteLine("初始化啟動器進入點");
                        onlyLauncher = true;
                    }
                    if (arg.ToLower().Equals("-forcechat"))
                    {
                        forceWebChat = true;
                    }
                    if (arg.ToLower().Equals("-updater"))
                    {
                        Console.WriteLine("初始化更新程式進入點");
                        isUpdater = true;
                    }
                }


                if (isUpdater)
                    Application.Run(new mainUpdater());
                else if (forceWebChat)
                    Application.Run(new main(args));
                else if (onlyLauncher)
                    Application.Run(new minecraftForm(args));
                else
                    Application.Run(new main(args));
            }
        }
    }
}
