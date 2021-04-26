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
    public class SubcategoryController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");

        // GET: Subcategory
        public ActionResult Index()
        {
            return View();
        }
        //-------fill category names dropdown-----------------------------------------------
        public List<SelectListItem> fillCategory()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");

            string seleQry = "select * from tbl_category";
            SqlDataAdapter adp = new SqlDataAdapter(seleQry, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            List<SelectListItem> items = new List<SelectListItem>();
            for(var i = 0; i < dt.Rows.Count; ++i)
            {
                items.Add(new SelectListItem
                {
                    Text = dt.Rows[i]["category_name"].ToString(),
                    Value = dt.Rows[i]["category_id"].ToString()
                }) ;
            }
            Subcategory model = new Subcategory()
            {
                categoryList = items
            };
            return items;

            
        }
        //---------insert subcategory names-------------------------------------------------
        public ActionResult insertSubcategory()
        {
            Subcategory obj = new Subcategory();
            obj.categoryList = fillCategory();
            return View(obj);
        }


        [HttpPost]
        public ActionResult insertSubcategory(Subcategory obj)
        {
            string insQry = "insert into tbl_subcategory (subcategory_name,category_id) values('"+obj.subcategory_name+"','"+obj.category_id+"')";
            SqlCommand cmd = new SqlCommand(insQry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return View(obj);
        }
        //--------display subcategory names--------------------------------------------------
        public ActionResult displaySubcategory()
        {
            string selQry = "select * from tbl_subcategory s inner join tbl_category c on s.category_id=c.category_id";
            var model = new List<Subcategory>();
            SqlDataAdapter adp = new SqlDataAdapter(selQry, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                Subcategory obj = new Subcategory();
                obj.subcategory_name = dt.Rows[i]["subcategory_name"].ToString();
                obj.category_id = dt.Rows[i]["category_name"].ToString();
                obj.subcategory_id = Convert.ToInt32(dt.Rows[i]["subcategory_id"]);

                model.Add(obj);
            }
            //SqlCommand cmd = new SqlCommand(selQry, con);
            //con.Open();
            //SqlDataReader rdr = cmd.ExecuteReader();
            //while (rdr.Read())
            //{
            //    var obj = new Subcategory();
            //    obj.subcategory_name = (string)rdr["subcategory_name"];
            //    obj.subcategory_id = (int)rdr["subcategory_id"];
            //    obj.category_id = (string)rdr["category_name"];
            //    model.Add(obj);
            //}
            return View(model);
        }
        //-------delete subcategory names---------------------------------------------------
        public ActionResult deleteSubcategory(int id)
        {
            string delQry = "delete from tbl_subcategory where subcategory_id='"+id+"'";
            SqlCommand cmd = new SqlCommand(delQry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("displaySubcategory");
        }
        //------edit subcategory names-------------------------------------------------------
        public ActionResult updateSubcategory(int id)
        {
            string selQry = "select * from tbl_subcategory s inner join tbl_category c on s.category_id=c.category_id  where s.subcategory_id='"+id+"'";
            SqlDataAdapter adp = new SqlDataAdapter(selQry, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Subcategory obj = new Subcategory();
            obj.categoryList = fillCategory();
            obj.subcategory_name = dt.Rows[0]["subcategory_name"].ToString();
            obj.subcategory_id = Convert.ToInt32(dt.Rows[0]["subcategory_id"]);
            obj.category_id= dt.Rows[0]["category_id"].ToString();
            return View(obj);

            //SqlCommand cmd = new SqlCommand(selQry, con);
            //con.Open();
            //SqlDataReader rdr = cmd.ExecuteReader();
            //while (rdr.Read())
            //{
            //    obj.subcategory_name = (string)rdr["subcategory_name"];
            //    obj.subcategory_id = (int)rdr["subcategory_id"];
            //    obj.category_id = (string)rdr["category_id"];
            //}

        }
        [HttpPost]
        public ActionResult updateSubcategory(Subcategory obj, int id)
        {
            

            string upQry = "update tbl_subcategory set subcategory_name='" + obj.subcategory_name + "',category_id='"+obj.category_id+"' where subcategory_id='" + id + "'";
            SqlCommand cmd = new SqlCommand(upQry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            
            con.Close();

            return RedirectToAction("displaySubcategory");
        }
    }
}