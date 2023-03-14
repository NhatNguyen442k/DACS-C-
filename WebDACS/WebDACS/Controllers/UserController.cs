using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebDACS.Models;
using WebDACS.Models.ViewModel;

namespace WebDACS.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        AppDataContext data = new AppDataContext();
        public ActionResult Dangky()
        {
            var uservm = new UserroleViewModel
            {
                Rolies = data.Roless.ToList()
            };
            return View(uservm);
        }
        [HttpPost]
        public ActionResult Dangky(UserroleViewModel useries)
        {
            if (!ModelState.IsValid)
            {
                return View("Dangky");
            }
            var check = data.Useries.FirstOrDefault(n => n.Email == useries.Email);
            if (check == null)
            {
                var us = new Users
                {
                    Username = useries.Username,
                    Userpassword = useries.Userpassword,
                    Email = useries.Email,
                    Displayname = useries.Displayname,
                    Avatar = useries.Avatar,
                    DateCreate = DateTime.Now,
                    IDrole = 2
                };
                data.Useries.Add(us);
                data.SaveChanges();
                return RedirectToAction("Home", "Film");
            }
            else
            {
                ViewBag.error = "Email đã đăng ký";
                return View();
            }
        }

        public static string GETMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte25string = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte25string += targetData[i].ToString("x2");
            }
            return byte25string;
        }

        public string ProcessUpload3(HttpPostedFileBase file3)
        {
            if (file3 == null)
            {
                return "";
            }
            file3.SaveAs(Server.MapPath("~/Content/Images/Avatar/" + file3.FileName));
            return "/Content/Images/Avatar/" + file3.FileName;
        }

        [HttpGet]
        public ActionResult Dangnhap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection cls,Users useries)
        {
            var em = cls["Email"];
            var mk = cls["Userpassword"];
            var idr = useries.IDrole;
            var check1 = data.Useries.FirstOrDefault(n => n.Email == em && n.Userpassword == mk);
            if (check1 != null)
            {
                if (check1.IDrole == 1) 
                {
                    Session["Taikhoan"] = check1;
                }
                else
                {
                    Session["TaikhoanAdmin"] = check1;
                }
                Session["Bietdanh"] = check1.Displayname;
                return RedirectToAction("Home", "Film");
            }
            else
            {
                ViewBag.Error = "Tài khoản không đúng hoặc chưa đăng ký";
                return RedirectToAction("Dangnhap");
            }
        }

        public ActionResult Dangxuat()
        {
            Session.Clear();
            return RedirectToAction("Home", "Film");
        }

        public ActionResult Changeinfouser(int id)
        {
            var edu = data.Useries.FirstOrDefault(n => n.Iduser == id);
            return View(edu);
        }
        public ActionResult Changeinfouser(int id, FormCollection cls, HttpPostedFileBase Upload4)
        {
            var ed = data.Useries.FirstOrDefault(n => n.Iduser == id);
            ed.Iduser = id;
            var tenvn = cls["Username"];
            var bietdanh = cls["Displayname"];
            var email = cls["Email"];
            var anh = cls["Avatar"];
            var mk = cls["Userpassword"];
            var ngaytao = Convert.ToDateTime(cls["DateCreate"]);
            if (string.IsNullOrEmpty(tenvn))
            {
                ViewData["Error"] = "Có lỗi!!";
            }
            else
            {
                ed.Username = tenvn.ToString();
                ed.Userpassword = mk.ToString();
                ed.Displayname = bietdanh.ToString();
                ed.Email = email.ToString();
                ed.Avatar = anh.ToString();
                ed.DateCreate = ngaytao;
                UpdateModel(ed);
                data.SaveChanges();
                return RedirectToAction("Home","Film");
            }
            return this.Changeinfouser(id);
        }
        public string ProcessUpload4(HttpPostedFileBase file4)
        {
            if (file4 == null)
            {
                return "";
            }
            file4.SaveAs(Server.MapPath("~/Content/Images/Avatar/" + file4.FileName));
            return "/Content/Images/Avatar/" + file4.FileName;
        }
    }
}