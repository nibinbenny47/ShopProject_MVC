using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
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

            string selQry = "select * from tbl-district";
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
    }
}