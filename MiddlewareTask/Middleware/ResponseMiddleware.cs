﻿using System.Diagnostics;

namespace MiddlewareTask.Middleware
{
    public class ResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = new Stopwatch();
            sw.Start();
            context.Response.OnStarting(state =>
            { 
                var httpREsponse  = (HttpContext)state;
                sw.Stop();
                context.Response.Headers.Add("Action-Name", context.Request.RouteValues["action"]?.ToString());
                context.Response.Headers.Add("HTTP-Method", context.Request.Method);
                context.Response.Headers.Add("HTTP-Scheme", context.Request.Scheme);
                context.Response.Headers.Add("Host", context.Request.Host.Host);
                context.Response.Headers.Add("Port", context.Request.Host.Port.ToString());
                context.Response.Headers.Add("Time-Taken", sw.ElapsedMilliseconds.ToString() + "ms");
                context.Response.Headers.Add("Server-Date-Time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                return Task.CompletedTask;
        
            },context);

            await _next(context);
        }
    }
}
