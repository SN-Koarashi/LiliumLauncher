using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace LiliumLauncher
{
    public static class DpapiHelper
    {
        /// <summary>
        /// 加密字串並回傳加密後的 byte[]（使用 DPAPI）。
        /// scope: DataProtectionScope.CurrentUser 或 DataProtectionScope.LocalMachine
        /// optionalEntropy: 可選的額外 entropy（若不需要可傳 null）
        /// </summary>
        public static byte[] EncryptStringToBytes(string plainText, DataProtectionScope scope = DataProtectionScope.CurrentUser, byte[] optionalEntropy = null)
        {
            if (plainText == null) throw new ArgumentNullException(nameof(plainText));

            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            try
            {
                byte[] encrypted = ProtectedData.Protect(plainBytes, optionalEntropy, scope);
                return encrypted;
            }
            catch (CryptographicException ex)
            {
                // 視情況處理或記錄錯誤
                throw new InvalidOperationException("DPAPI Protect Failed。", ex);
            }
        }

        /// <summary>
        /// 解密由 EncryptStringToBytes 產生的 byte[]，回傳原始字串。
        /// </summary>
        public static string DecryptBytesToString(byte[] cipherBytes, DataProtectionScope scope = DataProtectionScope.CurrentUser, byte[] optionalEntropy = null)
        {
            if (cipherBytes == null) throw new ArgumentNullException(nameof(cipherBytes));

            try
            {
                byte[] decrypted = ProtectedData.Unprotect(cipherBytes, optionalEntropy, scope);
                return Encoding.UTF8.GetString(decrypted);
            }
            catch (CryptographicException ex)
            {
                // 解密失敗（可能是 scope/entropy 不符或不是在相同使用者/機器上）
                throw new InvalidOperationException("DPAPI Unprotect failed, may not be the same user or machine.", ex);
            }
        }

        public static byte[] GetMachineGuid()
        {
            try
            {
                using (var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                            .OpenSubKey(@"SOFTWARE\Microsoft\Cryptography", false))
                {
                    var mg = key?.GetValue("MachineGuid") as string;
                    if (!string.IsNullOrEmpty(mg)) return Encoding.UTF8.GetBytes(mg);
                }
            }
            catch
            {
                // 取得失敗（權限等），回傳 null
            }
            return null;
        }
    }
}
