namespace Core
{
    public interface IStore
    {
        void Save(HourWriteEvent writeEvent);
    }
}
