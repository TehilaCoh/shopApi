using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Repository;
using Services;
using System.Threading.Tasks;

namespace ex02.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware  
    {
        private readonly RequestDelegate _next;



       public RatingMiddleware(RequestDelegate next)
        {
         
            _next = next;           
        }

        public async Task Invoke(HttpContext httpContext, IRatingService ratingService)
        {
            Rating r = new Rating();
            r.Method = httpContext.Request.Method;
            r.Path = httpContext.Request.Path;
            r.Host = httpContext.Request.Host.ToString();                     
            r.Referer = httpContext.Request.Headers.Referer;
            r.UserAgent = httpContext.Request.Headers.UserAgent;
            r.RecordDate = DateTime.Now;
            ratingService.AddRating(r);
            await _next(httpContext);

        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder RatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();


        }
    }
}



