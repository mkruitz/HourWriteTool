using System.Collections.Generic;

namespace Core
{
    public interface IStore
    {
        void Save(HourWriteEvent writeEvent);
        IList<HourWriteEvent> GetEvents();
        void Clear();
    }
}
