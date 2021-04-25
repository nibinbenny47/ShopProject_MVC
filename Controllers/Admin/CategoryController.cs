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
    public class CategoryController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_MVCProject;Integrated Security=True");

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        //------insert tbl_category-----------
        public ActionResult insertCategory()
        {
            Category obj = new Category();
            return View(obj);
        }
        [HttpPost]
        public ActionResult insertCategory(Category obj)
        {
            string insQry = "insert into tbl_category(category_name) values('"+obj.category_name+"')";
            SqlCommand cmd = new SqlCommand(insQry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ModelState.Clear();
            return View(obj);
         

        }
        //public void clear()
        //{
        //    Category obj = new Category();
        //    obj.category_name = string.Empty;
        //    obj.category_id = 0;
        //}


        //------display category names------------------------
        public ActionResult displayCategory()
        {
            string selQry = "select * from tbl_category";
            var model = new List<Category>();
            SqlCommand cmd = new SqlCommand(selQry, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var obj = new Category();
                obj.category_id = (int)rdr["category_id"];
                obj.category_name = (string)rdr["category_name"];
                model.Add(obj);
            }
            return View(model);
        }

        //--------delete category names---------------------------
        public ActionResult deleteCategory(int id)
        {
            string delQry = "delete from tbl_category where category_id='" + id + "'";
            SqlCommand cmd = new SqlCommand(delQry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("displayCategory");
        }
        //-------edit category names---------------------------
        public ActionResult updateCategory(int id,Category obj)
        {
            string selQry = "select * from tbl_category where category_id='"+id+"'";
            SqlCommand cmd = new SqlCommand(selQry, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                obj.category_id = (int)rdr["category_id"];
                obj.category_name = (string)rdr["category_name"];
            }
            return View(obj);

            //SqlDataAdapter adp = new SqlDataAdapter(selQry, con);
            //DataTable dt = new DataTable();
            //adp.Fill(dt);
            //obj.category_id = Convert.ToInt32(dt.Rows[0]["category_id"]);
            //obj.category_name = dt.Rows[0]["category_name"].ToString();
            //return View(obj);
        }
        //[HttpPost]
        //public ActionResult updateCategory(int id)
        //{
        //    Category obj = new Category();

        //    string upQry = "update tbl_category set category_name='"+obj.category_name+"' where category_id='"+id+"'";
        //    SqlCommand cmd = new SqlCommand(upQry, con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    return View(obj);

        //}
        [HttpPost]
        public ActionResult updateCategory(Category obj, int id)
        {
            string upQry = "update tbl_category set category_name='" + obj.category_name + "' where category_id='" + id + "'";
            SqlCommand cmd = new SqlCommand(upQry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return View(obj);
        }


    }
}