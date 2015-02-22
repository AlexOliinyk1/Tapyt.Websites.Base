using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapyt.Websites.Base.DAL;
using Tapyt.Websites.Base.Services.Domain.Entry;
using Tapyt.Websites.Base.Services.Factory;

namespace Tapyt.Websites.Base.Services.Services
{
    public class EntryService
    {
        private EntryFactory _entryFactory;

        public EntryService()
        {
            this._entryFactory = new EntryFactory();
        }

        public Entry GetEntryById(Guid id)
        {
            using (var tapyt = new TapytEntities())
            {
                var dbTapyt = tapyt.DbEntry.FirstOrDefault(c => c.Id == id);

                if (dbTapyt == null)
                {
                    throw new ArgumentException("No entries with this ID");
                }

                var entry = _entryFactory.Create(dbTapyt);
                return entry;
            }
        }

        public List<Entry> GetEntriesBySpecifications(EntrySpecification spec)
        {
            using (var tapyt = new TapytEntities())
            {
                IQueryable<DbEntry> entries = tapyt.DbEntry;

                if (spec.SubjectIds.Any())
                {
                    entries = entries.Where(c => spec.SubjectIds.Contains(c.SubjectId));
                }

                var ent = _entryFactory.Create(entries.Skip(spec.Skip).Take(spec.Take).ToList());
                return ent;
            }
        }

        public Entry Create(Entry entry)
        {
            var newId = Guid.NewGuid();
            using (var tapyt = new TapytEntities())
            {
                var dbEntry = new DbEntry()
                {
                    DateCreated = DateTime.Now,
                    Downvote = 0,
                    Id = newId,
                    EntryType = (int) entry.EntryType,
                    Text = entry.Text,
                    Title = entry.Title,
                    SubjectId = entry.SubjectId,
                    Upvote = 0,
                    UserId = entry.UserId
                };

                tapyt.DbEntry.Add(dbEntry);
                tapyt.SaveChanges();
            }

            return GetEntryById(newId);
        }

    }
}
