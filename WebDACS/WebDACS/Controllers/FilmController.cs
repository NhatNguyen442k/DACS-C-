using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebDACS.Models;

namespace WebDACS.Controllers
{
    public class FilmController : Controller
    {
        // GET: Film
        AppDataContext data = new AppDataContext();
        public ActionResult Phimbo()
        {
            var phimbo = from s in data.Films.Where(n => n.TypeFilm == "Phim bộ")
                         select s;
            return View(phimbo);
        }
        public ActionResult Phimle()
        {
            var phimle = from s in data.Films.Where(n => n.TypeFilm == "Phim lẻ")
                         select s;
            return View(phimle);
        }
        public ActionResult Phimchieurap()
        {
            var phimchieurap = from s in data.Films.Where(n => n.TypeFilm == "Phim chiếu rạp")
                               select s;
            return View(phimchieurap);
        }


        public ActionResult Home()
        {
            var home = from s in data.Films select s;
            return View(home);
        }

        public ActionResult InfoPhim(int id)
        {
            var infos = data.Films.Where(n => n.IdFilm == id).First();
            return View(infos);
        }

        public ActionResult SearchPhim(string tensearch)
        {
            tensearch = tensearch.ToLower();
            var inf = data.Films.Where(n => n.NameVN.ToLower().Contains(tensearch)
            || n.NameF.ToLower().Contains(tensearch) || n.Director.ToLower().Contains(tensearch));
            return View(inf.ToList());
        }
    }
}