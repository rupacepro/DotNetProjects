
using ConfigurationExample.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//supply an object of Weather (with 'client' section) as a service
builder.Services.Configure<Weather>
    (builder.Configuration.GetSection("client"));

//load myownconfig.json
builder.Configuration.AddJsonFile
    ("MyOwnConfig.json", optional: true, reloadOnChange: true);

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.Map("/myname", async context =>
{
    await context.Response.WriteAsync(app.Configuration["myname"] + "\n"); //when the key value is set in the appsettings.json file
    await context.Response.WriteAsync(app.Configuration.GetValue<string>("noValue", "Values not provided in appsetttings.json"));
});

app.MapControllers();

app.Run();
