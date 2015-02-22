using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tapyt.Websites.Base.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index(string alias)
        {
            return View();
        }
    }
}