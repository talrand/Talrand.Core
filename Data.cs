using System;
using System.Data;

namespace Talrand.Core
{
    public static class Data
    {
        /// <summary>
        /// Extracts a DataTable from the passed DataSet
        /// </summary>
        /// <param name="dataSet">DataSet to extract DataTable from</param>
        /// <param name="tableName">Name of the DataTable to extract from DataSet (optional)</param>
        /// <returns></returns>
        public static DataTable GetDataTableFromDataSet(DataSet dataSet, string tableName = "")
        {
            if (tableName != "")
            {
                // Return requested table
                return dataSet.Tables[tableName];
            }

            // No table name passed - just return first table
            return dataSet.Tables[0];
        }
    }
}