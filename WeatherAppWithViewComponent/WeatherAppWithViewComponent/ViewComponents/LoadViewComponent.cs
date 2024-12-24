using Microsoft.AspNetCore.Mvc;
using WeatherAppWithViewComponent.Models;

namespace WeatherAppWithViewComponent.ViewComponents
{
    public class LoadViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<CityWeather> param)
        {
            return View("Load", param);
        }
    }
}
