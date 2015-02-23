using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Tapyt.Websites.Base.Models
{
    public class SubjectViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Teaser { get; set; }
        public List<DescriptionViewModel> Descriptions { get; set; }
        public List<NoteViewModel> Notes { get; set; }
        public List<VideoViewModel> Videos { get; set; }

        public SubjectViewModel()
        {
            this.Descriptions = new List<DescriptionViewModel>();
            this.Notes = new List<NoteViewModel>();
            this.Videos = new List<VideoViewModel>();
        }
    }



    public class NoteViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
    }

    public class DescriptionViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
    }

    public class VideoViewModel
    {
        public string Title { get; set; }
        public string VideoUrl { get; set; }

        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
    }
}