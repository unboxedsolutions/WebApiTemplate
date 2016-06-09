using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApiTemplate.Infrastructure {
    public class WebApiTemplateOAuthProvider : OAuthAuthorizationServerProvider {
        private static IWebApiTemplateAuthentication _authenticationProvider;

        internal static void SetAuthenticationProvider(IWebApiTemplateAuthentication authenticationProvider) {
            _authenticationProvider = authenticationProvider;
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {
            var identity = new ClaimsIdentity("otc");
            var username = context.OwinContext.Get<string>("otc:username");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username));
            identity.AddClaim(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "user"));
            context.Validated(identity);
            return Task.FromResult(0);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context) {
            try {
                var username = context.Parameters["username"];
                var password = context.Parameters["password"];

                if (_authenticationProvider.Authenticate(username, password)) {
                    context.OwinContext.Set("otc:username", username);
                    context.Validated();
                }
                else {
                    context.SetError("Invalid credentials");
                    context.Rejected();
                }
            }
            catch {
                context.SetError("Server error");
                context.Rejected();
            }
            return Task.FromResult(0);
        }
    }
}