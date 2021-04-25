using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using ShopProject_MVC.Models.Admin;


namespace ShopProject_MVC.Controllers.Admin
{
    public class PlaceController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");

        // GET: Place
        public ActionResult Index()
        {
            return View();
        }
        //--------fill dropdown district names--------------------------
        public List<SelectListItem> fillDistrict()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");
            string selQry = "select * from tbl_district";
            SqlDataAdapter adp = new SqlDataAdapter(selQry, con);
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
            Place model = new Place()
            {
                districtList = items
            };
            return items;
        }
           



        //---------insert tbl_place----------------------------
        public ActionResult insertPlace()
        {
            Place obj = new Place();
            obj.districtList = fillDistrict();
            return View(obj);
        }
        [HttpPost]
        public ActionResult insertPlace(Place obj)
        {
            string insQry = "insert into tbl_place(place_name,district_id) values('"+obj.place_name+"','"+obj.district_id+"')";
            SqlCommand cmd = new SqlCommand(insQry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return View(obj);

        }

    }
}