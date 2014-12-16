using System.Collections.Generic;
using System.Linq;
using Core;
using Raven.Client.Embedded;
using Raven.Database.Server;

namespace GUI
{
    public class RavenStore : IStore
    {
        private readonly EmbeddableDocumentStore _store;

        public RavenStore()
        {
            _store = new EmbeddableDocumentStore
            {
                DataDirectory = "D:\\RavenDB\\Data\\",
                //DefaultDatabase = "HourWriteTool"
                //UseEmbeddedHttpServer = true,
            };
            //NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8081);
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

        public IList<HourWriteEvent> GetEvents()
        {
            using (var session = _store.OpenSession())
            {
                return session.Query<HourWriteEvent>().ToList();
            }
        }

        public void Clear()
        {
            using (var session = _store.OpenSession())
            {
                foreach(var writeEvent in session.Query<HourWriteEvent>())
                {
                    session.Delete(writeEvent);
                }
                session.SaveChanges();
            }
        }
    }
}