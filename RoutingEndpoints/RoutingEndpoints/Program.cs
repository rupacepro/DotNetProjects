
var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "myroot"
});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("files/{id:minlength(3)}", async (context) =>
    {
        string id = context.Request.RouteValues["id"].ToString();

        await context.Response.WriteAsync($"{id}");
    });
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Root");
});
app.Run();

