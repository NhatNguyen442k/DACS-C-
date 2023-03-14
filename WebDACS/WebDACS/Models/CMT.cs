using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDACS.Models
{
    public class CMT
    {
        [Key]
        public int IDcmt { get; set; }
        public int Iduser { get; set; }
        public int Idfilm { get; set; }
        public string Cmt { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public void GetCuren()
        {
            if (DateCreate == null)
            {
                DateCreate = DateTime.Now;
            }
        }
        public Film Films { get; set; }
        public Users Useries { get; set; }
    }
}