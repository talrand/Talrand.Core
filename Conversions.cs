using System;

namespace Talrand.Core
{
    public static class Conversions
    {
        /// <summary>
        /// Converts an integer value to a boolean value
        /// </summary>
        /// <param name="val">Integer to convert to boolean</param>
        /// <returns>Converted boolean value</returns>
        public static bool NumericToBoolean(int val)
        {
            if (val == 1)
            {
                return true;
            }
            
            return false;
        }

        /// <summary>
        /// Converts a boolean value to a byte value
        /// </summary>
        /// <param name="val">Boolean to convert to byte</param>
        /// <returns>Converted numeric value</returns>
        public static byte BooleanToNumeric(bool val)
        {
            if (val == true)
            {
                return 1;
            }
            
            return 0;
        }

        /// <summary>
        /// Converts passed minutes value into milliseconds
        /// </summary>
        /// <param name="minutes">Number of minutes to convert</param>
        /// <returns>Converted milliseconds value</returns>
        public static int MinutesToMilliseconds(int minutes)
        {
            return minutes * 60000;
        }

        /// <summary>
        /// Converts passed seconds value into milliseconds 
        /// </summary>
        /// <param name="seconds">Number of seconds to converty</param>
        /// <returns>Converted milliseconds value</returns>
        public static int SecondsToMilliseconds(int seconds)
        {
            return seconds * 1000;
        }
    }
}