using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ShopProject_MVC.Models.Guest;
using System.Web.UI.WebControls;

namespace ShopProject_MVC.Controllers.Guest
{
    public class ShopRegistrationController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");
        // GET: ShopRegistration
        public ActionResult Index()
        {
            return View();
        }
        //-----fill district dropdown---------------------------------------------------------
        public static List<SelectListItem> fillDistrict()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");


            string sel = "select * from tbl_district";
            SqlDataAdapter adp = new SqlDataAdapter(sel, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            List<SelectListItem> items = new List<SelectListItem>();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                items.Add(new SelectListItem
                {
                    Text = dt.Rows[i]["district_name"].ToString(),

                    Value = dt.Rows[i]["district_id"].ToString()
                });
            }
             ShopRegistration model = new ShopRegistration()
            {
                districtList = items
            };


            return items;
        }
        //--------fill place when district selected-----------------------------------------------

        [HttpPost]
        public ActionResult displayddlPlace(int id)
        {

            ShopRegistration obj = new ShopRegistration();

            obj.placeList = fillPlace(id);

            return Json(obj.placeList);

        }
        protected static List<SelectListItem> fillPlace(int id)
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");


            string sel = "select * from tbl_place where district_id=" + id + "";

            SqlDataAdapter adp = new SqlDataAdapter(sel, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);


            List<SelectListItem> items = new List<SelectListItem>();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                items.Add(new SelectListItem
                {
                    Text = dt.Rows[i]["place_name"].ToString(),
                    Value = dt.Rows[i]["place_id"].ToString()
                });


            }

            ShopRegistration model = new ShopRegistration()
            {
                districtList = items,
                //SelectItem1 = 1



            };


            return items;

        }
        //-----fill category dropdown-------------------------------------------------------
        public static List<SelectListItem> fillCategory()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");


            string sel = "select * from tbl_category";
            SqlDataAdapter adp = new SqlDataAdapter(sel, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            List<SelectListItem> items = new List<SelectListItem>();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                items.Add(new SelectListItem
                {
                    Text = dt.Rows[i]["category_name"].ToString(),

                    Value = dt.Rows[i]["category_id"].ToString()
                });
            }
            ShopRegistration model = new ShopRegistration()
            {
                categoryList = items
            };


            return items;
        }
        //------fill subcategory dropdown when category selected----------------------------------------------------
        [HttpPost]
        public ActionResult displayddlSubcategory(int id)
        {

            ShopRegistration obj = new ShopRegistration();

            obj.subcategoryList = fillSubcategory(id);

            return Json(obj.subcategoryList);

        }
        protected static List<SelectListItem> fillSubcategory(int id)
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");


            string sel = "select * from tbl_subcategory where subcategory_id=" + id + "";

            SqlDataAdapter adp = new SqlDataAdapter(sel, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);


            List<SelectListItem> items = new List<SelectListItem>();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                items.Add(new SelectListItem
                {
                    Text = dt.Rows[i]["subcategory_name"].ToString(),
                    Value = dt.Rows[i]["subcategory_id"].ToString()
                });


            }

            ShopRegistration model = new ShopRegistration()
            {
                categoryList = items,
                //SelectItem1 = 1



            };


            return items;

        }
        //------insert tbl_shop ---------------------------------------------------------------
        public ActionResult insertShop()
        {
            ShopRegistration obj = new ShopRegistration();
            obj.districtList = fillDistrict();
            obj.categoryList = fillCategory();
            return View(obj);

        }
        [HttpPost]
        public ActionResult insertShop(HttpPostedFileBase file, ShopRegistration obj)
        {

            string filename = Path.GetFileName(file.FileName);
            obj.imagepath = filename;
            string path = Path.Combine(Server.MapPath("~/Photos"), filename);
            file.SaveAs(path);
            {
                string insQry = "insert into tbl_shop(shop_name,shop_address,shop_email,shop_contact,shop_username,shop_password,shop_status,subcategory_id,place_id,shop_photo)values('"+obj.shop_name+"','"+obj.shop_address+ "','"+obj.shop_email+ "','"+obj.shop_contact+ "','"+obj.shop_username+ "','"+obj.shop_password+ "',0,'"+obj.ddlSubcategory+ "','"+obj.ddlPlace+"','" + obj.imagepath + "')";
                SqlCommand cmd = new SqlCommand(insQry, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ModelState.Clear();
                return View();

            }
        }



    }
}