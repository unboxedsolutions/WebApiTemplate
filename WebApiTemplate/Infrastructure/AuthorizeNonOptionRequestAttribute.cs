using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;


namespace WebApiTemplate.Infrastructure {
    public class AuthorizeNonOptionRequestAttribute : AuthorizeAttribute {
        protected override bool IsAuthorized(HttpActionContext actionContext) {
            if (actionContext.Request.Method == HttpMethod.Options) {
                return true;
            }
            return base.IsAuthorized(actionContext);
        }
    }
}
