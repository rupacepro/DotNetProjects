using DotNetFirstAssignment;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System;
using System.IO;
using System.Net.Security;
using System.Security;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync("<p>Hello</p>");
    await next(context);
});

app.UseMyCustomMiddleware();

app.Run(async (context) =>
{
    await context.Response.WriteAsync("hi\n");
});

app.Run();





//StreamReader reader = new StreamReader(context.Request.Body);
//string name = await reader.ReadToEndAsync();
//string method = context.Request.Method;
//string name1 = context.Request.Query["name"];
//Dictionary<string, StringValues> name2 = QueryHelpers.ParseQuery(name);
//context.Response.Headers["Content-type"] = "text/html";

//if (name2.ContainsKey("age"))
//{
//    string age = name2["age"][0];
//    await context.Response.WriteAsync($"<p>{age}</p>");
//}

//await context.Response.WriteAsync($"<p>{method}</p>");
//await context.Response.WriteAsync($"<p>{name}</p>");
//await context.Response.WriteAsync($"<p>{name1}</p>");



