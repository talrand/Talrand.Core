using System;
using System.Data;

namespace Talrand.Core
{
    public static class Data
    {
        /// <summary>
        /// Sorts DataTable using the passed sort string
        /// </summary>
        /// <param name="dataTable">DataTable to sort</param>
        /// <param name="sort">A string containing the required sort order</param>
        /// <returns></returns>
        public static DataTable SortDataTable(DataTable dataTable, string sort)
        {
            // Get default view of table
            DataView dataView = dataTable.DefaultView;

            // Sort data
            dataView.Sort = sort;

            // Return sorted data
            return dataView.ToTable();
        }

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