using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopProject_MVC.Models.Admin;
using System.Data;
using System.Data.SqlClient;

namespace ShopProject_MVC.Controllers.Admin
{
    public class DistrictController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");

        // GET: District
        public ActionResult Index()
        {
            return View();
        }
        //-------insert tbl_district--------
        public ActionResult insertDistrict()
        {
            District obj = new District();
            return View(obj);
        }
        [HttpPost]
        public ActionResult insertDistrict(District obj)
        {
            string insQry = "insert into tbl_district(district_name) values('" + obj.disṭrict_name + "')";
            SqlCommand cmd = new SqlCommand(insQry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ModelState.Clear();
            return View(obj);


        }
    }
}