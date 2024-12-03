

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<LoginHandler>();
var app = builder.Build();

app.useLoginHandler();

app.Run(async (context) =>
{
    await context.Response.WriteAsync("No response");
});

app.Run();



//without middleware;
//using Microsoft.AspNetCore.WebUtilities;
//using Microsoft.Extensions.Primitives;

//namespace temp
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);
//            var app = builder.Build();

//            app.Run(async (context) =>
//            {
//                if (context.Request.Method == "POST" && context.Request.Path == "/")
//                {
//                    StreamReader reader = new StreamReader(context.Request.Body);
//                    string body = await reader.ReadToEndAsync();
//                    Dictionary<string, StringValues> kvp = QueryHelpers.ParseQuery(body);
//                    string? username = null;
//                    string? password = null;
//                    if (kvp.ContainsKey("username"))
//                    {
//                        username = kvp["username"][0];
//                    }
//                    else
//                    {
//                        context.Response.StatusCode = 400;
//                        await context.Response.WriteAsync("Invalid input for 'username");
//                    }
//                    if (kvp.ContainsKey("password"))
//                    {
//                        password = kvp["password"][0];
//                    }
//                    else
//                    {
//                        if (context.Response.StatusCode != 400)
//                            context.Response.StatusCode = 400;
//                        await context.Response.WriteAsync("Invalid input for 'password");
//                    }
//                    string validUsername = "admin";
//                    string validPassword = "admin@123";

//                    if (username == validUsername && password == validPassword)
//                    {
//                        context.Response.StatusCode = 200;
//                        await context.Response.WriteAsync("Successful login");
//                    }
//                    else
//                    {
//                        context.Response.StatusCode = 400;
//                        await context.Response.WriteAsync("Invalid login");
//                    }
//                }
//                else
//                {
//                    context.Response.StatusCode = 200;
//                    await context.Response.WriteAsync("No response");
//                }
//            });

//            app.Run();
//        }
//    }
//}
