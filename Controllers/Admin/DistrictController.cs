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
        //---------show district names---------------
        public ActionResult displayDistrict()
        {
            string selQry = "select * from tbl_district";
            var model = new List<District>();
            SqlCommand cmd = new SqlCommand(selQry, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                var obj = new District();
                obj.district_id = (int)rdr["district_id"];
                obj.disṭrict_name = (string)rdr["district_name"];
                model.Add(obj);

            }
            return View(model);
        }
        //-----------delete district -----------
        public ActionResult deleteDistrict(int id)
        {
            string delQry = "delete from tbl_district where district_id='"+id+"'";
            SqlCommand cmd = new SqlCommand(delQry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("displayDistrict");
        }
        //----------edit district----------------
        public ActionResult updateDistrict(int id,District obj)
        {
            string selQry = "select * from tbl_district where district_id ='"+id+"'";
            SqlCommand cmd = new SqlCommand(selQry, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
           // District obj = new District();
            while (rdr.Read())
            {
                
                obj.district_id = (int)rdr["district_id"];
                obj.disṭrict_name = (string)rdr["district_name"];
            }
            return View();
        }
        [HttpPost]
        public ActionResult updateDistrict(District obj,int id)
        {
            string upQry = "update tbl_district set district_name='"+obj.disṭrict_name+"' where district_id='"+id+"'";
            SqlCommand cmd = new SqlCommand(upQry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return View(obj);
        }

    }
}