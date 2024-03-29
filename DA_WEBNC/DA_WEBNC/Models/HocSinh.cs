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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class HocSinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocSinh()
        {
            this.BaiThiHS = new HashSet<BaiThiH>();
        }

        [Display(Name = "ID Học sinh")]
        public string IDStudent { get; set; }
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string Password { get; set; }
        [Display(Name = "Tên học sinh")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string Name { get; set; }
        public string Avatar { get; set; }
        [Display(Name = "ID Role")]
        public Nullable<int> IDRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiThiH> BaiThiHS { get; set; }
        public virtual Role Role { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadAvt { get; set; }
    }
}
