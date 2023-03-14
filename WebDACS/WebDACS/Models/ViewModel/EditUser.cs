using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDACS.Models.ViewModel
{
    public class EditUser
    {
        public UserroleViewModel rsr { get; set; }
        public List<SelectListItem> rolies { get; set; }
    }
}