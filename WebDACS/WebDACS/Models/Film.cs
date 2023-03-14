using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDACS.Models
{
    public class Film
    {
        [Key]
        public int IdFilm { get; set; }
        [Required]
        public string NameVN { get; set; }
        [Required]
        public string NameF { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Nation { get; set; }
        [Required]
        public int Years { get; set; }
        [Required]
        public string TypeFilm { get; set; }
        [Required]
        public int Times { get; set; }
        [Required]
        public string Images { get; set; }
        [Required]
        public string Information { get; set; }
        public int Rating { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public void GetCuren1()
        {
            if (DateCreate == null)
            {
                DateCreate = DateTime.Now;
            }
        }
        [Required]
        public DateTime DateUpdate { get; set; }
        public void GetCuren2()
        {
            if (DateUpdate == null)
            {
                DateUpdate = DateTime.Now;
            }
        }



        AppDataContext data = new AppDataContext();
        public List<Film> ListAll()
        {
            return data.Films.Distinct().ToList();
        }

        public IEnumerable<Film> All()
        {
            return data.Films;
        }
    }
}