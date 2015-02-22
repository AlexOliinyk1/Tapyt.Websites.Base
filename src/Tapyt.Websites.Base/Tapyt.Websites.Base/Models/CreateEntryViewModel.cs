using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tapyt.Websites.Base.Models
{
    public class CreateEntryViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid SubjectId { get; set; }
    }
}