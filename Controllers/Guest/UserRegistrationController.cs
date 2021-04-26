using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ShopProject_MVC.Models.Guest;

namespace ShopProject_MVC.Controllers.Guest
{
    public class UserRegistrationController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");

        // GET: UserRegistration
        public ActionResult Index()
        {
            return View();
        }
        //----for dropdown district---------------------------------------------------------
        public static List<SelectListItem> filDistrict()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");

            string selQry = "select * from tbl_district";
            SqlDataAdapter adp = new SqlDataAdapter(selQry, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            List<SelectListItem> items = new List<SelectListItem>();

            for (var i = 0; i < dt.Rows.Count; ++i)
            {
                items.Add(new SelectListItem
                {
                    Text = dt.Rows[i]["district_name"].ToString(),
                    Value=dt.Rows[i]["district_id"].ToString()
                }) ;
            }
            UserRegistration model = new UserRegistration()
            {
                districtList=items
            };
            return items;


        }
        //-----fill place when district selected--------------------------------------------
        [HttpPost]
        public ActionResult displayddlPlace(int id)
        {
            UserRegistration obj = new UserRegistration();
            obj.placeList = fillPlace(id);
            return Json(obj.placeList);
                 

        }
        public static List<SelectListItem>fillPlace(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");

            string selQry = "select * from tbl_place where district_id='"+id+"'";
            SqlDataAdapter adp = new SqlDataAdapter(selQry, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            List<SelectListItem> items = new List<SelectListItem>();
            for(var i = 0; i < dt.Rows.Count; ++i)
            {
                items.Add(new SelectListItem
                {
                    Text = dt.Rows[i]["place_name"].ToString(),
                    Value=dt.Rows[i]["place_id"].ToString()
                });
                
            }
            UserRegistration model = new UserRegistration()
            {
                districtList = items,
            };
            return items;
        }
        //------insert tbl_user-------------------------------------------------------------
        public ActionResult insertUser()
        {
            UserRegistration obj = new UserRegistration();
            obj.districtList = filDistrict();
            return View(obj);
        }
        [HttpPost]
        public ActionResult insertUser(HttpPostedFileBase file,UserRegistration obj)
        {
            string filename = Path.GetFileName(file.FileName);
            obj.imagepath = filename;
            string path = Path.Combine(Server.MapPath("~/Photos"), filename);
            file.SaveAs(path);
            {

                string insQry = "insert into tbl_user(user_name,user_gender,user_email,place_id,user_photo,user_username,user_password,user_contact)values('"+obj.user_name+"','"+obj.user_gender+"','"+obj.user_email+"','"+obj.ddlPlace+"','"+obj.imagepath+"','"+obj.user_username+"','"+obj.user_password+"','"+obj.user_contact+"')";
                SqlCommand cmd = new SqlCommand(insQry, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return View(obj);
            }
        }
    }
}