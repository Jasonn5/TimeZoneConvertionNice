using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeZoneConversion;

namespace Tests
{
    [TestClass]
    public class TimeZoneConversionTests
    {
        [TestMethod]
        public void Convert_ConvertDateTimeToAnotherTimeZone() 
        {
            string sourceTimeZone = "GMT";
            string destinationTimeZone = "EAT";
            DateTime dateTimeSent = new DateTime(2023, 1, 5, 0, 21, 0);
            DateTime dateTimeExpected = new DateTime(2023, 1, 5, 3, 21, 0);

            DateTime result = TimeZoneHelper.ConvertDateTime(sourceTimeZone, destinationTimeZone, dateTimeSent);

            Assert.AreEqual(dateTimeExpected, result);
        }

        [TestMethod]
        public void DaylightTime_GetIfDaylightOrWinterTimer()
        {
            string timeZone = "EAT";
            DateTime dateTimeSent = new DateTime(2023, 1, 5, 0, 21, 0);
            string resultExpected = "Invierno";

            string result = TimeZoneHelper.IsDaylightSavingTime(timeZone, dateTimeSent);

            Assert.AreEqual(resultExpected, result);
        }

        [TestMethod]
        public void DifferenceBetweenTimeZones_GetInHourDifferenceBetweenTimeZones()
        {
            string timeZoneOne = "GMT";
            string timeZoneTwo = "EAT";
            double resultExpected = 3.0;

            double result = TimeZoneHelper.DifferenceBetweenTimeZones(timeZoneOne, timeZoneTwo);

            Assert.AreEqual(resultExpected, result);
        }

        [TestMethod]
        public void DateFormat_GetDateInAFormat()
        {
            DateTime dateTimeSent = new DateTime(2023, 1, 5, 0, 21, 0);
            string resultExpected = "20230105";

            string result = TimeZoneHelper.DateFormat(dateTimeSent);

            Assert.AreEqual(resultExpected, result);
        }

        [TestMethod]
        public void TimeFormat_GetTimeInAFormat()
        {
            DateTime dateTimeSent = new DateTime(2023, 1, 5, 10, 12, 0);
            string resultExpected = "101200";

            string result = TimeZoneHelper.TimeFormat(dateTimeSent);

            Assert.AreEqual(resultExpected, result);
        }
    }
}
