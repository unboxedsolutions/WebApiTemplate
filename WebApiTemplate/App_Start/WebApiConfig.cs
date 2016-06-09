using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using WebApiTemplate.Infrastructure;

namespace WebApiTemplate {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            config.Services.Add(typeof(System.Web.Http.ExceptionHandling.IExceptionLogger), new WebApiExceptionLogger());

            var container = new WindsorContainer().Install(Configuration.FromAppConfig()).Install(FromAssembly.InDirectory(new AssemblyFilter("bin")));
            var httpDependencyResolver = new WindsorHttpDependencyResolver(container);
            config.DependencyResolver = httpDependencyResolver;

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
