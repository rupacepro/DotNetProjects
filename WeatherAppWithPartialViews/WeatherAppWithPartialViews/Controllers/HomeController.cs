using Microsoft.AspNetCore.Mvc;
using WeatherAppWithPartialViews.Models;

namespace WeatherAppWithPartialViews.Controllers
{
    public class HomeController : Controller
    {
        List<CityWeather> cityWeather = new List<CityWeather>()
        {
            new CityWeather()
            {
                CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33 
            },
            new CityWeather()
            {
                CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60 
            },
            new CityWeather() 
            { 
                CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82 
            }
        };
        [Route("/")]
        public IActionResult Index()
        {
            return View(cityWeather);
        }
        [Route("/weather/{cityCode}")]
        public IActionResult Details(string cityCode)
        {
            CityWeather? city = cityWeather.Where(single => single.CityUniqueCode == cityCode).FirstOrDefault();
            return View(city);
        }
    }
}
