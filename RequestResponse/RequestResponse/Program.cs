
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["content-type"] = "text/html";
    if (context.Request.Query.ContainsKey("id"))
    {
        string id = context.Request.Query["id"];
        await context.Response.WriteAsync($"<h1>{id}</h1>");
    }
});

app.Run();
