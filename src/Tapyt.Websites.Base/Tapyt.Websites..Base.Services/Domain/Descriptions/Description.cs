using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapyt.Websites.Base.Services.Domain.Descriptions
{
    public class Description
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateDeleted { get; set; }

        public int UpVote { get; set; }
        public int DownVote { get; set; }

    }
}
