using System;

namespace NewModel.Helpers
{
    public static class Helpers
    {
        public static DateTime ToPstTime(this DateTime time)
        {
            var pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

            return TimeZoneInfo.ConvertTime(time, pst);
        }
    }
}
