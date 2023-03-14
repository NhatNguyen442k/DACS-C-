using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDACS.Models
{
    public class Category
    {
        [Key]
        public int IdGory { get; set; }
        [Required]
        public string Namegory { get; set; }
        [Required]
        public string Titlegory { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public void GetCuren()
        {
            if (DateCreate == null)
            {
                DateCreate = DateTime.Now;
            }
        }
        [Required]
        public string NameCreate { get; set; }

    }
}