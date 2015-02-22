using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tapyt.Websites.Base.Models
{
    public class SubjectViewModel
    {
        public string Title { get; set; }
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
        public string Title { get; set; }
    }

    public class DescriptionViewModel
    {
        public string Title { get; set; }
    }

    public class VideoViewModel
    {
        public string Title { get; set; }
        public string VideoUrl { get; set; }
    }
}