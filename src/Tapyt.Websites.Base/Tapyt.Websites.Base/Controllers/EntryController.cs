using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tapyt.Websites.Base.Services.Domain.Entry;

namespace Tapyt.Websites.Base.Controllers
{
    public class EntryController : Controller
    {
        // GET: Entry
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateEntry(Guid subjectId, EntryType type)
        {
            
        }
    }
}