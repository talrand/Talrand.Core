using System;
using System.IO;

namespace Talrand.Core
{
    public class CSVWriter
    {
        private string _rowData = "";
        private string _fileName = "";

        public string FileName {set { _fileName = value; }}

        /// <summary>
        /// Add value to row data
        /// </summary>
        /// <param name="value"></param>
        public void AddValue(string value)
        {
            _rowData = _rowData.Join(",", $"'{value}'");
        }

        /// <summary>
        /// Writes current row data to file
        /// </summary>
        public void WriteLine()
        {
            using (var fileWriter = File.AppendText(_fileName))
            {
                fileWriter.WriteLine(_rowData);
            }

            _rowData = "";
        }
    }
}