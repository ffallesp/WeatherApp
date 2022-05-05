using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WeatherApp.Models;

namespace WeatherApp {
    public class MvcApplication : System.Web.HttpApplication {
        //private Dictionary<string, ResponseWeatherModel> Cache = new Dictionary<string, ResponseWeatherModel>();
        protected void Application_Start() {
            //Application["Cache"] = Cache;
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
