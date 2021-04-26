using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject_MVC.Models.Guest
{
    public class UserRegistration
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_gender { get; set; }
        public string user_email { get; set; }
        public string user_contact { get; set; }
        public string user_username { get; set; }
        public string user_password { get; set; }
        //----for file upload-------------
        public string imagepath { get; set; }
        public HttpPostedFileBase imagefile { get; set; }
        //----for district dropdown---------
        public List<SelectListItem> districtList { get; set; }
        public string ddlDistrict { get; set; }
        //-----for place dropdown---------
        public List<SelectListItem> placeList { get; set; }
        public string ddlPlace { get; set; }









    }
}