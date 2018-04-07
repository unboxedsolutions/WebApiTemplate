using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using WebApiTemplate.Infrastructure;

[assembly: OwinStartup(typeof(WebApiTemplate.Startup))]

namespace WebApiTemplate
{
    public class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
            
        public static string PublicClientId { get; private set; }

        public void ConfigureAuth(IAppBuilder app) {
            app.UseOAuthAuthorizationServer(new WebApiTemplateOAuthOptions());
            app.UseJwtBearerAuthentication(new WebApiTemplateJwtOptions());
        }
    }
}
