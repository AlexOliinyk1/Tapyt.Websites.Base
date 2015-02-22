using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapyt.Websites.Base.DAL;
using Tapyt.Websites.Base.Services.Domain.Entry;

namespace Tapyt.Websites.Base.Services.Factory
{
    public class EntryFactory
    {
        public Entry Create(DbEntry dbEntry)
        {
            return new Entry()
            {
                DateCreated = dbEntry.DateCreated,
                DateDeleted = dbEntry.DateDeleted,
                DateModified = dbEntry.DateModified,
                DownVotes = dbEntry.Downvote,
                EntryType = (EntryType)dbEntry.EntryType,
                Id = dbEntry.Id,
                SubjectId = dbEntry.SubjectId,
                Text = dbEntry.Text,
                Title = dbEntry.Title,
                UpVotes = dbEntry.Upvote,
                UserId = dbEntry.UserId
            };
        }

        public List<Entry> Create(List<DbEntry> entries)
        {
            return entries.Select(Create).ToList();
        }
    }
}
