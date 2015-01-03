using System;
using System.Collections.Generic;

namespace Core
{
    public class GroupOfEventsReport
    {
        private readonly IEnumerable<HourWriteEvent> events;

        public GroupOfEventsReport(IEnumerable<HourWriteEvent> events)
        {
            this.events = events;
            SetProperties();
        }

        public TimeSpan TotalTimeWorked
        {
            get; private set;
        }

        private void SetProperties()
        {
            TotalTimeWorked = new TimeSpan();

            DateTime? start = null;
            DateTime? startBreak = null;
            DateTime? endBreak = null;
            foreach (var hourWriteEvent in events)
            {
                switch (hourWriteEvent.Type)
                {
                    case HourWriteType.StartWork:
                        start = hourWriteEvent.HappendOn;
                        break;
                    case HourWriteType.StartPauze:
                        startBreak = hourWriteEvent.HappendOn;
                        break;
                    case HourWriteType.StopPauze:
                        endBreak = hourWriteEvent.HappendOn;
                        break;
                    case HourWriteType.StopWork:
                        TotalTimeWorked += CalculateTime(start, hourWriteEvent.HappendOn) - CalculateTime(startBreak, endBreak);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private TimeSpan CalculateTime(DateTime? start, DateTime? end)
        {
            if(!start.HasValue || !end.HasValue)
                return new TimeSpan();

            return end.Value.Subtract(start.Value);
        }
    }
}