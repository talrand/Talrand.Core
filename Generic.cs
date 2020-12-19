using System;

namespace Talrand.Core
{
    public class Generic
    {
        /// <summary>
        /// Retrieves data by inspecting a string for start and end data tags
        /// </summary>
        /// <param name="strData">String to inspect</param>
        /// <param name="strStartTag">Tag indicate start of data block</param>
        /// <param name="strEndTag">Tag to indicate end of data block</param>
        /// <param name="strRepositionTag">(optional) Tag to specify start of string inspection</param>
        /// <returns></returns>
        public static string GetDataFromString(string strData, string strStartTag, string strEndTag, string strRepositionTag = "")
        {
            string strTemp = "";
            int intStart = 0;
            int intEnd = 0;

            try
            {
                // Don't continue if no data passed
                if (strData == "")
                {
                    return "";
                }

                // No tags passed - return data
                if (strStartTag == "" || strEndTag == "")
                {
                    return strData;
                }

                // Data doesn't contain tags
                if (strData.ToLower().Contains(strStartTag.ToLower()) == false || strData.ToLower().Contains(strEndTag.ToLower()) == false)
                {
                    return "";
                }

                // Store data in temp string for formatting
                strTemp = strData;

                // Reposition if tag passed
                if (strRepositionTag != "")
                {
                    // Check data actually contains the reposition tag
                    if (strData.ToLower().Contains(strRepositionTag.ToLower()) == true)
                    {
                        strTemp = strTemp.Substring(strTemp.ToLower().IndexOf(strRepositionTag.ToLower()) + strRepositionTag.Length);
                    }
                }

                // Get position of start + end tags
                intStart = strTemp.IndexOf(strStartTag) + strStartTag.Length;
                intEnd = strTemp.IndexOf(strEndTag, intStart);

                if (intStart != 0 && intEnd != 0)
                {
                    // Return data
                    return strTemp.Substring(intStart, intEnd - intStart).Trim();
                }
                else
                {
                    // Data not found
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Concatenate strings together with a delimiter
        /// </summary>
        /// <param name="strDelimiter">A string containing the delimiter to be used between strings</param>
        /// <param name="str1">First string to concatenate</param>
        /// <param name="str2">Second string to concatenate</param>
        /// <param name="str3">Third string to concatenate (optional)</param>
        /// <param name="str4">Fourth string to concatenate (optional)</param>
        /// <param name="str5">Fifth string to concatenate (optional)</param>
        /// <param name="str6">Sixth string to concatenate (optional)</param>
        /// <returns>A concatenated string</returns>
        public static string StringTogether(string strDelimiter, string str1, string str2, string str3 = "", string str4 = "", string str5 = "", string str6 = "")
        {
            string strTemp = "";
            try
            {
                strTemp = IndividualStringTogether(strDelimiter, str1, str2);
                strTemp = IndividualStringTogether(strDelimiter, strTemp, str3);
                strTemp = IndividualStringTogether(strDelimiter, strTemp, str4);
                strTemp = IndividualStringTogether(strDelimiter, strTemp, str5);
                strTemp = IndividualStringTogether(strDelimiter, strTemp, str6);

                return strTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Concatenate 2 strings together with a delimiter
        /// </summary>
        /// <param name="strDelimiter">A string containing the delimiter to be used between strings</param>
        /// <param name="str1">First string to concatenate</param>
        /// <param name="str2">Second string to concatenate</param>
        /// <returns>A concaenated string</returns>
        private static string IndividualStringTogether(string strDelimiter, string str1, string str2)
        {
            try
            {
                if (str1 != "" && str2 != "")
                {
                    // Both strings exist - concatenate both strings with delimiter
                    return str1 + strDelimiter + str2;
                }
                else if (str1 != "" && str2 == "")
                {
                    // Only first string exists - return first string
                    return str1;
                }
                else if (str1 == "" && str2 != "")
                {
                    // Only second string exists - return second string
                    return str2;
                }
                else
                {
                    // Both strings blank
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Uses regular expression to remove HTML from passed text string
        /// </summary>
        /// <param name="strText">A string to remove HTML from</param>
        /// <returns>A string with HTML removed</returns>
        public static string RemoveHTML(string strText)
        {
            System.Text.RegularExpressions.Regex objRegex = null;

            try
            {
                // Don't continue if nothing passed
                if (strText == "")
                {
                    return "";
                }

                // Define regex pattern
                objRegex = new System.Text.RegularExpressions.Regex("<[^>]*>");

                // Remove HTML from text
                return objRegex.Replace(strText, " ").Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets executing path of application
        /// </summary>
        /// <returns></returns>
        public static string ExecutablePath()
        {
            try
            {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Converts an integer value to a boolean value
        /// </summary>
        /// <param name="intVal">Integer to convert to boolean</param>
        /// <returns>Boolean</returns>
        public static bool ConvertNumericToBoolean(int intVal)
        {
            try
            {
                if (intVal == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Converts a boolean value to a byte value
        /// </summary>
        /// <param name="booVal">Boolean to convert to byte</param>
        /// <returns></returns>
        public static byte ConvertBooleanToNumeric(bool booVal)
        {
            try
            {
                if (booVal == true)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
