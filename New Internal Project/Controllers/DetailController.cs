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
        // GET: Detail
            public ActionResult Details()
            {
                Employee employee = new Employee()
                {
                    Id = 101,
                    Name = "Yash",
                    Gender = "Male",
                    City = "jaipur"
                };
                return View(employee);
            }
    }
}