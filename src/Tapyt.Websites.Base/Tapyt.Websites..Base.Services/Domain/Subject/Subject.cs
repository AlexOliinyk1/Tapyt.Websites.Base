using System;

namespace Tapyt.Websites.Base.Services.Domain.Subject
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Teaser { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Guid AreaId { get; set; }
        public int Views { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Alias { get; set; }
    }
}
