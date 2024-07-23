using Global;
using LiliumLauncher.Tasks;
using Microsoft.WindowsAPICodePack.Taskbar;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using static LiliumLauncher.ClassModel.globalModel;

namespace LiliumLauncher
{
    public partial class minecraftForm
    {
        private async void onAzureToken(string azureToken)
        {
            if (isClosed) return;

            if (!this.IsDisposed)
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate, Handle);
            settingAllControl(false);
            progressBar.Style = ProgressBarStyle.Marquee;

            output("INFO", gb.lang.LOGGER_VERIFYING_AZURE);
            var bearer = await authification.Code2Token(azureToken);
            if (!bearer.ContainsKey("error"))
            {
                output("INFO", gb.lang.LOGGER_VERIFYING_AZURE_COMPLETE);


                gb.refreshToken = bearer["refresh_token"].ToString();

                onXBLToken(bearer["access_token"].ToString());
                progressBar.Value += 10;
            }
            else
            {
                gb.resetTokens();
                MessageBox.Show(bearer["error_description"].ToString(), gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                gb.savingSession(true);

                FormCollection fc = Application.OpenForms;
                if (fc != null && fc.Count > 0 && fc[0].Name == this.Name)
                {
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private async void onRefreshToken(string refresh_token)
        {
            if (isClosed) return;

            avatar.Visible = false;
            textUser.Visible = false;
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate, Handle);
            settingAllControl(false);
            progressBar.Style = ProgressBarStyle.Marquee;

            output("INFO", gb.lang.LOGGER_GETTING_REFRESH_TOKEN);
            var result = await authification.refreshToken(gb.refreshToken);
            output("INFO", gb.lang.LOGGER_GETTING_REFRESH_TOKEN_COMPLETE);
            progressBar.Value += 10;

            if (result.ContainsKey("error"))
            {
                gb.resetTokens();
                MessageBox.Show(result["error_description"].ToString(), gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                gb.savingSession(true);

                FormCollection fc = Application.OpenForms;
                if (fc != null && fc.Count > 0 && fc[0].Name == this.Name)
                {
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                var access_token = result["access_token"].ToString();
                gb.refreshToken = result["refresh_token"].ToString();

                onXBLToken(access_token);
            }
        }

        private async void onXBLToken(string access_token)
        {
            if (isClosed) return;
            output("INFO", gb.lang.LOGGER_GETTING_XBL_TOKEN);
            var token = await authification.getXBLToken(access_token);
            output("INFO", gb.lang.LOGGER_GETTING_XBL_TOKEN_COMPLETE);
            progressBar.Value += 10;

            var Token = token["Token"].ToString();
            onXSTSToken(Token);
        }
        private async void onXSTSToken(string XBLToken)
        {
            if (isClosed) return;
            output("INFO", gb.lang.LOGGER_GETTING_XSTS_TOKEN);
            var token = await authification.getXSTSToken(XBLToken);
            output("INFO", gb.lang.LOGGER_GETTING_XSTS_TOKEN_COMPLETE);
            progressBar.Value += 10;

            if (token.ContainsKey("XErr"))
            {
                string type = token["XErr"].ToString();

                switch (type)
                {
                    case "2148916233":
                        MessageBox.Show(gb.lang.DIALOG_NO_XBOX_ACCOUNT, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "2148916235":
                        MessageBox.Show(gb.lang.DIALOG_XBOX_NOT_AVAILABLE, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "2148916238":
                        MessageBox.Show(gb.lang.DIALOG_XBOX_IS_CHILD, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                FormCollection fc = Application.OpenForms;
                if (fc != null && fc.Count > 0 && fc[0].Name == this.Name)
                {
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                var DisplayClaims = token["DisplayClaims"].ToString();
                var XM = JsonConvert.DeserializeObject<authificationTask.XUIModel>(DisplayClaims);

                var UserHash = XM.xui[0]["uhs"].ToString();
                var XSTSToken = token["Token"].ToString();
                onMinecraftAuth(XSTSToken, UserHash);
            }
        }

        private async void onMinecraftAuth(string XSTSToken, string UserHash)
        {
            if (isClosed) return;

            output("INFO", gb.lang.LOGGER_GETTING_MINECRAFT_TOKEN);
            var token = await authification.getMinecraftAuth(XSTSToken, UserHash);
            output("INFO", gb.lang.LOGGER_GETTING_MINECRAFT_TOKEN_COMPLETE);
            progressBar.Value += 10;

            var access_token = token["access_token"].ToString();
            var token_type = token["token_type"].ToString();
            int expires_in = int.Parse(token["expires_in"].ToString());

            gb.launchToken = access_token;
            gb.launchTokenExpiresAt = gb.getNowMilliseconds() + expires_in * 1000;

            onCheckGameOwnership(access_token, token_type);
        }

        private async void onCheckGameOwnership(string accessToken, string type)
        {
            if (isClosed) return;

            output("INFO", gb.lang.LOGGER_CHECKING_MINECRAFT_OWNERSHIP);
            var auth = await authification.checkGameOwnership(accessToken, type);
            output("INFO", gb.lang.LOGGER_CHECKING_MINECRAFT_OWNERSHIP_COMPLETE);
            progressBar.Value += 10;

            if (auth["items"].ToString().Length < 10)
            {
                MessageBox.Show(gb.lang.DIALOG_NO_MINECRAFT_ACCOUNT, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormCollection fc = Application.OpenForms;
                if (fc != null && fc.Count > 0 && fc[0].Name == this.Name)
                {
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                onMinecraftProfile(accessToken, type);
            }
        }
        private async void onMinecraftProfile(string accessToken, string type)
        {
            if (isClosed) return;

            output("INFO", gb.lang.LOGGER_GETTING_MINECRAFT_PROFILE);
            var result = await authification.getMinecraftProfile(accessToken, type);
            output("INFO", gb.lang.LOGGER_GETTING_MINECRAFT_PROFILE_COMPLETE);
            progressBar.Value += 10;

            if (result.ContainsKey("errorType"))
            {
                MessageBox.Show(gb.lang.DIALOG_NO_MINECRAFT_ACCOUNT, gb.lang.DIALOG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormCollection fc = Application.OpenForms;
                if (fc != null && fc.Count > 0 && fc[0].Name == this.Name)
                {
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                string uuid = result["id"].ToString();
                string username = result["name"].ToString();
                gb.minecraftUsername = username;
                gb.minecraftUUID = uuid;

                loginSuccess(username, uuid);
            }
        }

        private void loginSuccess(string username, string uuid)
        {
            if (isClosed) return;

            progressBar.Style = ProgressBarStyle.Blocks;
            output("INFO", $"{gb.lang.LOGGER_LOGIN_USER} -{username} -{uuid}");

            textUser.Text = username;

            avatar.WaitOnLoad = false;
            avatar.LoadAsync($"https://cravatar.eu/helmavatar/{uuid}");

            textUser.Visible = true;

            gb.startupParms.username = username;
            gb.startupParms.uuid = uuid;
            gb.startupParms.accessToken = gb.launchToken;

            gb.account.Remove(gb.minecraftUUID);
            AccountModel am = new AccountModel();
            am.username = gb.minecraftUsername;
            am.refreshToken = gb.refreshToken;
            am.accessToken = gb.launchToken;
            am.expiresAt = gb.launchTokenExpiresAt;
            am.lastUsed = gb.getDateTimeWithAD();
            gb.account.Add(gb.minecraftUUID, am);

            gb.savingSession(false);
            onGetAllVersion();
            settingAllControl(true);
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress, Handle);

            updateTrayAvatar();

            if (!gb.firstStart)
                gb.checkForUpdate(false);
        }
    }
}
