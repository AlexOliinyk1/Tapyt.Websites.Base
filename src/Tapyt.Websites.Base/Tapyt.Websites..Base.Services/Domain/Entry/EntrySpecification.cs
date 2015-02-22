using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapyt.Websites.Base.Services.Domain.Common;

namespace Tapyt.Websites.Base.Services.Domain.Entry
{
    public class EntrySpecification:Specification
    {
        public List<Guid> SubjectIds { get; set; }

        public EntrySpecification()
        {
            this.SubjectIds = new List<Guid>();
        }
    }
}
