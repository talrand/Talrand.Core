﻿using System;
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