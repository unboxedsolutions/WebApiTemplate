using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using log4net.Config;
using System.Web.Optimization;

[assembly: XmlConfigurator(ConfigFile = "Web.config", Watch = true)]

namespace WebApiTemplate {
    public class WebApiApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
