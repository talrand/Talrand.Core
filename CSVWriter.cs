using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // Write constructed data to file
            using (var fileWriter = System.IO.File.AppendText(_fileName))
            {
                fileWriter.WriteLine(_rowData);
            }

            _rowData = "";
        }
    }
}