using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;


namespace WebApiTemplate.Infrastructure {
    public class WebApiTemplateJwtOptions : JwtBearerAuthenticationOptions {
        public WebApiTemplateJwtOptions() {
            var issuer = WebConfigurationManager.AppSettings["jwt:Domain"] ?? "localhost";
            var audience = WebConfigurationManager.AppSettings["jwt:ClientID"] ?? "all";
            var key = Encoding.ASCII.GetBytes(WebConfigurationManager.AppSettings["jwt:ClientSecret"]);

            AllowedAudiences = new[] { audience };
            IssuerSecurityTokenProviders = new[] { new SymmetricKeyIssuerSecurityTokenProvider(issuer, key) };
        }
    }
}