using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDACS.Models
{
    public class Report
    {
        [Key]
        public int Idreport { get; set; }
        [Required]
        public int Idfilm { get; set; }
        public string Content { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public void GetCuren1()
        {
            if (DateCreate == null)
            {
                DateCreate = DateTime.Now;
            }
        }
        public Film Films { get; set; }
    }
}