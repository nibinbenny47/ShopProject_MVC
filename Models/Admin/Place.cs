using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
     

namespace ShopProject_MVC.Models.Admin
{
    public class Place
    {
        public int place_id { get; set; }
        public string place_name { get; set; }
        public  string district_id { get; set; }
        //------for district dropdown-----------------
        public List<SelectListItem> districtList { get; set; }
       
             
             

    }
}