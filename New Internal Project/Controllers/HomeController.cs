using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_Internal_Project.Controllers
{
    public class HomeController : Controller
    {
        private static List<string> tasks = new List<string>();
        public ActionResult Index()
        {
            return View(tasks);
        }
        public ActionResult Create()
        {
            return View();
        }

        // Add Task (AJAX Request)
        [HttpPost]
        [Route("todo/addtask")]
        public JsonResult AddTask(string task)
        {
            Debug.WriteLine(task);
            if (!string.IsNullOrEmpty(task))
            {
                tasks.Add(task);
            }
            return Json(tasks);
        }

        [HttpPost]
        public ActionResult Create(string task)
        {
            Debug.WriteLine(task);
            if (!string.IsNullOrEmpty(task))
            {
                tasks.Add(task);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (id < 0 || id >= tasks.Count)
                return HttpNotFound();

            ViewBag.TaskId = id;
            return View((object)tasks[id]);
        }

        [HttpPost]
        public ActionResult Edit(int id, string updatedTask)
        {
            if (id >= 0 && id < tasks.Count && !string.IsNullOrEmpty(updatedTask))
            {
                tasks[id] = updatedTask;
            }
            return RedirectToAction("Index"); 
        }
        public ActionResult Delete(int id)
        {
            if(id >= 0 && id < tasks.Count)
            {
                tasks.RemoveAt(id);
            }
            return RedirectToAction("Index");
        }


        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page."; 

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}