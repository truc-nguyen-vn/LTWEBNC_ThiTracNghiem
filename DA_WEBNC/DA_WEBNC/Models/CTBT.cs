//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DA_WEBNC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTBT
    {
        public string IDBaiThi { get; set; }
        public string IDCauHoi { get; set; }
        public string CauHoi { get; set; }
    
        public virtual BaiThi BaiThi { get; set; }
        public virtual CauHoi CauHoi1 { get; set; }
    }
}