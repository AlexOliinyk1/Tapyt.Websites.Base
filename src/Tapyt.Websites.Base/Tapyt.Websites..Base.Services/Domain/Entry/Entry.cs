using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapyt.Websites.Base.Services.Domain.Entry
{
    public class Entry
    {
        public Guid Id { get; set; }
        public EntryType EntryType { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public Guid? UserId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
