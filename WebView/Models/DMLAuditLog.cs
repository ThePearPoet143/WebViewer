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
    
    public partial class DMLAuditLog
    {
        public int ID { get; set; }
        public string TableName { get; set; }
        public Nullable<long> KeyID { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public System.DateTime PostTime { get; set; }
        public string HostName { get; set; }
        public string LoginName { get; set; }
        public Nullable<long> IkoLogsID { get; set; }
    }
}
