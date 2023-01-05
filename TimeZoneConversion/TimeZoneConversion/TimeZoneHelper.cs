using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZoneConversion
{
    public class TimeZoneHelper
    {
        public static DateTime ConvertDateTime(string sourceTimeZone, string destinationTimeZone, DateTime dateTime)
        {
            TimeZoneInfo resultSourceTimeZone = TimeZoneInfo.FindSystemTimeZoneById(sourceTimeZone);
            TimeZoneInfo resultDestinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(destinationTimeZone);
            DateTime destinationDateTime = TimeZoneInfo.ConvertTime(dateTime, resultSourceTimeZone, resultDestinationTimeZone);

            return destinationDateTime;
        }

        public static string IsDaylightSavingTime(string timeZone, DateTime dateTime)
        {
            TimeZoneInfo resultTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            bool isSavingTime = resultTimeZone.IsDaylightSavingTime(dateTime);
            var result = isSavingTime ? "Verano" : "Invierno";

            return result;
        }

        public static double DifferenceBetweenTimeZones(string sourceTimeZone, string destinationTimeZone) 
        {
            TimeZoneInfo resultSourceTimeZone = TimeZoneInfo.FindSystemTimeZoneById(sourceTimeZone);
            TimeZoneInfo resultDestinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(destinationTimeZone);
            double differenceInHours = (resultDestinationTimeZone.BaseUtcOffset - resultSourceTimeZone.BaseUtcOffset).TotalHours;

            return differenceInHours;
        }

        public static string DateFormat(DateTime dateTime)
        {
            string convertedDate = dateTime.ToString("yyyyMMdd");

            return convertedDate;
        }

        public static string TimeFormat(DateTime dateTime)
        {
            string convertedTime = dateTime.ToString("HHmmss");

            return convertedTime;
        }
    }
}
