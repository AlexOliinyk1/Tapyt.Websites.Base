using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapyt.Websites.Base.Services.Domain.Common;

namespace Tapyt.Websites.Base.Services.Domain.Area
{
    public class AreaSpecification:Specification
    {
        public List<string> Alias { get; set; }

        public AreaSpecification()
        {
            this.Alias = new List<string>();
        }
    }
}
