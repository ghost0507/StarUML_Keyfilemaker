using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace StarUML_Keyfilemaker
{
    /*
     * NOTE: 
     *      -For v5.x, v6.x needs patch validate() function of the '/src/engine/license-manager.js' file from '/resources/app.asar'
     *        All content code of '//Server check' needs to be replaced with this new line to enable offline activation
     *         resolve(licenseInfo);
     *      -For v7.x just needs block IPs from domain 'dev.staruml-io-astro.pages.dev'
     */

    public static class Licensing
    {
        public static readonly string LICENSE_PATH_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"StarUML");

        public static License buildLicenseInfo(string username, LicenseType licenseType, LicenseVersion licenseVersion)
        {
            License licenseInfo;

            if (LicenseVersion.V5.Equals(licenseVersion) || LicenseVersion.V6.Equals(licenseVersion))
            {
                licenseInfo = buildOldLicenseInfo(username, licenseType, licenseVersion);
            }
            else
            {
                licenseInfo = buildNewLicenseInfo(username, licenseType, licenseVersion);
            }

            string licenseKey = generateLicenseKey(licenseInfo, licenseVersion);

            licenseInfo.LicenseKey = licenseKey;

            return licenseInfo;
        }

        private static OldLicense buildOldLicenseInfo(string username, LicenseType licenseType, LicenseVersion licenseVersion)
        {
            OldLicense licenseInfo = new OldLicense
            {
                Name = username.Trim(),
                Product = licenseVersion.Code,
                LicenseType = licenseType.Code,
                Quantity = 999,
                Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                LicenseKey = string.Empty
            };

            return licenseInfo;
        }

        private static NewLicense buildNewLicenseInfo(string username, LicenseType licenseType, LicenseVersion licenseVersion)
        {
            NewLicense licenseInfo = new NewLicense
            {
                Name = username.Trim(),
                Product = licenseVersion.Code,
                Edition = licenseType.Code,
                DelivceId = GetMachineGuid(),
                LicenseKey = string.Empty
            };

            return licenseInfo;
        }

        private static String generateLicenseKey(License licenseInfo, LicenseVersion licenseVersion)
        {
            if (LicenseVersion.V5.Equals(licenseVersion) || LicenseVersion.V6.Equals(licenseVersion))
            {
                return generateOldLicenseKey(licenseInfo as OldLicense, licenseVersion);
            }

            return generateNewLicenseKey(licenseInfo as NewLicense);
        }

        private static String generateOldLicenseKey(OldLicense licenseInfo, LicenseVersion licenseVersion)
        {
            string baseSerial = string.Concat(licenseVersion.CryptoKey, licenseInfo.Name, licenseVersion.CryptoKey, licenseInfo.Product, "-"
                , licenseInfo.LicenseType, licenseVersion.CryptoKey, licenseInfo.Quantity, licenseVersion.CryptoKey, licenseInfo.Timestamp, licenseVersion.CryptoKey);

            string key = string.Empty;

            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(baseSerial);
                byte[] hashBytes = sha1.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("X2"));
                }

                key = stringBuilder.ToString().ToUpper();
            }

            return key;
        }

        private static String generateNewLicenseKey(NewLicense licenseInfo)
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }

        private static string GetMachineGuid()
        {
            string key = @"SOFTWARE\Microsoft\Cryptography";

            string deviceId = null;

            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(key))
            {
                if (registryKey != null)
                {
                    object guid = registryKey.GetValue("MachineGuid");

                    if (guid != null)
                    {
                        deviceId = guid.ToString();
                    }
                }
            }

            if (!String.IsNullOrEmpty(deviceId))
            {
                using (SHA256 sha256 = SHA256.Create()){
                    byte[] bytesDeviceId = Encoding.UTF8.GetBytes(deviceId);

                    byte[] hashBytesDeviceId = sha256.ComputeHash(bytesDeviceId);

                    StringBuilder sb = new StringBuilder();

                    foreach (byte hashByteDeviceId in hashBytesDeviceId)
                    {
                        sb.Append(hashByteDeviceId.ToString("x2"));
                    }

                    deviceId = sb.ToString();
                }
            }

            return String.IsNullOrEmpty(deviceId) ? "*" : deviceId;
        }

        public static bool writeLicenseFile(License licenseInfo, LicenseVersion licenseVersion, string licensePathToWrite)
        {
            bool needAesEncryptation = !LicenseVersion.V5.Equals(licenseVersion) && !LicenseVersion.V6.Equals(licenseVersion);

            return writeLicenseFile(licenseInfo, licenseVersion, licensePathToWrite, needAesEncryptation);
        }

        private static bool writeLicenseFile(License licenseInfo, LicenseVersion licenseVersion, string licensePathToWrite, bool needAesEncryptation)
        {
            bool result = false;

            try
            {
                string contentToWrite = JsonConvert.SerializeObject(licenseInfo);

                if (needAesEncryptation)
                {
                    byte[] key = AesGcmEncryption.ImportAesKey(licenseVersion.CryptoKey);

                    contentToWrite = AesGcmEncryption.EncryptString(contentToWrite, key);
                }

                if (File.Exists(licensePathToWrite))
                    File.SetAttributes(licensePathToWrite, FileAttributes.Normal);

                if (SafeWriteFile(Encoding.UTF8.GetBytes(contentToWrite), licensePathToWrite))
                {
                    File.SetAttributes(licensePathToWrite, File.GetAttributes(licensePathToWrite) | FileAttributes.Normal);

                    result = true;
                }
            }
            catch
            {
            }

            return result;
        }

        private static bool SafeWriteFile(byte[] content, string path)
        {
            string temp = path + ".tmp";
            bool success;
            try
            {
                new FileInfo(temp).Directory.Create();
                if (File.Exists(temp))
                {
                    File.Delete(temp);
                }
                File.WriteAllBytes(temp, content);
                if (File.ReadAllBytes(temp).Length == content.Length)
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    File.Copy(temp, path, true);
                }
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            try
            {
                if (File.Exists(temp))
                {
                    File.Delete(temp);
                }
            }
            catch
            {
            }
            return success;
        }

    }
}
