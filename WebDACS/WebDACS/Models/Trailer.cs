using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDACS.Models
{
    public class Trailer
    {
        [Key]
        public int Idtrailer { get; set; }
        public string TrailerName { get; set; }
        public string TrailerImage { get; set; }
        public string TrailerUrl { get; set; }
        public int Idfilm { get; set; }
        public Film Films { get; set; }
    }
}