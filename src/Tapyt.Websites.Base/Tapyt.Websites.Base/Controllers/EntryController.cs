using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tapyt.Websites.Base.Models;
using Tapyt.Websites.Base.Services.Domain.Entry;
using Tapyt.Websites.Base.Services.Services;

namespace Tapyt.Websites.Base.Controllers
{
    public class EntryController : Controller
    {
        private EntryService _entryService;
        private SubjectService _subjectService;

        public EntryController()
        {
            this._entryService = new EntryService();
            this._subjectService = new SubjectService();
        }

        // GET: Entry
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateEntry(Guid subjectId, EntryType type)
        {
            return View(new CreateEntryViewModel()
            {
                EntryType = type,
                SubjectId = subjectId
            });
        }

        [HttpPost]
        public ActionResult CreateEntry(CreateEntryViewModel model)
        {
            var entry = _entryService.Create(new Entry()
            {
                SubjectId = model.SubjectId,
                Title = model.Title,
                Text = model.Content,
                EntryType = model.EntryType
            });

            var subject = _subjectService.GetSubjectById(model.SubjectId);

            return RedirectToAction("Index", "Subject", new { alias = subject.Alias});
        }


    }
}