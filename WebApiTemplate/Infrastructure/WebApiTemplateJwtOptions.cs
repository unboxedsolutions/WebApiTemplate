﻿using System.Text;
using System.Web.Configuration;
using Microsoft.Owin.Security.Jwt;

namespace WebApiTemplate.Infrastructure
{
    public class WebApiTemplateJwtOptions : JwtBearerAuthenticationOptions
    {
        public WebApiTemplateJwtOptions()
        {
            var issuer = WebConfigurationManager.AppSettings["jwt:Domain"] ?? "localhost";
            var audience = WebConfigurationManager.AppSettings["jwt:ClientID"] ?? "all";
            var key = Encoding.ASCII.GetBytes(WebConfigurationManager.AppSettings["jwt:ClientSecret"]);

            AllowedAudiences = new[] { audience };
            IssuerSecurityTokenProviders = new[] { new SymmetricKeyIssuerSecurityTokenProvider(issuer, key) };
        }
    }
}
 