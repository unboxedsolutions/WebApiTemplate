using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace WebApiTemplate.Infrastructure {
    public class OptionsRequestActionFilter : System.Web.Http.Filters.ActionFilterAttribute {
        public override void OnActionExecuting(HttpActionContext actionContext) {
            if (System.Web.HttpContext.Current.Request.HttpMethod == "OPTIONS") {
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.OK,
                    new { },
                    actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
                );
            }

            base.OnActionExecuting(actionContext);
        }
    }
}
