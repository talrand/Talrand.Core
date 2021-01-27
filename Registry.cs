using System;

namespace Talrand.Core
{
    public static class Registry
    {
        /// <summary>
        /// Read the value for the passed registry key
        /// </summary>
        /// <param name="keyPath">Path to registry key</param>
        /// <param name="keyName">Name of registry key</param>
        /// <returns></returns>
        public static string ReadKey(string keyPath, string keyName)
        {
            Object keyVal = null;

            // Open registry key
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if (key != null)
                {
                    // Get key value and close key
                    keyVal = key.GetValue(keyName);
                    key.Close();
                }

            }

            if (keyVal != null)
            {
                // Convert key value to string
                return keyVal.ToString();
            }
            else
            {
                // No value - return blank
                return "";
            }
        }

        /// <summary>
        /// Writes value to the registry
        /// </summary>
        /// <param name="keyPath">Path to registry key</param>
        /// <param name="keyName">Name of registry key</param>
        /// <param name="keyVal">Value to write to registry key</param>
        public static void WriteKey(string keyPath, string keyName, string keyVal)
        {
            Microsoft.Win32.RegistryKey key;

            // Open registry key
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyPath, true);

            // Create registry key if it doesn't exist
            if (key == null)
            {
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(keyPath, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
            }

            // Set key value
            key.SetValue(keyName, keyVal, Microsoft.Win32.RegistryValueKind.String);

            // Close and dispose of key
            key.Close();
            key.Dispose();
        }
    }
}
