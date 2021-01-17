using System;

namespace Talrand.Core
{
    public static class Extensions
    {
        public static byte ToByte(this Boolean val)
        {
            return Conversions.BooleanToNumeric(val);
        }

        public static bool ToBoolean(this Int32 val)
        {
            return Conversions.NumericToBoolean(val);
        }

        public static bool ToBoolean(this Byte val)
        {
            return Conversions.NumericToBoolean(val);
        }

        /// <summary>
        /// Concatenate strings together with a delimiter
        /// </summary>
        /// <param name="delimiter">A string containing the delimiter to be used between strings</param>
        /// <param name="val">First string to concatenate</param>
        /// <param name="val2">Second string to concatenate</param>
        /// <param name="val3">Third string to concatenate (optional)</param>
        /// <param name="val4">Fourth string to concatenate (optional)</param>
        /// <param name="val5">Fifth string to concatenate (optional)</param>
        /// <param name="val6">Sixth string to concatenate (optional)</param>
        /// <returns>A concatenated string</returns>
        public static string Join(this String val, string delimiter, string val2, string val3 = "", string val4 = "", string val5 = "", string val6 = "")
        {
            string joinedVal = "";

            joinedVal = IndividualStringTogether(delimiter, val, val2);
            joinedVal = IndividualStringTogether(delimiter, joinedVal, val3);
            joinedVal = IndividualStringTogether(delimiter, joinedVal, val4);
            joinedVal = IndividualStringTogether(delimiter, joinedVal, val5);
            joinedVal = IndividualStringTogether(delimiter, joinedVal, val6);

            return joinedVal;
        }

        /// <summary>
        /// Concatenate 2 strings together with a delimiter
        /// </summary>
        /// <param name="delimiter">A string containing the delimiter to be used between strings</param>
        /// <param name="str1">First string to concatenate</param>
        /// <param name="str2">Second string to concatenate</param>
        /// <returns>A concaenated string</returns>
        private static string IndividualStringTogether(string delimiter, string str1, string str2)
        {
            if (str1 != "" && str2 != "")
            {
                // Both strings exist - concatenate both strings with delimiter
                return str1 + delimiter + str2;
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

        /// <summary>
        /// Strings together items in a string array with the specified delimiter
        /// </summary>
        /// <param name="val"></param>
        /// <param name="delimiter">Delimiter to use between items in the array</param>
        /// <returns></returns>
        public static string Join(this String[] val, string delimiter)
        {
            string joinedVal = "";

            // Loop through array and join strings together
            for(int i = 0; i < val.Length; i++)
            {
                joinedVal = joinedVal.Join(delimiter, val[i]);
            }

            // Return constructed string
            return joinedVal;
        }

        /// <summary>
        /// Strings together items in an integer array with the specified delimiter
        /// </summary>
        /// <param name="val"></param>
        /// <param name="delimiter">Delimiter to use between items in the array</param>
        /// <returns></returns>
        public static string Join(this int[] val, string delimiter)
        {
            string joinedVal = "";

            // Loop through array and join strings together
            for (int i = 0; i < val.Length; i++)
            {
                joinedVal = joinedVal.Join(delimiter, val[i].ToString());
            }

            // Return constructed string
            return joinedVal;
        }

        /// <summary>
        /// Retrieves data by inspecting a string for start and end data tags
        /// </summary>
        /// <param name="data">String to inspect</param>
        /// <param name="startTag">Tag indicate start of data block</param>
        /// <param name="endTag">Tag to indicate end of data block</param>
        /// <param name="repositionTag">(optional) Tag to specify start of string inspection</param>
        /// <returns></returns>
        public static string GetData(this string data, string startTag, string endTag, string repositionTag = "")
        {
            string temp = "";
            int start = 0;
            int end = 0;

            // Don't continue if no data passed
            if (data == "")
            {
                return "";
            }

            // No tags passed - return data
            if (startTag == "" || endTag == "")
            {
                return data;
            }

            // Data doesn't contain tags
            if (data.ToLower().Contains(startTag.ToLower()) == false || data.ToLower().Contains(endTag.ToLower()) == false)
            {
                return "";
            }

            // Store data in temp string for formatting
            temp = data;

            // Reposition if tag passed
            if (repositionTag != "")
            {
                // Check data actually contains the reposition tag
                if (data.ToLower().Contains(repositionTag.ToLower()) == true)
                {
                    temp = temp.Substring(temp.ToLower().IndexOf(repositionTag.ToLower()) + repositionTag.Length);
                }
            }

            // Get position of start + end tags
            start = temp.IndexOf(startTag) + startTag.Length;
            end = temp.IndexOf(endTag, start);

            if (start != 0 && end != 0)
            {
                // Return data
                return temp.Substring(start, end - start).Trim();
            }
            else
            {
                // Data not found
                return "";
            }
        }

        /// <summary>
        /// Uses regular expression to remove HTML from passed text string
        /// </summary>
        /// <param name="text">A string to remove HTML from</param>
        /// <returns>A string with HTML removed</returns>
        public static string RemoveHTML(this string val)
        {
            System.Text.RegularExpressions.Regex regex = null;

            // Don't continue if nothing passed
            if (val == "")
            {
                return "";
            }

            // Define regex pattern
            regex = new System.Text.RegularExpressions.Regex("<[^>]*>");

            // Remove HTML from text
            return regex.Replace(val, " ").Trim();
        }
    }
}