//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tapyt.Websites.Base.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class DbSubject
    {
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public string Teaser { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<System.DateTime> DateDeleted { get; set; }
        public System.Guid AreaId { get; set; }
        public int Views { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Alias { get; set; }
    }
}