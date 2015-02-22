using System;

namespace Tapyt.Websites.Base.Services.Domain.Subject
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Teaser { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
