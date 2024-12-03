

using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

public class LoginHandler : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Method == "POST" && context.Request.Path == "/")
        {
            StreamReader reader = new StreamReader(context.Request.Body);
            string body = await reader.ReadToEndAsync();

            Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);
            string? username = null, password = null;

            if (queryDict.ContainsKey("username")){
                username = queryDict["username"][0];
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'username'\n");
            }
            if (queryDict.ContainsKey("password"))
            {
                password = queryDict["password"][0];   
            }
            else
            {
                if (context.Response.StatusCode == 200)
                    context.Response.StatusCode = 400;
                await context.Response.WriteAsync("invalid input for 'password'\n");
            }
            string validUsername = "admin@example.com";
            string validpassword = "admin1234"; 
            if(password == validpassword && username == validUsername)
            {
                await context.Response.WriteAsync("Successful login");
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid login");
            }
        }
        else
        {
            await next(context);
        }
    }
}

public static class LoginHandlerExtension
{
    public static IApplicationBuilder useLoginHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LoginHandler>();
    }
}
