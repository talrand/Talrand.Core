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
        public static string GetApplicationExecutablePath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// Opens a file using the default associated program
        /// </summary>
        /// <param name="fileName">Full filename path of file to open</param>
        public static void OpenFile(String fileName)
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.Start();
        }

        /// <summary>
        /// Opens a file using the default associated program and waits for user to close the file
        /// </summary>
        /// <param name="fileName">Full filename path of file to open</param>
        public static void OpenFileAndWaitForExit(String fileName)
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.Start();
            process.WaitForExit();
        }
    }
}