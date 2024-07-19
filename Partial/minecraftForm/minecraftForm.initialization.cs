using Global;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using LiliumLauncher.Properties;
using LiliumLauncher.Tasks;

namespace LiliumLauncher
{
    public partial class minecraftForm
    {
        private StreamWriter logger = null;
        // 顯示在主畫面及偵錯與輸出
        private void output(string type, string sOutput)
        {
            if (this.IsDisposed) return;

            textStatus.Text = sOutput;
            Application.DoEvents();

            outputDebug(type, sOutput);
        }

        // 顯示在偵錯與輸出
        private void outputDebug(string type, string output)
        {
            if (this.IsDisposed) return;

            DateTime dateTime = System.DateTime.Now;

            string time = $"{dateTime.Year.ToString("00")}/{dateTime.Month.ToString("00")}/{dateTime.Day.ToString("00")} {dateTime.Hour.ToString("00")}:{dateTime.Minute.ToString("00")}:{dateTime.Second.ToString("00")}.{dateTime.Millisecond.ToString("000")} ";

            string result = $"{time} [{type}] {output}" + Environment.NewLine;

            if (gb.isSaveLogFile)
            {
                logger.Write(result);
            }
            else
            {
                textBox.AppendText(result);
            }

            Console.WriteLine(output);
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

            this.Text = this.Text + " v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void initializeMain(string[] args)
        {
            initializeMain();
        }
        private void initializeMain()
        {
            InitializeComponent();
            setTray();
            setTranslate();

            this.SetStyle(
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);

            authification = new authificationTask();
            launcher = new launcherTask();

            radConcurrent.Checked = gb.isConcurrent;
            radSingle.Checked = !gb.isConcurrent;

            maxMemory = Convert.ToInt32(Math.Floor(Convert.ToDouble(new ComputerInfo().TotalPhysicalMemory / 1024 / 1024 / 1000)) - 2) * 1024;
            trackBarMiB.Maximum = maxMemory / 1024;
            trackBarMiB.Minimum = 0;

            if (gb.maxMemoryUsage == 0)
            {
                trackBarMiB.Value = 0;
                textBoxMiB.Text = "512";
            }
            else
            {
                trackBarMiB.Value = gb.maxMemoryUsage / 1024;
                textBoxMiB.Text = gb.maxMemoryUsage.ToString();
            }

            checkBoxMaxMem.Checked = gb.usingMaxMemoryUsage;

            textBoxAD.Text = gb.mainFolder;
            DATA_FOLDER = gb.mainFolder;
            try
            {
                gb.hideTabPage = tabControl1.TabPages[2];

                Directory.CreateDirectory(DATA_FOLDER);
                Directory.CreateDirectory(gb.PathJoin(DATA_FOLDER, ".x-instance"));

                initLoggerHandle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + gb.lang.DIALOG_REPLACE_DEFAULT_PATH, gb.lang.DIALOG_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                createGameDefFolder();
            }

            onGetAllInstance();
        }

        private void initLoggerHandle()
        {
            if (gb.isSaveLogFile)
            {
                Directory.CreateDirectory(gb.PathJoin(DATA_FOLDER, "launcher-logs"));
                tabControl1.TabPages.Remove(gb.hideTabPage);

                if (logger == null)
                {
                    string file_path = gb.PathJoin(gb.mainFolder, "launcher-logs", $"process-{gb.startUnixTime}.log");
                    logger = File.AppendText(file_path);
                    logger.AutoFlush = true;
                }
            }
            else if (!gb.isSaveLogFile && !tabControl1.TabPages.Contains(gb.hideTabPage))
            {
                tabControl1.TabPages.Insert(2, gb.hideTabPage);
            }
        }

        private void createGameDefFolder()
        {
            gb.mainFolder = gb.mainFolderDefault;
            textBoxAD.Text = gb.mainFolder;
            DATA_FOLDER = gb.mainFolder;
            Directory.CreateDirectory(DATA_FOLDER);
            Directory.CreateDirectory(gb.PathJoin(DATA_FOLDER, ".x-instance"));


            onGetAllVersion();
            onGetAllInstance();
        }

        private void setTray()
        {
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.lilium_logo,
                //ContextMenu = new ContextMenu(),
                ContextMenuStrip = new ContextMenuStrip(),
                Visible = false
            };
            trayIcon.MouseClick += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    restoreWindowInFront();
                }
            };
            trayIcon.Text = "Lilium Minecraft Launcher";

