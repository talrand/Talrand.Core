using System;
using System.Diagnostics;

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
    }
}