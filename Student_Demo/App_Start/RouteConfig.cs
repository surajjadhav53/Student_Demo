using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Student_Demo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();  //Enables attributes based routing

            routes.MapRoute(
                "ViewDepartment",
                "Department/View",
                new { controller = "Department", action = "DepartmentList" }
               
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Index", id = 0 }
            );
        }
    }
}
