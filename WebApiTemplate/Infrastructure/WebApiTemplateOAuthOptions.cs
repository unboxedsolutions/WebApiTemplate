using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;

namespace WebApiTemplate.Infrastructure {
    public class WebApiTemplateOAuthOptions : OAuthAuthorizationServerOptions {
        public WebApiTemplateOAuthOptions() {
            TokenEndpointPath = new PathString("/token");
            AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60);
            AccessTokenFormat = new WebApiTemplateJwtFormat(new OAuthAuthorizationServerOptions());
            Provider = new WebApiTemplateOAuthProvider();
#if DEBUG
            AllowInsecureHttp = true;
#endif
        }
    }
}
