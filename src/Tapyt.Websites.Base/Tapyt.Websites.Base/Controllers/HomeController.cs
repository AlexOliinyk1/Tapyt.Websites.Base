using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tapyt.Websites.Base.Models;
using Tapyt.Websites.Base.Services.Domain.Area;
using Tapyt.Websites.Base.Services.Services;

namespace Tapyt.Websites.Base.Controllers
{
    public class HomeController : Controller
    {
        private AreaService _areaService;

        public HomeController()
        {
            this._areaService = new AreaService();
        }

        public ActionResult Index()
        {
            var areas = _areaService.GetAreaBySpecification(new AreaSpecification()
            {
                Take = int.MaxValue
            });

            HomePageViewModel model =new HomePageViewModel();

            foreach (var area in areas)
            {
                model.Areas.Add(AreaController.setAreaViewModel(area));
            }

            return View(model);
        }

    }
}