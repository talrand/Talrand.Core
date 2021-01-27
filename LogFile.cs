using System;
using System.IO;

namespace Talrand.Core
{
    public class LogFile
    {
        public string FileName { get; set; }

        public LogFile(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Outputs passed text to log file
        /// </summary>
        /// <param name="text">Text to append to log</param>
        public void Write(string text)
        {
            using (StreamWriter fileWriter = File.AppendText(FileName))
            {
                fileWriter.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " : " + text);
            }
        }

        /// <summary>
        /// Deletes log file
        /// </summary>
        public void Delete()
        {
            if (File.Exists(FileName) == true)
            {
                File.Delete(FileName);
            }
        }
    }
}
