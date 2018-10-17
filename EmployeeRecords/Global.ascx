using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecords
{
    public class Global
    {
        public class WebApiApplication : System.Web.HttpApplication {
           protected void Application_Start()
    {
        WebApiConfig.Register(GlobalConfiguration.Configuration);
    } }
    }
}
