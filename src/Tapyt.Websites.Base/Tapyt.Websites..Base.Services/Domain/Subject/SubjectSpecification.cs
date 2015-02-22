using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapyt.Websites.Base.Services.Domain.Common;

namespace Tapyt.Websites.Base.Services.Domain.Subject
{
    public class SubjectSpecification:Specification
    {
        public List<Guid> AreaIds { get; set; }
        public List<string> Alias { get; set; }

        public SubjectSpecification()
        {
            this.AreaIds = new List<Guid>();
            this.Alias = new List<string>();
        }
    }
}
