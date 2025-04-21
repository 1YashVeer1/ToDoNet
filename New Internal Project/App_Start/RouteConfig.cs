using System.Web.Mvc;
using System.Web.Routing;

public class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

    //    routes.MapRoute(
    //     name: "Login",
    //     url: "Login/index",
    //     defaults: new { controller = "Login", action = "Index" }
    //);


       //  ✅ More specific route for AddTask
        //routes.MapRoute(
        //    name: "AddTask",
        //    url: "ToDo/AddTask",
        //    defaults: new { controller = "ToDo", action = "AddTask" }
        //);

        //// ✅ Route for dynamic task pages (must come after specific routes)
        //routes.MapRoute(
        //    name: "TaskRoute",
        //    url: "ToDo/{id}",
        //    defaults: new { controller = "ToDo", action = "NewTask" }
        //);

        // 🟢 Default Route
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
        );

    }
}
