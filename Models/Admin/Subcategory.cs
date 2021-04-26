using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject_MVC.Models.Admin
{
    public class Subcategory
    {
        public int subcategory_id { get; set; }
        public string subcategory_name { get; set; }
        //------for category names dropdown-------------------

        public List<SelectListItem> categoryList { get; set; }
        public string category_id { get; set; }
       
    }
}