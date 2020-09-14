using HR_Example.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_Example.Controllers
{
    public class EmpCountryController : Controller
    {
        DBHelper func = new DBHelper();
        // GET: EmpCountry
        public ActionResult Index()
        {
            string sql = "SELECT * FROM Country";
            DataTable s =func.FireDataTable(sql);
            return View(s);
        }

        // GET: EmpCountry/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpCountry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpCountry/Create
        [HttpPost]
        public ActionResult Create(HR_Example.Models.Country country)
        {
            try
            {
                string sql = "INSERT INTO Country ([country_Name])VALUES(N'{0}')";
                func.fireSQL(String.Format(sql, country.Country_name));
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpCountry/Edit/5
        public ActionResult Edit(int id)
        {
            string sql = "SELECT * FROM Country WHERE country_ID = '{0}'";
            DataTable s = func.FireDataTable(String.Format(sql , id));
            HR_Example.Models.Country country = new Country();

            foreach (DataRow item in s.Rows)
            {
                country.Country_name = item[1].ToString();
            }
            return View(country);
        }

        // POST: EmpCountry/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HR_Example.Models.Country country)
        {
            try
            {

                string sql = "UPDATE Country SET [country_Name] = N'{0}' WHERE country_ID = N'{1}'";
                func.fireSQL(String.Format(sql, country.Country_name, id));
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpCountry/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

           
            string sql = "DELETE FROM Country WHERE country_ID= N'{0}'";
            func.fireSQL(String.Format(sql, id));
            // TODO: Add update logic here

            return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: EmpCountry/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
