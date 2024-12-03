

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseRouting();

Dictionary<int, string> countries = new Dictionary<int, string>
{
    {1, "United States" },
    {2, "Canada"},
    {3, "United Kingdom" },
    {4, "India" },
    {5, "Japan" }
};

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/countries", async (context) =>
    {
        foreach (var country in countries)
        {
            await context.Response.WriteAsync($"{country.Key}, {country.Value}\n");
        }
    });
    endpoints.MapGet("/countries/{id:range(1, 100)}", async (context) =>
    {
        if (!context.Request.RouteValues.ContainsKey("id"))
        {
            context.Response.StatusCode = 300;
            await context.Response.WriteAsync("The CountryId should be between 1 and 100");
        }

        int id = Int32.Parse(context.Request.RouteValues["id"].ToString());
        if (countries.ContainsKey(id))
        {
            string countryName = countries[id];
            await context.Response.WriteAsync($"{countryName}");
        }

        else
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync($"[No country]");
        }
    });
    endpoints.MapGet("/countries/{id:min(101)}", async (context) =>
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("The CountryID should be between 1 and 100 - min");
    });
});


app.Run();
