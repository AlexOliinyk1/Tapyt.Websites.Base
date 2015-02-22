using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapyt.Websites.Base.DAL;
using Tapyt.Websites.Base.Services.Domain.Subject;

namespace Tapyt.Websites.Base.Services.Factory
{
    public class SubjectFactory
    {
        public Subject Create(DbSubject dbSubject)
        {
            return new Subject()
            {
                Views = dbSubject.Views,
                DateDeleted = dbSubject.DateDeleted,
                Alias = dbSubject.Alias,
                AreaId = dbSubject.AreaId,
                DateModified = dbSubject.DateModified,
                DateCreated = dbSubject.DateCreated,
                Id = dbSubject.Id,
                MetaDescription = dbSubject.MetaDescription,
                MetaTitle = dbSubject.MetaTitle,
                Title = dbSubject.Title,
                Teaser = dbSubject.Teaser
            };
        }

        public List<Subject> Create(List<DbSubject> dbsubjects)
        {
            return dbsubjects.Select(Create).ToList();
        }
    }
}
