using Core;
using Raven.Client.Embedded;

namespace GUI
{
    public class RavenStore : IStore
    {
        private readonly EmbeddableDocumentStore _store;

        public RavenStore()
        {
            _store = new EmbeddableDocumentStore
            {
                DataDirectory = "/"
            };
            _store.Initialize();
        }

        public void Save(HourWriteEvent writeEvent)
        {
            using (var session = _store.OpenSession())
            {
                session.Store(writeEvent);
                session.SaveChanges();
            }
        }
    }
}