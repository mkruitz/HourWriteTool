using System;
using System.Collections.Generic;

namespace Core
{
    public class Report : GroupOfEventsReport
    {
        public Report(IList<HourWriteEvent> events) : base(events)
        {
            WorkedOnDays = new Dictionary<DateTime, GroupOfEventsReport>();
            foreach (var pair in GroupByWorkingDay(events))
            {
                WorkedOnDays.Add(pair.Key, new GroupOfEventsReport(pair.Value));
            }
        }

        private Dictionary<DateTime, IList<HourWriteEvent>> GroupByWorkingDay(IEnumerable<HourWriteEvent> events)
        {
            var grouped = new Dictionary<DateTime, IList<HourWriteEvent>>();
            var currentKey = DateTime.MinValue;

            foreach (var evnt in events)
            {
                var potentialNewKey = evnt.HappendOn.Date;
                if (evnt.Type == HourWriteType.StartWork
                    && !grouped.ContainsKey(potentialNewKey))
                {
                    grouped.Add(potentialNewKey, new List<HourWriteEvent>());
                    currentKey = potentialNewKey;
                }

                grouped[currentKey].Add(evnt);
            }
            return grouped;
        }

        public Dictionary<DateTime, GroupOfEventsReport> WorkedOnDays { get; private set; }
    }
}