﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations;

    public partial class CauHoi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CauHoi()
        {
            this.CTBTs = new HashSet<CTBT>();
        }


        [Display(Name = "ID Câu hỏi")]
        public string IDCauHoi { get; set; }
        [Display(Name = "Câu hỏi")]
        [Required]
        public string CauHoi1 { get; set; }
        [Required]
        public string A { get; set; }
        [Required]
        public string B { get; set; }
        [Required]
        public string C { get; set; }
        [Required]
        public string D { get; set; }

        [Display(Name = "Đáp án")]
        public string DapAn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTBT> CTBTs { get; set; }
    }
}
