using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ProdBuilder0920.web.App_Start;

namespace ProdBuilder0920.web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
