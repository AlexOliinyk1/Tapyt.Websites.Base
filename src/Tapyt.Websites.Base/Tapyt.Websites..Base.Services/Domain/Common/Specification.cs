using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapyt.Websites.Base.Services.Domain.Common
{
    public class Specification
    {
        public int Take { get; set; }
        public int Skip { get; set; }

        public Specification()
        {
            this.Take = 10;
        }
    }
}
