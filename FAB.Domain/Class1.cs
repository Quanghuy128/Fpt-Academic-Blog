using Microsoft.AspNetCore.Http;
using System.Net;

namespace FAB.Domain
{
    public class Class1 : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}