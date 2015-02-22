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
    public class AreaController : Controller
    {
        private AreaService _areaService;

        public AreaController()
        {
            _areaService = new AreaService();
        }

        // GET: Area
        public ActionResult Index(string alias)
        {
            var aliasL = alias.ToLower().Trim();
            var area = _areaService.GetAreaBySpecification(new AreaSpecification()
            {
                Take = 1,
                Alias = new List<string>() {aliasL}
            }).FirstOrDefault();


            if (area == null)
            {
                throw new HttpException(404, "Not found");
            }

            var model = setAreaViewModel(area);
            return View(model);
        }

        public ActionResult CreateArea()
        {
            return View(new CreateAreaViewModel());
        }

        [HttpPost]
        public ActionResult CreateArea(CreateAreaViewModel model)
        {

            _areaService.Create(new Area()
            {
                Text = model.Text,
                Title = model.Title
            });

            return View(new CreateAreaViewModel());
        }


        public static AreaViewModel setAreaViewModel(Area area)
        {
            AreaViewModel v = new AreaViewModel()
            {
                Title = area.Title,
                Text = area.Text,
                Id = area.Id
            };

            return v;
        }
    }
}