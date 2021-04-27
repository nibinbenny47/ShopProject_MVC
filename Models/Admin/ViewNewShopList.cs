using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject_MVC.Models.Admin
{
    public class ViewNewShopList
    {
        public int shop_id { get; set; }
        public string shop_name { get; set; }
        public string shop_address { get; set; }
        public string shop_contact { get; set; }
        public string shop_email { get; set; }
        public string shop_photo { get; set; }
        public string shop_username { get; set; }
        public string shop_password { get; set; }
        public string shop_status { get; set; }
        //------for file upload---------------
        public string imagepath { get; set; }
        public HttpPostedFileBase imagefile { get; set; }
        //-------for district dropdown------------
        public List<SelectListItem> districtList { get; set; }
        public string ddlDistrict { get; set; }
        //-------for place dropdown------------
        public List<SelectListItem> placeList { get; set; }
        public string ddlPlace { get; set; }
        //-------for category dropdown-----------
        public List<SelectListItem> categoryList { get; set; }

        public string ddlCategory { get; set; }
        //-----for subcategory dropdown-------------
        public List<SelectListItem> subcategoryList { get; set; }
        public string ddlSubcategory { get; set; }
    }
}