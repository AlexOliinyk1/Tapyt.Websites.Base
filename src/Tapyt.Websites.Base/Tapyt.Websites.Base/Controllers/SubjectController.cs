using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tapyt.Websites.Base.Models;
using Tapyt.Websites.Base.Services.Domain.Entry;
using Tapyt.Websites.Base.Services.Domain.Subject;
using Tapyt.Websites.Base.Services.Services;

namespace Tapyt.Websites.Base.Controllers
{
    public class SubjectController : Controller
    {
        private SubjectService _subjectService;
        private EntryService _entryService;

        public SubjectController()
        {
            _subjectService = new SubjectService();
            _entryService = new EntryService();
        }

        // GET: Subject
        public ActionResult Index(string alias)
        {
            var aliasL = alias.ToLower().Trim();

            var subject = _subjectService.GetSubjectsBySpecification(new SubjectSpecification()
            {
                Take = 1,
                Alias = new List<string>() {  aliasL}
            }).FirstOrDefault();

            if (subject == null)
            {
                throw new HttpException(404,"Not found");
            }

            var entries = _entryService.GetEntriesBySpecifications(new EntrySpecification()
            {
                Take = int.MaxValue,
                SubjectIds = new List<Guid>() { subject.Id }
            });

            var model = setSubjectViewModel(subject, entries);
            return View(model);
        }

        public ActionResult CreateSubject(Guid areaid)
        {
            return View(new CreateSubjectViewModel()
            {
                AreaId = areaid
            });
        }

        [HttpPost]
        public ActionResult CreateSubject(CreateSubjectViewModel model)
        {
            _subjectService.Create(new Subject()
            {
                Title = model.Title,
                Teaser = model.Teaser,
                MetaTitle = model.MetaTitle,
                MetaDescription = model.MetaDescription,
                AreaId = model.AreaId,
            
            });

            return View(new CreateSubjectViewModel()
            {
                AreaId = model.AreaId
            });
        }

        private SubjectViewModel setSubjectViewModel(Subject subject, List<Entry> entries)
        {
            var s = new SubjectViewModel()
            {
                Title = subject.Title,
                Teaser = subject.Teaser,
                Id = subject.Id
            };

            foreach (var entry in entries)
            {
                switch (entry.EntryType)
                {
                    case EntryType.Description:
                        s.Descriptions.Add(new DescriptionViewModel()
                        {
                            Title = entry.Title,
                            DownVotes = entry.DownVotes,
                            Id = entry.Id,
                            Text =entry.Text,
                            UpVotes = entry.UpVotes
                        });
                        break;
                    case EntryType.Video:
                        s.Videos.Add(new VideoViewModel()
                        {
                            Title = entry.Title,
                            DownVotes = entry.DownVotes,
                            
                            VideoUrl = entry.Text,
                            UpVotes = entry.UpVotes
                        });
                        break;
                    case EntryType.Note:
                        s.Notes.Add(new NoteViewModel()
                        {
                            Title = entry.Title,
                            DownVotes = entry.DownVotes,
                            Id = entry.Id,
                            Text = entry.Text,
                            UpVotes = entry.UpVotes
                        });
                        break;

                }
            }
            return s;
        }
    }
}