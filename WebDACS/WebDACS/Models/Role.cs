using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDACS.Models
{
    public class Role
    {
        [Key]
        public int Idrole { get; set; }
        [Required]
        public string Namerole { get; set; }
    }
}