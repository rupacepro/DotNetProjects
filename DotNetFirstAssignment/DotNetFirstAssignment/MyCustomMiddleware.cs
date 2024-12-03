
namespace DotNetFirstAssignment
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Second Middleware\n");
            await next(context);
            await context.Response.WriteAsync("Middleware ends\n");
        }
    }

    public static class CustomMiddlewareExtention
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this WebApplication app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
