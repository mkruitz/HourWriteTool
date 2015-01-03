using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Core;
using Raven.Client.Embedded;
using Raven.Database.Server;

namespace GUI
{
    public class RavenStore : IStore
    {
        private readonly EmbeddableDocumentStore store;

        public RavenStore()
        {
            store = new EmbeddableDocumentStore
            {
                DataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data"),
            };
            store.Initialize();
        }

        public void Save(HourWriteEvent writeEvent)
        {
            using (var session = store.OpenSession())
            {
                session.Store(writeEvent);
                session.SaveChanges();
            }
        }

        public IList<HourWriteEvent> GetEvents()
        {
            using (var session = store.OpenSession())
            {
                return session.Query<HourWriteEvent>().ToList();
            }
        }

        public void Clear()
        {
            using (var session = store.OpenSession())
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