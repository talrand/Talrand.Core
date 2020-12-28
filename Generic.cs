using System;

namespace Talrand.Core
{
    public class Generic
    {
        /// <summary>
        /// Retrieves data by inspecting a string for start and end data tags
        /// </summary>
        /// <param name="data">String to inspect</param>
        /// <param name="startTag">Tag indicate start of data block</param>
        /// <param name="endTag">Tag to indicate end of data block</param>
        /// <param name="repositionTag">(optional) Tag to specify start of string inspection</param>
        /// <returns></returns>
        public static string GetDataFromString(string data, string startTag, string endTag, string repositionTag = "")
        {
            string temp = "";
            int start = 0;
            int end = 0;

            try
            {
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Concatenate strings together with a delimiter
        /// </summary>
        /// <param name="delimiter">A string containing the delimiter to be used between strings</param>
        /// <param name="str1">First string to concatenate</param>
        /// <param name="str2">Second string to concatenate</param>
        /// <param name="str3">Third string to concatenate (optional)</param>
        /// <param name="str4">Fourth string to concatenate (optional)</param>
        /// <param name="str5">Fifth string to concatenate (optional)</param>
        /// <param name="str6">Sixth string to concatenate (optional)</param>
        /// <returns>A concatenated string</returns>
        public static string StringTogether(string delimiter, string str1, string str2, string str3 = "", string str4 = "", string str5 = "", string str6 = "")
        {
            string temp = "";
            try
            {
                temp = IndividualStringTogether(delimiter, str1, str2);
                temp = IndividualStringTogether(delimiter, temp, str3);
                temp = IndividualStringTogether(delimiter, temp, str4);
                temp = IndividualStringTogether(delimiter, temp, str5);
                temp = IndividualStringTogether(delimiter, temp, str6);

                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Uses regular expression to remove HTML from passed text string
        /// </summary>
        /// <param name="text">A string to remove HTML from</param>
        /// <returns>A string with HTML removed</returns>
        public static string RemoveHTML(string text)
        {
            System.Text.RegularExpressions.Regex regex = null;

            try
            {
                // Don't continue if nothing passed
                if (text == "")
                {
                    return "";
                }

                // Define regex pattern
                regex = new System.Text.RegularExpressions.Regex("<[^>]*>");

                // Remove HTML from text
                return regex.Replace(text, " ").Trim();
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
        /// <param name="val">Integer to convert to boolean</param>
        /// <returns>Boolean</returns>
        public static bool ConvertNumericToBoolean(int val)
        {
            try
            {
                if (val == 1)
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
        /// <param name="val">Boolean to convert to byte</param>
        /// <returns></returns>
        public static byte ConvertBooleanToNumeric(bool val)
        {
            try
            {
                if (val == true)
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