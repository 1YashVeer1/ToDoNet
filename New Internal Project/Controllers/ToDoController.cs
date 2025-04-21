using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace New_Internal_Project.Controllers
{
    public class ToDoController : Controller
    {

        private static List<string> tasks = new List<string>(); // Temporary Task List

        public ActionResult Index()
    {
        if (Session["User"] != null)
        {
            ViewBag.Username = Session["User"].ToString();  
        }
        else
        {
            return RedirectToAction("Index", "Login"); 
        }

        return View();
    }

        // Get Tasks (For AJAX)
        public JsonResult GetTasks()
        {
            return Json(tasks, JsonRequestBehavior.AllowGet);
        }
        // Add Task (AJAX Request)
        [HttpPost]
        //[Route("todo/AddTask")]
        //public JsonResult AddTask(string task)
        //{
        //    if (!string.IsNullOrEmpty(task))
        //    {
        //        tasks.Add(task);
        //        return Json(new { success = true, redirectUrl = "/ToDo/" + task });
        //    }
        //    //return Json(tasks);
        //    return Json(new { success = false });

        //}

        [Route("todo/AddTask")]
        public JsonResult AddTask(string task)
        {
            if (!string.IsNullOrEmpty(task))
            {
                tasks.Add(task);

                return Json(new { success = true, taskText = task });
            }

            return Json(new { success = false });
        }

        public ActionResult NewTask(string id)
        {
            if (tasks.Contains(id))
            {
                ViewBag.TaskName = id;
                return View("Index"); // Same view render karega
            }
            return HttpNotFound();
        }

        [HttpPost]
        public JsonResult EditTask(int id, string updatedTask)
        {
            if (id >= 0 && id < tasks.Count && !string.IsNullOrEmpty(updatedTask))
            {
                tasks[id] = updatedTask;
            }
            return Json(tasks);
        }
        [HttpPost]
        public JsonResult DeleteTask(int id)
        {
            if (id >= 0 && id < tasks.Count)
            {
                tasks.RemoveAt(id);
            }
            return Json(tasks);
        }
    }
}