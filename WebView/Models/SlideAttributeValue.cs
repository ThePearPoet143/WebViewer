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
    
    public partial class SlideAttributeValue
    {
        public int ID { get; set; }
        public int SlideID { get; set; }
        public int AttributeID { get; set; }
        public string Value { get; set; }
    
        public virtual Slide Slide { get; set; }
        public virtual SlideAttribute SlideAttribute { get; set; }
    }
}