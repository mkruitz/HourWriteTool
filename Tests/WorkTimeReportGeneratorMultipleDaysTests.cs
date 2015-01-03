using System;
using System.Collections.Generic;
using Core;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WorkTimeReportGeneratorMultipleDaysTests : WorkTimeReportGeneratorTestBase
    {
        [Test]
        public void TwoStartAndStopEventsOnDifferentDaysStarted_GenerateReport_TwoDaysOneHourReported()
        {
            var today = DateTime.MinValue;
            var tomorrow = today.AddDays(1);

            var report = GetReport(new List<HourWriteEvent>
            {
                new HourWriteEvent {HappendOn = today, Type = HourWriteType.StartWork},
                new HourWriteEvent {HappendOn = today.AddHours(1), Type = HourWriteType.StopWork},
                new HourWriteEvent {HappendOn = tomorrow, Type = HourWriteType.StartWork},
                new HourWriteEvent {HappendOn = tomorrow.AddHours(3), Type = HourWriteType.StopWork},

            });

            AssertTotalTimeWorked(report,
                expectedHours: 4);
            Assert.AreEqual(2, report.WorkedOnDays.Count);
            AssertTotalTimeWorked(report.WorkedOnDays[today],
                expectedHours: 1);
            AssertTotalTimeWorked(report.WorkedOnDays[tomorrow],
                expectedHours: 3);
        }
    }
}