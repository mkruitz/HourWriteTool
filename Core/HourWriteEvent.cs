﻿using System;

namespace Core
{
    public class HourWriteEvent
    {
        public String Id { get; set; }
        public DateTime HappendOn { get; set; }
        public HourWriteType Type { get; set; }
        public String Remark { get; set; }
        public Boolean IsDeleted { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", HappendOn, Type, Remark);
        }
    }

    public enum HourWriteType
    {
        StartWork,
        StartPauze,
        StopPauze,
        StopWork
    }
}
