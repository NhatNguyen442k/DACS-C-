using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDACS.Models;

namespace WebDACS.Controllers
{
    public class TrailerController : Controller
    {
        AppDataContext data = new AppDataContext();
        // GET: Trailer
        public ActionResult InfoTrailer(int id)
        {
            var trl = data.Trailers.FirstOrDefault(n => n.Idfilm == id);
            return View(trl);
        }

        public ActionResult InfoEpisode(int id)
        {
            var epis = data.EpisodeFilms.FirstOrDefault(n => n.IdFilm == id);
            return View(epis);
        }
    }
}