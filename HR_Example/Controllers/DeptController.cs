using HR_Example.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_Example.Controllers
{

    public class DeptController : Controller
    {
        DBHelper func = new DBHelper();
        // GET: Dept
        public ActionResult Index()
        {
            string sql = "Dept_select";
            SqlDataReader dataReader = func.ExecuteReader(sql);
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            return View(dt);
        }

        // GET: Dept/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dept/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dept/Create
        [HttpPost]
        public ActionResult Create(HR_Example.Models.Dept dept)
        {
            try
            {
                string sql = "Dept_insert_";
                SqlParameter [] sqlParameter = new SqlParameter[1];
                sqlParameter[0] = new SqlParameter("@Dept_Name", dept.Dept_Name);
                func.ExecuteNonQuery(sql,sqlParameter);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dept/Edit/5
        public ActionResult Edit(int id)
        {
            string sql = "Dept_select_id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Dept_Id", id);
            SqlDataReader dataReader = func.ExecuteReader(sql, sqlParameters);
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            HR_Example.Models.Dept dept = new Dept();
            foreach (DataRow item in dt.Rows)
            {
                dept.Dept_Name = item[1].ToString();
            }
            return View(dept);
        }

        // POST: Dept/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HR_Example.Models.Dept dept)
        {
            try
            {
                // TODO: Add update logic here
                string sql = "Dept_update";
                SqlParameter[] sqlParameter = new SqlParameter[2];
                sqlParameter[0] = new SqlParameter("@Dept_Id", id);
                sqlParameter[1] = new SqlParameter("@Dept_Name", dept.Dept_Name);

                 func.ExecuteNonQuery(sql, sqlParameter);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dept/Delete/5
        public ActionResult Delete(int id)
        {
            string sql = "Dept_select_id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Dept_Id", id);
            SqlDataReader dataReader = func.ExecuteReader(sql, sqlParameters);
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            HR_Example.Models.Dept dept = new Dept();
            foreach (DataRow item in dt.Rows)
            {
                dept.Dept_Name = item[1].ToString();
            }
            return View(dept);
        }

        // POST: Dept/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                string sql = "Dept_delete";
                SqlParameter[] sqlParameter = new SqlParameter[1];
                sqlParameter[0] = new SqlParameter("@Dept_Id", id);

                func.ExecuteNonQuery(sql, sqlParameter);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
