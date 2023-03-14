using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDACS.Models
{
    public class Film_Category
    {
        [Key, Column(Order = 1)]
        public int Idgory { get; set; }
        [Key, Column(Order = 2)]
        public int Idfilm { get; set; }

        public Category Categories { get; set; }
        public Film Films { get; set; }

    }
}