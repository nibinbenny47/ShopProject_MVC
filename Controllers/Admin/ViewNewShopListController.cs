using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ShopProject_MVC.Models.Admin;
namespace ShopProject_MVC.Controllers.Admin
{
    public class ViewNewShopListController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");

        // GET: ViewNewShopList
        public ActionResult Index()
        {
            return View();
        }
        //-------display all new shop list--------------------------------------------------
        public ActionResult displayShopList()
        {
            string selQry = "select * from tbl_shop s inner join tbl_place p on s.place_id=p.place_id inner join tbl_subcategory sc on sc.subcategory_id=s.subcategory_id where s.shop_status =0";
            SqlCommand cmd = new SqlCommand(selQry, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            var model = new List<ViewNewShopList>();
            while (rdr.Read())
            {
                var obj = new ViewNewShopList();
                obj.shop_name = rdr["shop_name"].ToString();
                obj.shop_email = rdr["shop_email"].ToString();
                obj.shop_contact = rdr["shop_contact"].ToString();
                obj.shop_address = rdr["shop_address"].ToString();
                obj.imagepath = rdr["shop_photo"].ToString();
                obj.ddlPlace = rdr["place_name"].ToString();
                obj.ddlSubcategory = rdr["subcategory_name"].ToString();
                model.Add(obj);


            }
            return View(model);

        }
    }
}