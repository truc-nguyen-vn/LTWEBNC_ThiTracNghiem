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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Threading.Tasks;
    using System.Web;

    public partial class NhanVien
    {
        [Display(Name = "ID Nhân viên")]
        public string IDNhanVien { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage ="{0} không được bỏ trống")]
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string Password { get; set; }
        [Display(Name = "Tên nhân viên")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string Name { get; set; }
        public string Avatar { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string Address { get; set; }
        [Display(Name = "ID Role")]
        public Nullable<int> IDRole { get; set; }

        public virtual Role Role { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadAvt { get; set; }

        internal static Task ChangePasswordAsync(object p, object oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }
        [Display(Name = "Xác nhận mật khẩu mới")]
        public string ConfirmNewPassword { get; set; }
    }
}
