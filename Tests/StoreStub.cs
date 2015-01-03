using System.Collections.Generic;
using Core;

namespace Tests
{
    public class StoreStub : IStoreReader
    {
        public StoreStub()
        {
            Events = new List<HourWriteEvent>();
        }

        public IList<HourWriteEvent> Events { get; set; }

        public IList<HourWriteEvent> GetEvents()
        {
            return Events;
        }
    }
}