            var menuItemIcon = new ToolStripMenuItem("Lilium Launcher", Resources.lilium_logo.ToBitmap());
            menuItemIcon.Image = Resources.lilium_logo.ToBitmap();
            menuItemIcon.ToolTipText = "Minecraft Launcher";
            menuItemIcon.Click += (sender, e) =>
            {
                MessageBox.Show(gb.lang.DIALOG_TRAY_MAIN, "Lilium Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            var menuItemAvatar = new ToolStripMenuItem(textUser.Text, avatar.Image);
            menuItemAvatar.Image = avatar.Image;

            var menuItemKill = new ToolStripMenuItem(gb.lang.TRAY_CLOSE_GAME);
            menuItemKill.Enabled = false;

            var menuItemExit = new ToolStripMenuItem(gb.lang.TRAY_CLOSE_LAUNCHER);
            menuItemExit.Click += (sender, e) =>
            {
                this.Close();
            };

            trayIcon.ContextMenuStrip.Items.Add(menuItemIcon);
            trayIcon.ContextMenuStrip.Items.Add(menuItemAvatar);
            trayIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            trayIcon.ContextMenuStrip.Items.Add(menuItemKill);
            trayIcon.ContextMenuStrip.Items.Add(menuItemExit);
        }

        private void restoreWindowInFront()
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Opacity = 1;
            this.Icon = Resources.lilium_logo;
            this.Activate();
        }

        private void updateTrayAvatar()
        {
            trayIcon.ContextMenuStrip.Items.RemoveAt(1);
            trayIcon.ContextMenuStrip.Items.Insert(1, new ToolStripMenuItem(gb.minecraftUsername, avatar.Image));
            trayIcon.ContextMenuStrip.Items[1].ToolTipText = gb.minecraftUUID;
        }

        private void setTranslate()
        {
            btnLaunch.Text = gb.lang.BTN_LAUNCH;
            btnOpenFolder.Text = gb.lang.BTN_OPEN_FOLDER;
            btnVerifyFile.Text = gb.lang.BTN_OPEN_VERIFY;
            btnMultiAcc.Text = gb.lang.BTN_MULTI_ACCOUNT;
            btnSwitchAcc.Text = gb.lang.BTN_ADD_ACCOUNT;
            btnLogout.Text = gb.lang.BTN_LOGOUT_ACCOUNT;
            btnChkUpdate.Text = gb.lang.BTN_CHECK_UPDATE;
            btnMainSetting.Text = gb.lang.BTN_SETTINGS;
            buttonVerReload.Text = gb.lang.BTN_VER_INS_RELOAD;
            btnVerRecache.Text = gb.lang.BTN_VER_INS_RECACHE;
            btnInstanceAdd.Text = gb.lang.BTN_ADD_INSTANCE;
            btnInstanceEdit.Text = gb.lang.BTN_EDIT_INSTANCE;
            btnInstanceDel.Text = gb.lang.BTN_REMOVE_INSTANCE;

            groupBoxAccount.Text = gb.lang.GROUP_ACCOUNT;
            groupBoxDataFolder.Text = gb.lang.GROUP_MAIN_DATA;
            groupBoxInstance.Text = gb.lang.GROUP_INSTANCE;
            groupBoxInterval.Text = gb.lang.GROUP_DOWNLOAD_MODE;
            groupBoxVersionReload.Text = gb.lang.GROUP_VERSION_AND_INSTANCE_DATA;
            groupBoxMemory.Text = gb.lang.GROUP_MAX_MEMORY;
            groupBoxMainProg.Text = gb.lang.GROUP_LAUNCHER;

            checkBoxMaxMem.Text = gb.lang.CHK_OPEN;
            radConcurrent.Text = gb.lang.RAD_CONCURRENCY;
            radSingle.Text = gb.lang.RAD_SINGLE;

            tabControl1.TabPages[0].Text = gb.lang.TAB_MAIN;
            tabControl1.TabPages[1].Text = gb.lang.TAB_SETTINGS;
            tabControl1.TabPages[2].Text = gb.lang.TAB_OUTPUT_LOG;
            tabControl1.TabPages[3].Text = gb.lang.TAB_CHANGELOG;

            toolTip.SetToolTip(btnOpenFolder, gb.lang.TOOLTIP_OPEN_FOLDER);
            toolTip.SetToolTip(btnVerifyFile, gb.lang.TOOLTIP_VERIFY_FILE);
            toolTip.SetToolTip(buttonVerReload, gb.lang.TOOLTIP_RELOAD);
            toolTip.SetToolTip(btnVerRecache, gb.lang.TOOLTIP_RECACHE);
            toolTip.SetToolTip(radConcurrent, gb.lang.TOOLTIP_DOWNLOAD_CONCURRENCY);
            toolTip.SetToolTip(radSingle, gb.lang.TOOLTIP_DOWNLOAD_SINGLE);

            tabControl1.Font = new System.Drawing.Font(gb.lang.FONT_FAMILY, gb.lang.FONT_SIZE);
        }

        public IEnumerable<Control> GetSelfAndChildrenRecursive(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control child in parent.Controls)
            {
                controls.AddRange(GetSelfAndChildrenRecursive(child));
            }

            controls.Add(parent);

            return controls;
        }
    }
}
