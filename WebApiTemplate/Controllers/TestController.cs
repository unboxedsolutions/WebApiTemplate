using System;
using log4net;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiTemplate.Infrastructure;
using System.Threading.Tasks;

namespace WebApiTemplate.Controllers
{
    [RoutePrefix("api/Test")]
    [OptionsRequestActionFilter]
    [AuthorizeNonOptionRequest]
    [EnableCors("* ", "* ", "* ")]
    public class TestController : ApiController {
        private static readonly ILog _logger = log4net.LogManager.GetLogger(typeof(TestController));

        public TestController() {
            //TODO: Dependency Injection
        }

        [Route("GetTestData")]
        [HttpGet]
        [HttpOptions]
        public async Task<IHttpActionResult> GetTestData() {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var results = await Task.FromResult(new {
                username = ClaimsPrincipal.Current.Identity.Name,
                DateTime = DateTime.UtcNow
            });
            
            return Ok(results);
        }
    }
}
