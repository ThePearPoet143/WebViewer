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
    
    public partial class GenericAppConfig
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GenericAppConfig()
        {
            this.GenericAppScanConfigs = new HashSet<GenericAppScanConfig>();
            this.GenericAppConfig1 = new HashSet<GenericAppConfig>();
            this.SlideTypeAssociations = new HashSet<SlideTypeAssociation>();
            this.Studies = new HashSet<Study>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int GenericAppID { get; set; }
        public bool IsDefault { get; set; }
        public bool AllowEdit { get; set; }
        public Nullable<int> ManualGenericAppConfigID { get; set; }
        public string FilterGroupName { get; set; }
        public int TargetClassificationSetID { get; set; }
    
        public virtual GenericApp GenericApp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GenericAppScanConfig> GenericAppScanConfigs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GenericAppConfig> GenericAppConfig1 { get; set; }
        public virtual GenericAppConfig GenericAppConfig2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SlideTypeAssociation> SlideTypeAssociations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Study> Studies { get; set; }
        public virtual TargetClassificationSet TargetClassificationSet { get; set; }
    }
}
