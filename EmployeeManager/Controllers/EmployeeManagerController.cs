using EmployeeManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Controllers
{
    [Authorize(Roles="Manager")]
    public class EmployeeManagerController : Controller
    {
        private AppDbContext db = null;
        public EmployeeManagerController(AppDbContext db)
        {
            this.db = db;

        }

        public IActionResult List()
        {
            List<Employees> model = (from e in db.Employees 
                                    orderby e.EmployeeID
                                    select e).ToList();
            return View(model);

        }

        [HttpGet]
        public IActionResult Insert ()
        {
            FillCountries();
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Employees model)
        {
            FillCountries();
            if (ModelState.IsValid)
            {
                db.Employees.Add(model);
                db.SaveChanges();
                ViewBag.Message = "employee inserted successfully";

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            FillCountries();
            var model = db.Employees.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Employees model)
        {
            FillCountries();
            if (ModelState.IsValid)
            {
                db.Employees.Update(model);
                db.SaveChanges();
                ViewBag.Message = "employee Updated successfully";

            }
            return View(model);
        }


        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var model = db.Employees.Find(id);
            return View(model);
                
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = db.Employees.Find(id);
            db.Employees.Remove(model);
            db.SaveChanges();
            TempData["message"] = "Employee deleted successfully";
            return RedirectToAction("List");
        }

        private void FillCountries()
        {
            List<SelectListItem> listOfCountries = (from c in db.Employees
                                                    select new SelectListItem()
                                                    {
                                                        Text = c.Country,
                                                        Value = c.Country
                                                    }).Distinct().ToList();
            ViewBag.Countries = listOfCountries;
        }
    }
}
