using System;

namespace Talrand.Core
{
    public static class Extensions
    {
        public static byte ToNumeric(this Boolean val)
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
    }
}