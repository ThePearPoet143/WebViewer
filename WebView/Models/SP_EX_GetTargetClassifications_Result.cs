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
    
    public partial class SP_EX_GetTargetClassifications_Result
    {
        public int ID { get; set; }
        public int TargetClassificationSetID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Abbreviation { get; set; }
        public int SortSequence { get; set; }
        public Nullable<bool> ShowInMenu { get; set; }
        public Nullable<bool> IncludeInCount { get; set; }
        public string Rule { get; set; }
        public int RuleSequence { get; set; }
        public bool IsDefault { get; set; }
    }
}