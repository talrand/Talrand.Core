using System;
using System.Data;

namespace Talrand.Core
{
    class Data
    {
        /// <summary>
        /// Sorts DataTable using the passed sort string
        /// </summary>
        /// <param name="objDataTable">DataTable to sort</param>
        /// <param name="strSort">A string containing the required sort order</param>
        /// <returns></returns>
        public static DataTable SortDataTable(DataTable objDataTable, string strSort)
        {
            DataView objDataView = null;

            try
            {
                // Don't continue if no DataTable passed
                if (objDataTable == null)
                {
                    return null;
                }

                // No sort order passed - just return passed DataTable
                if (strSort == "")
                {
                    return objDataTable;
                }

                // Get default view of table
                objDataView = objDataTable.DefaultView;

                // Sort data
                objDataView.Sort = strSort;

                // Return sorted data
                return objDataView.ToTable();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Extracts a DataTable from the passed DataSet
        /// </summary>
        /// <param name="objDataSet">DataSet to extract DataTable from</param>
        /// <param name="strTableName">Name of the DataTable to extract from DataSet (optional)</param>
        /// <returns></returns>
        public static DataTable GetTableFromDataSet(DataSet objDataSet, string strTableName = "")
        {
            try
            {
                // Don't continue if no data present
                if (objDataSet == null)
                {
                    return null;
                }

                if (objDataSet.Tables.Count == 0)
                {
                    return null;
                }

                if (strTableName != "")
                {
                    // Check DataSet contains requested table
                    if (objDataSet.Tables.Contains(strTableName) == true)
                    {
                        // Return requested table
                        return objDataSet.Tables[strTableName];
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
                    return objDataSet.Tables[0];
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
