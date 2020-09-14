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
    public class EmpsController : Controller
    {
        DBHelper func = new DBHelper();
        // GET: Emps
        public ActionResult Index()
        {
            string sql = "Employees_select";
            SqlDataReader sqlDataReader = func.ExecuteReader(sql);
            DataTable dt = new DataTable();
            dt.Load(sqlDataReader);
            return View(dt);
        }

        // GET: Emps/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Emps/Create
        public ActionResult Create()
        {
            //------------------------Department Name-----------------------

            string sql1 = "Dept_select";
            SqlDataReader dataReader1 = func.ExecuteReader(sql1);
            DataTable dt1 = new DataTable();
            dt1.Load(dataReader1);
            List<SelectListItem> Dept_List = new List<SelectListItem>();
            foreach (DataRow item in dt1.Rows)
            {
                Dept_List.Add(new SelectListItem()
                { Value = item[0].ToString(), Text = item[1].ToString() });
            }
            ViewBag.dept = Dept_List;

            //-------------------------------END----------------------------

            //-----------------Country Name-------------------------------
            string sql2 = "Country_select";
            SqlDataReader dataReader2 = func.ExecuteReader(sql2);
            DataTable dt2 = new DataTable();
            dt2.Load(dataReader2);
            List<SelectListItem> country_List = new List<SelectListItem>();
            foreach (DataRow item in dt2.Rows)
            {
                country_List.Add(new SelectListItem()
                { Value = item[0].ToString(), Text = item[1].ToString() });
            }
            ViewBag.country = country_List;

            //[Country_select]
            //------------------------------------------------------------
            return View();
        }

        // POST: Emps/Create
        [HttpPost]
        public ActionResult Create(HR_Example.Models.Emp emp)
        {
            try
            {
                string sql = "Employee_insert";
                SqlParameter[] parameter = new SqlParameter[4];
                parameter[0] = new SqlParameter("@Employee_Name", emp.Employee_Name);
                parameter[1] = new SqlParameter("@Employee_salary", emp.Employee_salary);
                parameter[2] = new SqlParameter("@Dept_Id", emp.Dept_ID);
                parameter[3] = new SqlParameter("@country_ID", emp.Country_ID);
                func.ExecuteNonQuery(sql , parameter);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emps/Edit/5
        public ActionResult Edit(int id)
        {
            string sql = "Employees_select_ID";
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Employee_ID", id);
            SqlDataReader dataReader = func.ExecuteReader(sql, p);
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            HR_Example.Models.Emp emp = new Emp();
            //------------------------Department Name-----------------------

            string sql1 = "Dept_select";
            SqlDataReader dataReader1 = func.ExecuteReader(sql1);
            DataTable dt1 = new DataTable();
            dt1.Load(dataReader1);
            List<SelectListItem> Dept_List = new List<SelectListItem>();
            foreach (DataRow item in dt1.Rows)
            {
                Dept_List.Add(new SelectListItem()
                { Value = item[0].ToString(), Text = item[1].ToString() });
            }
            ViewBag.dept = Dept_List;

            //-------------------------------END----------------------------

            //-----------------Country Name-------------------------------
            string sql2 = "Country_select";
            SqlDataReader dataReader2 = func.ExecuteReader(sql2);
            DataTable dt2 = new DataTable();
            dt2.Load(dataReader2);
            List<SelectListItem> country_List = new List<SelectListItem>();
            foreach (DataRow item in dt2.Rows)
            {
                country_List.Add(new SelectListItem()
                { Value = item[0].ToString(), Text = item[1].ToString() });
            }
            ViewBag.country = country_List;

            //[Country_select]
            //------------------------------------------------------------
            foreach (DataRow data in dt.Rows)
            {
                emp.Employee_Name = data[1].ToString();
                emp.Employee_salary =(double) data[2] ;
                emp.Dept_ID =(int) data[3];
                emp.Country_ID = (int)data[4];
            }
            return View(emp);
        }

        // POST: Emps/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HR_Example.Models.Emp emp)
        {
            try
            {
                string sql = "Employee_update";
                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("@Employee_ID", id);
                p[1] = new SqlParameter("@Employee_Name", emp.Employee_Name);
                p[2] = new SqlParameter("@Employee_salary", emp.Employee_salary);
                p[3] = new SqlParameter("@Dept_Id", emp.Dept_ID);
                p[4] = new SqlParameter("@country_ID", emp.Country_ID);
                func.ExecuteNonQuery(sql, p);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emps/Delete/5
        public ActionResult Delete(int id)
        {
            string sql = "Employees_select_ID";
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Employee_ID", id);
            SqlDataReader dataReader = func.ExecuteReader(sql, p);
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            HR_Example.Models.Emp emp = new Emp();
            foreach (DataRow data in dt.Rows)
            {
                emp.Employee_Name = data[1].ToString();
                emp.Employee_salary = (double)data[2];
                emp.Dept_ID = (int)data[3];
                emp.Country_ID = (int)data[4];
            }
            return View(emp);
        }

        // POST: Emps/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, HR_Example.Models.Emp emp)
        {
            try
            {
                string sql = "Employee_delete";
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Employee_ID", id);
                func.ExecuteNonQuery(sql, p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
