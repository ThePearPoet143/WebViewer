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
    
    public partial class TargetStatistic
    {
        public int ID { get; set; }
        public int TargetClassificationSetID { get; set; }
        public int TargetClassificationID { get; set; }
        public int StatisticsSetID { get; set; }
        public bool IsDefault { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Abbreviation { get; set; }
        public string Rules { get; set; }
    
        public virtual TargetClassification TargetClassification { get; set; }
    }
}
