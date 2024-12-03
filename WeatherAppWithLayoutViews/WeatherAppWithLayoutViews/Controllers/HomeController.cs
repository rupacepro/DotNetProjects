using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WeatherAppWithLayoutViews.Models;

namespace WeatherAppWithLayoutViews.Controllers
{
    public class HomeController : Controller
    {
        private List<CityWeather> cityWeathers = new List<CityWeather>()
            {
                new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = new DateTime(2030, 1, 1, 8, 0, 0), TemperatureFahrenheit = 33 },
                new CityWeather() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = new DateTime(2030, 1, 1, 3, 0, 0), TemperatureFahrenheit = 60 },
                new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = new DateTime(2030, 1, 1, 9, 0, 0),  TemperatureFahrenheit = 82}
        };
        [Route("/")]
        public IActionResult Index()
        {
            return View(cityWeathers);
        }
         [Route("/weather/{cityCode?}")]
         public IActionResult Details(string? cityCode)
            {
                if (string.IsNullOrEmpty(cityCode))
                {
                    return View();
                }
                CityWeather? city = cityWeathers.Where(city => city.CityUniqueCode == cityCode).FirstOrDefault();
                return View(city);
            }
    }
}
