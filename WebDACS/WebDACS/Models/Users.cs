using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDACS.Models
{
    public class Users
    {
        [Key]
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
        public void GetCuren()
        {
            if (DateCreate == null)
            {
                DateCreate = DateTime.Now;
            }
        }
        [Required]
        public int IDrole { get; set; }
        public Role Roless { get; set; }
        
    }
}