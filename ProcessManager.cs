using System;
using System.Diagnostics;
using System.IO;

namespace Talrand.Core
{
    public static class ProcessManager
    {        
        /// <summary>
        /// Gets executing path of current application
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentExecutablePath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// Opens a file using the default associated program
        /// </summary>
        /// <param name="fileName">Full filename path of file to open</param>
        /// <param name="waitForExit">Boolean indicating whether program should wait for program to exit before continuing (optional)</param>
        public static void OpenFile(string fileName, bool waitForExit = false)
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.Start();

            if(waitForExit == true)
            {
                process.WaitForExit();
            }
        }

        /// <summary>
        /// Checks if the passed file is currently locked by another process
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsFileLocked(string fileName)
        {
            try
            {
                // Try to stream file - if errors file is locked
                using (var streamReader = new StreamReader(fileName))
                {
                    streamReader.Close();
                }

                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}