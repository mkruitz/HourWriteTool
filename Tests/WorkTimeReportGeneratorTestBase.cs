using System.Collections.Generic;
using Core;
using NUnit.Framework;

namespace Tests
{
    public class WorkTimeReportGeneratorTestBase 
    {
        protected Report GetReport(IList<HourWriteEvent> events)
        {
            return new WorkTimeReportGenerator(new StoreStub
            {
                Events = events
            }).GetReport();
        }

        protected void AssertTotalTimeWorked(GroupOfEventsReport report, int expectedDays = 0, int expectedHours = 0, int expectedMinutes = 0)
        {
            Assert.AreEqual(expectedDays, report.TotalTimeWorked.Days);
            Assert.AreEqual(expectedHours, report.TotalTimeWorked.Hours);
            Assert.AreEqual(expectedMinutes, report.TotalTimeWorked.Minutes);
        }
    }
}