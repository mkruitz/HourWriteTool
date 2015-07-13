using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core;
using Raven.Client;
using Raven.Client.Embedded;

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
                RavenQueryStatistics stats;
                var temp = session.Query<HourWriteEvent>()
                    .Statistics(out stats)
                    .Take(1).ToList();

                return session.Query<HourWriteEvent>()
                    .Take(stats.TotalResults)
                    .OrderBy(evt => evt.HappendOn)
                    .ToList();
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