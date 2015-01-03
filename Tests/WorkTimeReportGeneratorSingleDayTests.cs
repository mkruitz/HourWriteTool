using System;
using System.Collections.Generic;
using Core;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WorkTimeReportGeneratorSingleDayTests : WorkTimeReportGeneratorTestBase
    {
        [Test]
        public void NoEvents_GenerateReport_NoHours()
        {
            var report = GetReport(new List<HourWriteEvent>());

            AssertTotalTimeWorked(report);
        }

        [Test]
        public void OneStartAndStopEvent_GenerateReport_OneHourAndTwoMinutesReported()
        {
            var report = GetReport(new List<HourWriteEvent>
            {
                new HourWriteEvent { HappendOn = DateTime.MinValue, Type = HourWriteType.StartWork },
                new HourWriteEvent { HappendOn = DateTime.MinValue.AddHours(1).AddMinutes(2), Type = HourWriteType.StopWork },
            });

            AssertTotalTimeWorked(report,
                expectedHours: 1,
                expectedMinutes: 2);
        }

        [Test]
        public void OneStartAndStopEventWithPauzeInBetween_GenerateReport_SevenMinutesOfWorkReported()
        {
            var start = DateTime.MinValue;
            var end = DateTime.MinValue.AddHours(1);

            var report = GetReport(new List<HourWriteEvent>
            {
                new HourWriteEvent { HappendOn = start, Type = HourWriteType.StartWork},
                new HourWriteEvent { HappendOn = start.AddMinutes(3), Type = HourWriteType.StartPauze },
                new HourWriteEvent { HappendOn = end.AddMinutes(-4), Type = HourWriteType.StopPauze },
                new HourWriteEvent { HappendOn = end, Type = HourWriteType.StopWork },
            });

            AssertTotalTimeWorked(report,
                expectedMinutes: 7);
        }


        [Test]
        public void OneStartAndStopEventOnNextDay_GenerateReport_OneDayAndOneHourReported()
        {
            var today = DateTime.MinValue;
            var tomorrow = today.AddDays(1);

            var report = GetReport(new List<HourWriteEvent>
            {
                new HourWriteEvent { HappendOn = today, Type = HourWriteType.StartWork },
                new HourWriteEvent { HappendOn = tomorrow.AddHours(1), Type = HourWriteType.StopWork },
            });

            AssertTotalTimeWorked(report,
                expectedDays: 1,
                expectedHours: 1);
        }

        [Test]
        public void TwoStartAndStopEvents_GenerateReport_TwoHoursReported()
        {
            var today = DateTime.MinValue;

            var report = GetReport(new List<HourWriteEvent>
            {
                new HourWriteEvent { HappendOn = today, Type = HourWriteType.StartWork },
                new HourWriteEvent { HappendOn = today.AddHours(1), Type = HourWriteType.StopWork },
                new HourWriteEvent { HappendOn = today.AddHours(2), Type = HourWriteType.StartWork },
                new HourWriteEvent { HappendOn = today.AddHours(3), Type = HourWriteType.StopWork },

            });

            AssertTotalTimeWorked(report,
                expectedHours: 2);
        }
    }
}
