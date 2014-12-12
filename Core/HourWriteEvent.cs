using System;

namespace Core
{
    public class HourWriteEvent
    {
        public DateTime HappendOn { get; set; }
        public HourWriteType Type { get; set; }
        public String Remark { get; set; }
    }

    public enum HourWriteType
    {
        StartWork,
        StartPauze,
        StopPauze,
        StopWork
    }
}
