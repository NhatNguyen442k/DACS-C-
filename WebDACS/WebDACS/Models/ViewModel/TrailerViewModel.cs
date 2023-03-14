using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDACS.Models.ViewModel
{
    public class TrailerViewModel
    {
        public string NameVN { get; set; }
        public string NameF { get; set; }
        public int Year { get; set; }
        public string TrailerUrl { get; set; }
        public int IdFilml { get; set; }
        public int Idtrailer { get; set; }
        public Film Films { get; set; }
        public Trailer Trailer { get; set; }
        public IEnumerable<Film> Filmies { get; set; }
        public IEnumerable<Trailer> Traileries { get; set; }
    }
}