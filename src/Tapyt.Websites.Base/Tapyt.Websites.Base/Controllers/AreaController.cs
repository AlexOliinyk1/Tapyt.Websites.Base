using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tapyt.Websites.Base.Controllers
{
    public class AreaController : Controller
    {
        public AreaController()
        {
            
        }

        // GET: Area
        public ActionResult Index()
        {
            return View();
        }
    }
}