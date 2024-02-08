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
    
    public partial class GenericApp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GenericApp()
        {
            this.GenericAppConfigs = new HashSet<GenericAppConfig>();
            this.GenericAppScans = new HashSet<GenericAppScan>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Abbreviation { get; set; }
        public int ReportID { get; set; }
        public bool AllowEdit { get; set; }
        public Nullable<int> GenericAppMethodID { get; set; }
        public string Reserved { get; set; }
        public bool AllowPurging { get; set; }
        public int Revision { get; set; }
    
        public virtual GenericAppMethod GenericAppMethod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GenericAppConfig> GenericAppConfigs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GenericAppScan> GenericAppScans { get; set; }
        public virtual Report Report { get; set; }
    }
}