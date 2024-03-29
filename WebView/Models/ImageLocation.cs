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
    
    public partial class ImageLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImageLocation()
        {
            this.Scanners = new HashSet<Scanner>();
            this.SlideRuns = new HashSet<SlideRun>();
            this.SlideRunBrightFields = new HashSet<SlideRunBrightField>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool IsDefault { get; set; }
        public int WarnThresholdInGB { get; set; }
        public int NewSlideThresholdInGB { get; set; }
        public string Share { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Scanner> Scanners { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SlideRun> SlideRuns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SlideRunBrightField> SlideRunBrightFields { get; set; }
    }
}
