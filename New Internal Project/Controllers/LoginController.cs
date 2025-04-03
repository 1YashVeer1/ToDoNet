using System;
using System.Web.Mvc;

namespace New_Internal_Project.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            // Redirect logged-in users to the ToDo page
            if (Session["User"] != null)
                return RedirectToAction("Index", "ToDo");

            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            // Simple authentication directly inside Index
            if (username == "admin" && password == "1234")
            {
                Session["User"] = username;
                return RedirectToAction("Index", "ToDo");
            }
           
                ViewBag.Message = "Invalid username or password.";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
