using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmployeeRecords
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "Default",
               routeTemplate: "api/{controller=employee}/{action=index}/{id}",
               defaults: new { id = RouteParameter.Optional}
           );
            //EnableCrossSiteRequests(config);
            // AddRoutes(config);
        }

        ////private static void AddRoutes(HttpConfiguration config)
        ////{
        ////    config.Routes.MapHttpRoute(
        ////        name: "Default",
        ////        routeTemplate: "api/{controller}/"
        ////    );
        ////}

        //private static void EnableCrossSiteRequests(HttpConfiguration config)
        //{
            
        //    config.EnableCors();
        //}
    }
}

