using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using New_Internal_Project.Models;

namespace New_Internal_Project.Controllers
{
    public class DetailController : Controller
    {
        private static List<Employee> employeeList = new List<Employee>();

        [HttpGet]
        public ActionResult Index()
        {
            return View(employeeList);
        }

        [HttpPost]
        public ActionResult Index(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeList.Add(employee);
            }
            return RedirectToAction("Index");
        }
    }
}
