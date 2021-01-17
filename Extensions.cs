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

        public static string Join(this String val, string delimiter, string val2, string val3 = "", string val4 = "", string val5 = "", string val6 = "")
        {
            return Generic.StringTogether(delimiter, val, val2, val3, val4, val5, val6);
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
                joinedVal = joinedVal.Join(delimiter, joinedVal, val[i]);
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
                joinedVal = joinedVal.Join(delimiter, joinedVal, val[i].ToString());
            }

            // Return constructed string
            return joinedVal;
        }
    }
}