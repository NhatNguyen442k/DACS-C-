using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDACS.Models.ViewModel
{
    public class SetCategoriesViewModel
    {
        public int Idgory { get; set; }
        public int Idfilm { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Film> Films { get; set; }
    }
}