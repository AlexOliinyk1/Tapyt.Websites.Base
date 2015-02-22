using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tapyt.Websites.Base.Models
{
    public class CreateSubjectViewModel
    {
        public Guid AreaId { get; set; }
        public string Title { get; set; }
        public string Teaser { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }
}