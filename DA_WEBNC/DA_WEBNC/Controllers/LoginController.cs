﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA_WEBNC.Models;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DA_WEBNC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //private readonly TracNghiemOnlineEntities _database;
        //public LoginController(TracNghiemOnlineEntities database)
        //{
        //    _database = database;
        //}

        readonly TracNghiemOnlineEntities _database = new TracNghiemOnlineEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                //Mã hóa mật khẩu bằng MD5
                string password = HashPassword(loginModel.Password);

                var modelHS = _database.HocSinhs.Where(x => x.Email == loginModel.Email && x.Password == password).FirstOrDefault();
                var modelNV = _database.NhanViens.Where(x => x.Email == loginModel.Email && x.Password == password).FirstOrDefault();
                if (modelNV != null)
                {
                    //Khởi tạo (Set) Session["email"]
                    Session["email"] = loginModel.Email;
                    StaticAcc.Name = modelNV.Name;
                    StaticAcc.Role = modelNV.IDRole == 1 ? "Admin" : "NhanVien";

                    return RedirectToAction("Index", "Profile");
                }
                else if (modelHS != null)
                {
                    Session["email"] = loginModel.Email;
                    StaticAcc.Name = modelHS.Name;

                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.error = "Kiểm tra lại thông tin đăng nhập";
            return View(loginModel);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var model = new HocSinh
                {
                    IDStudent = GetIDHocSinh(),
                    Email = registerModel.Email,
                    Password = HashPassword(registerModel.Password),
                    Name = "Hãy cập nhật tên",
                    IDRole = 3
                };
                _database.HocSinhs.Add(model);
                await _database.SaveChangesAsync();
                return View("Login");

            }
            return View(registerModel);
        }
        [HttpGet]
        public ActionResult Logout()
        {
            //Delete Session
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
        public string GetIDHocSinh()
        {
            var list = _database.HocSinhs.ToArray();
            int[] listID = new int[list.Length];

            for (int i = 0; i < list.Length; i++)
            {
                int.TryParse(list[i].IDStudent.Substring(2), out listID[i]);
            }
            int lastID = 0;
            for (int i = 0; i < listID.Length; i++)
            {
                if (listID[i] > lastID)
                {
                    lastID = listID[i];
                }
            }
            string ID = "HS" + ++lastID;
            return ID;
          
        }


        //[HttpGet]
        //public ActionResult Reset()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<ActionResult> Reset(ResetPasswordModel resetModel)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var model = _database.HocSinhs.Where(x => x.Email == resetModel.Email).FirstOrDefault();
        //        if (model == null)
        //        {
        //            ViewBag.error = "Email không tồn tại trong hệ thống!";
        //            return View(resetModel);
        //        }

        //        //model.pass đã được set new password
        //        model.Password = GetPasswordRandom();
                
        //        await _database.SaveChangesAsync();

        //        #region Send mail
        //        MimeMessage message = new MimeMessage();

        //        MailboxAddress from = new MailboxAddress("H2T Moto", "h2t.moto.huflit@gmail.com");
        //        message.From.Add(from);

        //        MailboxAddress to = new(model.TenKh, model.Email);
        //        message.To.Add(to);

        //        message.Subject = "Reset Mật khẩu thành công";
        //        BodyBuilder bodyBuilder = new()
        //        {
        //            HtmlBody = $"<h1>Mật khẩu của bạn đã được reset, mật khẩu mới: {model.Pass}  </h1>",
        //            TextBody = "Mật Khẩu của bạn đã được thay đổi "
        //        };
        //        message.Body = bodyBuilder.ToMessageBody();
        //        // xac thuc email
        //        SmtpClient client = new();
        //        //connect (smtp address, port , true)
        //        await client.ConnectAsync("smtp.gmail.com", 465, true);
        //        await client.AuthenticateAsync("h2t.moto.huflit@gmail.com", "H2tmotohuflit");
        //        //send email
        //        await client.SendAsync(message);
        //        await client.DisconnectAsync(true);
        //        client.Dispose();
        //        #endregion
        //        ViewBag.success = "Hãy kiểm tra email của bạn để lấy mật khẩu mới!";

        //        return View("Login");
        //    }
        //    return View(resetModel);
        //}

        public string HashPassword(string password)
        {
            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            //nếu bạn muốn các chữ cái in thường thay vì in hoa thì bạn thay chữ "X" in hoa trong "X2" thành "x"
            return sb.ToString();
        }
        public string GetPasswordRandom()
        {
            Random rnd = new Random();
            string value = "";
            for (int i = 0; i < 6; i++)
            {
                value += rnd.Next(0, 9).ToString();
            }
            return value;
        }
    }
}