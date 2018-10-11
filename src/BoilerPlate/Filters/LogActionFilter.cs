using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BoilerPlate.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        private readonly ILogger _iLogger;

        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _iLogger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var message = Log(filterContext.RouteData);
            _iLogger.LogInformation(new EventId(1001), "Entry " + message + " - {0}", JsonConvert.SerializeObject(filterContext.ActionArguments));
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var message = Log(filterContext.RouteData);
            if (filterContext.Exception == null)
            {
                _iLogger.LogInformation(new EventId(1001), "Exit " + message);
            }
            else
            {
                _iLogger.LogError(new EventId(1001), "Exception in " + message);
            }
        }

        private static string Log(RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = string.Format("controller:{0} action:{1}  ", controllerName, actionName);
            return message;
        }
    }
}
