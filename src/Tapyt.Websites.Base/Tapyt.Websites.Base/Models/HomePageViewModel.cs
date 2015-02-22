using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tapyt.Websites.Base.Models
{
    public class HomePageViewModel
    {
        public List<AreaViewModel> Areas { get; set; }

        public HomePageViewModel()
        {
            this.Areas = new List<AreaViewModel>();
        }
    }
}