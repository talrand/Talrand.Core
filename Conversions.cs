using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talrand.Core
{
    public class Conversions
    {
        /// <summary>
        /// Converts an integer value to a boolean value
        /// </summary>
        /// <param name="val">Integer to convert to boolean</param>
        /// <returns>Boolean</returns>
        public static bool NumericToBoolean(int val)
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
        public static byte BooleanToNumeric(bool val)
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

        /// <summary>
        /// Converts passed minutes value into milliseconds
        /// </summary>
        /// <param name="minutes">Number of minutes to convert</param>
        /// <returns>Converted milliseconds value</returns>
        public static int MinutesToMilliseconds(int minutes)
        {
            try
            {
                return minutes * 60000;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Converts passed seconds value into milliseconds 
        /// </summary>
        /// <param name="seconds">Number of seconds to converty</param>
        /// <returns>Converted milliseconds value</returns>
        public static int SecondsToMilliseconds(int seconds)
        {
            try
            {
                return seconds * 1000;
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
