using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Routing;
using Contracts.Exception;
using Contracts;

namespace BoilerPlate.Filters
{
    public class HttpExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger _logger;
        public HttpExceptionFilter(ILogger<HttpExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            if (exception is HttpException)
            {
                var ex = exception as HttpException;
                var result = new JsonResult(new { errorMessage = Constants.NOT_FOUND_MESSAGE })
                {
                    StatusCode = ex.StatusCode
                };
                context.Result = result;
            }
            else
            {
                var result = new JsonResult(new { errorMessage = Constants.API_ERROR }) { StatusCode = 500 };
                context.Result = result;
            }
            var message = Log(context.RouteData);
            _logger.LogError(new EventId(1001), exception, exception.Message + " in " + message);
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
