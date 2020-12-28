using System;
using System.Data;

namespace Talrand.Core
{
    class Data
    {
        /// <summary>
        /// Sorts DataTable using the passed sort string
        /// </summary>
        /// <param name="dataTable">DataTable to sort</param>
        /// <param name="sort">A string containing the required sort order</param>
        /// <returns></returns>
        public static DataTable SortDataTable(DataTable dataTable, string sort)
        {
            DataView dataView = null;

            try
            {
                // Don't continue if no DataTable passed
                if (dataTable == null)
                {
                    return null;
                }

                // No sort order passed - just return passed DataTable
                if (sort == "")
                {
                    return dataTable;
                }

                // Get default view of table
                dataView = dataTable.DefaultView;

                // Sort data
                dataView.Sort = sort;

                // Return sorted data
                return dataView.ToTable();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Extracts a DataTable from the passed DataSet
        /// </summary>
        /// <param name="dataSet">DataSet to extract DataTable from</param>
        /// <param name="tableName">Name of the DataTable to extract from DataSet (optional)</param>
        /// <returns></returns>
        public static DataTable GetTableFromDataSet(DataSet dataSet, string tableName = "")
        {
            try
            {
                // Don't continue if no data present
                if (dataSet == null)
                {
                    return null;
                }

                if (dataSet.Tables.Count == 0)
                {
                    return null;
                }

                if (tableName != "")
                {
                    // Check DataSet contains requested table
                    if (dataSet.Tables.Contains(tableName) == true)
                    {
                        // Return requested table
                        return dataSet.Tables[tableName];
                    }
                    else
                    {
                        // Passed table name not found
                        return null;
                    }
                }
                else
                {
                    // No table name passed - just return first table
                    return dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}