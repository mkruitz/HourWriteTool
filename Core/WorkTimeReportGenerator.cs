using System.Linq;

namespace Core
{
    public class WorkTimeReportGenerator
    {
        private readonly IStoreReader store;

        public WorkTimeReportGenerator(IStoreReader storeReader)
        {
            store = storeReader;
        }

        public Report GetReport()
        {
            var events = store.GetEvents()
                .Where(e => !e.IsDeleted)
                .ToList();
            return new Report(events);
        }
    }
}