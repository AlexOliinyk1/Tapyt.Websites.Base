using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tapyt.Websites.Base.DAL;
using Tapyt.Websites.Base.Services.Domain.Subject;
using Tapyt.Websites.Base.Services.Factory;
using Tapyt.Websites.Base.Services.Utils;

namespace Tapyt.Websites.Base.Services.Services
{
    public class SubjectService
    {
        private SubjectFactory _subjectFactory;

        public SubjectService()
        {
         _subjectFactory = new SubjectFactory();   
        }

        public Subject GetSubjectById(Guid id)
        {
            using (var tapyt = new TapytEntities())
            {
                var dbTapyt = tapyt.DbSubject.FirstOrDefault(c => c.Id == id);

                if (dbTapyt == null)
                {
                    throw new ArgumentException("No");
                }

                var tap = _subjectFactory.Create(dbTapyt);
                return tap;
            }
        }

        public List<Subject> GetSubjectsBySpecification(SubjectSpecification specification)
        {
            using (var tapyt = new TapytEntities())
            {
                IQueryable<DbSubject> dbsubjects = tapyt.DbSubject;

                if (specification.AreaIds.Any())
                {
                    dbsubjects = dbsubjects.Where(c => specification.AreaIds.Contains(c.AreaId));
                }
                if (specification.Alias.Any())
                {
                    dbsubjects = dbsubjects.Where(c => specification.Alias.Contains(c.Alias));
                }

                var subjects =
                    _subjectFactory.Create(dbsubjects.OrderBy(c=>c.Id).Skip(specification.Skip).Take(specification.Take).ToList());

                return subjects;
            }
         
        }

        public Subject Create(Subject subject)
        {
            var newId = Guid.NewGuid();
            using (var tapyt = new TapytEntities())
            {
                var dbSubject = new DbSubject()
                {
                    Alias = Helpers.GenerateSlug(subject.Title),
                    AreaId = subject.AreaId,
                    DateCreated = DateTime.Now,
                    MetaDescription = string.Empty,
                    MetaTitle = string.Empty,
                    Id = newId,
                    Teaser = subject.Teaser,
                    Title = subject.Title,
                    Views = 0
                };

                tapyt.DbSubject.Add(dbSubject);
                tapyt.SaveChanges();
            }

            return GetSubjectById(newId);
        }
    }
}
