//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebView.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class IkoGroupUser
    {
        public int ID { get; set; }
        public int IkoUserId { get; set; }
        public int IkoGroupID { get; set; }
    
        public virtual IkoGroup IkoGroup { get; set; }
        public virtual IkoUser IkoUser { get; set; }
    }
}