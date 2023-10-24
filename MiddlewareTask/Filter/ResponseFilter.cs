using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MiddlewareTask.Filter
{
    public class ResponseFilter : IActionFilter
    {
        private readonly Stopwatch _sw = new Stopwatch();

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _sw.Stop();
            var httpContext = context.HttpContext;
            httpContext.Response.Headers.Add("Action-Name", context.ActionDescriptor.DisplayName);
            httpContext.Response.Headers.Add("HTTP-Method", httpContext.Request.Method);
            httpContext.Response.Headers.Add("HTTP-Scheme", httpContext.Request.Scheme);
            httpContext.Response.Headers.Add("Host", httpContext.Request.Host.Host);
            httpContext.Response.Headers.Add("Port", httpContext.Request.Host.Port.ToString());
            httpContext.Response.Headers.Add("Time-Taken", _sw.ElapsedMilliseconds.ToString() + "ms");
            httpContext.Response.Headers.Add("Server-Date-Time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _sw.Start();
        }
    }
}
