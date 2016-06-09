using log4net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace WebApiTemplate.Infrastructure {
    public class WebApiExceptionLogger : ExceptionLogger {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(WebApiExceptionLogger));

        public async override Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken) {
            _logger.Error("An unhandled exception occurred.", context.Exception);
            await base.LogAsync(context, cancellationToken);
        }

        public override void Log(ExceptionLoggerContext context) {
            _logger.Error("An unhandled exception occurred.", context.Exception);
            base.Log(context);
        }

        public override bool ShouldLog(ExceptionLoggerContext context) {
            return base.ShouldLog(context);
        }
    }
}
