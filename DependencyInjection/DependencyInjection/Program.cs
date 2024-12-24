


using DependencyInjection.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IVehicleService, CarService>();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.Map("/myname", async context =>
{
    await context.Response.WriteAsync(app.Configuration["Mykey"]);
});

app.MapControllers();

app.Run();
