using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Repository;
using Services;
using System.Threading.Tasks;

namespace ex02.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Rating1  
    {
        private readonly RequestDelegate _next;

      
        public Rating1(RequestDelegate next)
        {
         
            _next = next;           
        }

        public async  Task Invoke(HttpContext httpContext, IRatingRepository rating)
        {
            Rating r = new Rating();
            _next(httpContext);
            //r.Host = httpContext.Request.Host;
            r.Method = httpContext.Request.Method;
            r.Path = httpContext.Request.Path;
            //r.Referer = httpContext.Request.Referer;
            //r.UserAgent = httpContext.Request.UserAgent;
            //r.RecordDate = httpContext.Request.RecordDate;
            rating.AddRating(r);
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Rating1>();


        }
    }
}
