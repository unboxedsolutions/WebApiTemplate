﻿using System;
using System.IdentityModel.Tokens;
using System.Text;
using System.Web.Configuration;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace WebApiTemplate.Infrastructure
{
    public class WebApiTemplateJwtFormat : ISecureDataFormat<AuthenticationTicket> {
        private readonly OAuthAuthorizationServerOptions _options;

        public WebApiTemplateJwtFormat(OAuthAuthorizationServerOptions options)
        {
            _options = options;
        }

        public string SignatureAlgorithm {
            get { return "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256"; }
        }

        public string DigestAlgorithm {
            get { return "http://www.w3.org/2001/04/xmlenc#sha256"; }
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null) throw new ArgumentNullException("data");

            var issuer = WebConfigurationManager.AppSettings["jwt:Domain"] ?? "localhost";
            var audience = WebConfigurationManager.AppSettings["jwt:ClientID"] ?? "all";
            var key = Encoding.ASCII.GetBytes(WebConfigurationManager.AppSettings["jwt:ClientSecret"]);
            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(_options.AccessTokenExpireTimeSpan.TotalMinutes);
            var signingCredentials = new SigningCredentials(new InMemorySymmetricSecurityKey(key), SignatureAlgorithm, DigestAlgorithm);
            var token = new JwtSecurityToken(issuer, audience, data.Identity.Claims, now, expires, signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}