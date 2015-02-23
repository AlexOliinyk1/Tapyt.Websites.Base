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

        public ActionResult UpdateArea(Guid id)
        {
            var area = _areaService.GetAreaById(id);

            return View(SetCreateAreaViewModel(area));
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateArea(CreateAreaViewModel model)
        {

            var area = _areaService.GetAreaById(model.Id);
            area.Text = model.Text;
            area.Title = model.Title;

            _areaService.Update(area);

            return RedirectToAction("Index", "Area", new {alias = area.Alias});

        }


        [ValidateInput(false)]
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


        public static CreateAreaViewModel SetCreateAreaViewModel(Area area)
        {
            return new CreateAreaViewModel()
            {
                Title = area.Title,
                Id = area.Id,
                Text = area.Text
            };
        }

        public static AreaViewModel setAreaViewModel(Area area)
        {
            AreaViewModel v = new AreaViewModel()
            {
                Title = area.Title,
                Text = area.Text,
                Id = area.Id,
                Alias = area.Alias
            };

            return v;
        }
    }
}