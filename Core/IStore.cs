using System.Collections.Generic;

namespace Core
{
    public interface IStore : IStoreReader
    {
        void Save(HourWriteEvent writeEvent);
        void Clear();
    }

    public interface IStoreReader
    {
        IList<HourWriteEvent> GetEvents();
    }
}
