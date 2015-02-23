using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tapyt.Websites.Base.Models
{
    public class CreateAreaViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}