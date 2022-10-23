using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ElCaminoDeCostaRica
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ElCaminoDeCostaRIca.FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            ElCaminoDeCostaRIca.RouteConfig.RegisterRoutes(RouteTable.Routes);
            ElCaminoDeCostaRIca.BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
