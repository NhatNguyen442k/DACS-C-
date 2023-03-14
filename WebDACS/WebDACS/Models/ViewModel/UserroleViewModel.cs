using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDACS.Models.ViewModel
{
    public class UserroleViewModel
    {
        public int Iduser { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Userpassword { get; set; }
        [Required]
        public string Displayname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Avatar { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        [Required]
        public int IDrole { get; set; }
        public IEnumerable<Role> Rolies { get; set; }
    }
}