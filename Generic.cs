using System;
using Microsoft.Win32;
using System.Diagnostics;

namespace Talrand.Core
{
    public static class Generic
    {        
        /// <summary>
        /// Gets executing path of application
        /// </summary>
        /// <returns></returns>
        public static string ExecutablePath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// Read the value for the passed registry key
        /// </summary>
        /// <param name="keyPath">Path to registry key</param>
        /// <param name="keyName">Name of registry key</param>
        /// <returns></returns>
        public static string ReadRegistryKey(string keyPath, string keyName)
        {
            Object keyVal = null;

            // Open registry key
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
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
        public static void WriteRegistryKey(string keyPath, string keyName, string keyVal)
        {
            RegistryKey key = null;

            // Open registry key
            key = Registry.CurrentUser.OpenSubKey(keyPath, true);

            // Create registry key if it doesn't exist
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(keyPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
            }

            // Set key value
            key.SetValue(keyName, keyVal, RegistryValueKind.String);

            // Close and dispose of key
            key.Close();
            key.Dispose();
        }

        /// <summary>
        /// Opens a file using the default associated program
        /// </summary>
        /// <param name="fileName">Full filename path of file to open</param>
        /// <param name="waitForExit">A boolean indicating whether the program should wait for the file to be closed before continuing (optional)</param>
        public static void ViewFile(String fileName, bool waitForExit = false)
        {
            Process process = new Process();

            process.StartInfo.FileName = fileName;
            process.Start();

            if (waitForExit == true)
            {
                process.WaitForExit();
            }
        }
    }
}