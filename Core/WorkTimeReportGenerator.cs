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
            return new Report(store.GetEvents());
        }
    }
}