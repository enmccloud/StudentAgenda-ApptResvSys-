using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace StudentAgenda
{
    public class AgendaErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public AgendaErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = JsonConvert.SerializeObject(new
            {
                action = "error"
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return context.Response.WriteAsync(result);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AgendaErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseAgendaErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AgendaErrorMiddleware>();
        }
    }
}
