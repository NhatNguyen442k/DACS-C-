using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDACS.Models;
using WebDACS.Models.ViewModel;

namespace WebDACS.Controllers
{
    public class AdminController : Controller
    {
        AppDataContext data = new AppDataContext();
        // GET: User
        public ActionResult ControlPhim(int? page)
        {
            if (page == null) page = 1;
            var film = (from s in data.Films
                        select s).OrderBy(n => n.IdFilm);
            int pageSize = 5;
            int pageNum = page ?? 1;
            return View(film.ToPagedList(pageNum, pageSize));
        }
        public ActionResult ControlUser()
        {
            var us = from s in data.Useries
                     select s;
            return View(us);
        }

        public ActionResult AdminP()
        {
            return View();
        }
        public ActionResult CreateFilm()
        {
            SetViewType();
            return View();
        }
        public void SetViewType()
        {
            var ty = new Film();
            ViewBag.TypeFilm = new SelectList(ty.ListAll(), "TypeFilm", "TypeFilm");
        }
        [HttpPost]
        public ActionResult CreateFilm(Film films, HttpPostedFileBase Upload)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateFilm");
            }
            var fs = new Film
            {
                NameVN = films.NameVN,
                NameF = films.NameF,
                Images = films.Images,
                Status = films.Status,
                Director = films.Director,
                Nation = films.Nation,
                Times = films.Times,
                TypeFilm = films.TypeFilm,
                Rating = films.Rating,
                Years = films.Years,
                Information = films.Information,
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now
            };
            data.Films.Add(fs);
            data.SaveChanges();
            return RedirectToAction("AdminP", "Admin");
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/Images/Phim/" + file.FileName));
            return "/Content/Images/Phim/" + file.FileName;
        }

        public ActionResult EditFilm(int id)
        {
            var ed = data.Films.First(n => n.IdFilm == id);
            return View(ed);
        }
        [HttpPost]
        public ActionResult EditFilm(int id, FormCollection cls, HttpPostedFileBase Upload1)
        {
            var ed = data.Films.First(n => n.IdFilm == id);
            ed.IdFilm = id;
            var tenvn = cls["NameVN"];
            var tenreal = cls["NameF"];
            var daodien = cls["Director"];
            var quocgia = cls["Nation"];
            var anh = cls["Images"];
            var nam = Convert.ToInt32(cls["Year"]);
            var trangthai = cls["Status"];
            var thoiluong = Convert.ToInt32(cls["Time"]);
            var luotxem = Convert.ToInt32(cls["Rating"]);
            var loaiphim = cls["TypeFilm"];
            var noidung = cls["Information"];
            var ngaydang = Convert.ToDateTime(cls["DateCreate"]);
            var ngaycapnhat = Convert.ToDateTime(cls["DateUpdate"]);
            if (string.IsNullOrEmpty(tenvn))
            {
                ViewData["Error"] = "Có lỗi!!";
            }
            else
            {
                ed.NameVN = tenvn.ToString();
                ed.NameF = tenreal.ToString();
                ed.Director = daodien.ToString();
                ed.Nation = quocgia.ToString();
                ed.Years = nam;
                ed.Images = anh.ToString();
                ed.Status = trangthai.ToString();
                ed.Times = thoiluong;
                ed.Rating = luotxem;
                ed.TypeFilm = loaiphim.ToString();
                ed.Information = noidung.ToString();
                ed.DateCreate = ngaydang;
                ed.DateUpdate = DateTime.Now;
                UpdateModel(ed);
                data.SaveChanges();
                return RedirectToAction("ControlPhim");
            }
            return this.EditFilm(id);
        }
        public string ProcessUpload1(HttpPostedFileBase file1)
        {
            if (file1 == null)
            {
                return "";
            }
            file1.SaveAs(Server.MapPath("~/Content/Images/Phim/" + file1.FileName));
            return "/Content/Images/Phim/" + file1.FileName;
        }
        public ActionResult DeleteFilm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film fms = data.Films.Find(id);
            if (fms == null)
            {
                return HttpNotFound();
            }
            return View(fms);
        }
        [HttpPost, ActionName("DeleteFilm")]
        public ActionResult DeleteFilmms(int id, FormCollection cls)
        {
            Film fmss = data.Films.Find(id);
            data.Films.Remove(fmss);
            data.SaveChanges();
            return RedirectToAction("AdminP");
        }

        public ActionResult EditUser(int id)
        {
            var edu = data.Useries.First(n => n.Iduser == id);
            return View(edu);
        }
        [HttpPost]
        public ActionResult EditUser(int id, FormCollection cls, HttpPostedFileBase Upload2)
        {
            var ed = data.Useries.First(n => n.Iduser == id);
            ed.Iduser = id;
            var tenvn = cls["Username"];
            var matkhau = cls["Userpassword"];
            var bietdanh = cls["Displayname"];
            var email = cls["Email"];
            var anh = cls["Avatar"];
            var ngaytao = Convert.ToDateTime(cls["DateCreate"]);
            var idr = cls["IDrole"];
            if (string.IsNullOrEmpty(tenvn))
            {
                ViewData["Error"] = "Có lỗi!!";
            }
            else
            {
                ed.Username = tenvn.ToString();
                ed.Userpassword = matkhau.ToString();
                ed.Displayname = bietdanh.ToString();
                ed.Email = email.ToString();
                ed.Avatar = anh.ToString();
                ed.DateCreate = ngaytao;
                ed.IDrole = int.Parse(idr);
                UpdateModel(ed);
                data.SaveChanges();
                return RedirectToAction("ControlUser");
            }
            return this.EditUser(id);
        }
        public string ProcessUpload2(HttpPostedFileBase file2)
        {
            if (file2 == null)
            {
                return "";
            }
            file2.SaveAs(Server.MapPath("~/Content/Images/Avatar/" + file2.FileName));
            return "/Content/Images/Avatar/" + file2.FileName;
        }
        public ActionResult DeleteUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users fms = data.Useries.Find(id);
            if (fms == null)
            {
                return HttpNotFound();
            }
            return View(fms);
        }
        [HttpPost, ActionName("DeleteUser")]
        public ActionResult DeleteUseries(int id, FormCollection cls)
        {
            Users fmss = data.Useries.Find(id);
            data.Useries.Remove(fmss);
            data.SaveChanges();
            return RedirectToAction("ControlUser");
        }

        public ActionResult SetTL()
        {
            var vmc = new SetCategoriesViewModel
            {
                Categories = data.Categories.ToList(),
                Films = data.Films.ToList()
            };
            return View(vmc);
        }
        [HttpPost]
        public ActionResult SetTL(int id,SetCategoriesViewModel cgviewmodel)
        {
            var ed = data.Film_Category.FirstOrDefault(n => n.Idfilm == id);
            if (!ModelState.IsValid)
            {
                return View("CreateFilm");
            }
            var pp = new Film_Category
            {
                Idfilm = ed.Idfilm,
                Idgory = cgviewmodel.Idgory,
            };
            data.Film_Category.Add(pp);
            data.SaveChanges();
            return RedirectToAction("ControlPhim", "Admin");
        }
    }
}