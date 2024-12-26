using StockApp.Services;

namespace StockApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped< MyInterface, MyService >();
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            var app = builder.Build();

            app.UseRouting();
            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
