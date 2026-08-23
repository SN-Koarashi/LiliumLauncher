using Global;
using System;
using System.Windows.Forms;

namespace LiliumLauncher
{
    // 非隱私模式下無法自動判斷瀏覽器是否關閉(使用者其他分頁仍會佔用處理程序)，
    // 因此改以此視窗提供取消操作，讓使用者主動中止等待登入。
    public partial class loginWaitingForm : Form
    {
        private readonly string profilePath;
        private bool isCancelled = false;
        private bool isCompleted = false;

        public loginWaitingForm(string profilePath)
        {
            this.profilePath = profilePath;

            InitializeComponent();

            this.Text = gb.lang.FORM_TITLE_MICROSOFT_OAUTH;
            labelWaiting.Text = gb.lang.LAB_WAITING_BROWSER_LOGIN;
            btnCancel.Text = gb.lang.BTN_CANCEL;
        }

        // 登入完成時由呼叫端關閉此視窗
        public void CompleteLogin()
        {
            if (this.IsDisposed) return;

            isCompleted = true;

            // 視窗尚未顯示即完成登入(例如憑證已快取)，
            // 此時無視窗控制代碼不可 Invoke；
            // 先設定 DialogResult，Shown 事件會在顯示後立即關閉
            if (!this.IsHandleCreated)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }

            // 使用 BeginInvoke 避免延續工作與介面執行緒互相等待
            this.BeginInvoke(new Action(() => closeAsCompleted()));
        }

        private void closeAsCompleted()
        {
            if (this.IsDisposed) return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 登入在視窗顯示前(或顯示途中)即完成時，顯示後立即關閉
        private void loginWaitingForm_Shown(object sender, EventArgs e)
        {
            if (isCompleted)
                closeAsCompleted();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (isCancelled) return;
            isCancelled = true;

            btnCancel.Enabled = false;

            // 通知本機 HTTP 伺服器結束等待，並清除瀏覽器設定檔中的暫存資料
            Tasks.loginChallengeTask.CancelLogin(profilePath);

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
