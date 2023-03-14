using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDACS.Models
{
    public class EpisodeFilm
    {
        [Key]
        public int IdEs { get; set; }
        [Required]
        public int IdFilm { get; set; }
        [Required]
        public string EsName { get; set; }
        [Required]
        public int EsFilm { get; set; }
        [Required]
        public string EsUrl { get; set; }
        public Film Films { get; set; }
    }
}