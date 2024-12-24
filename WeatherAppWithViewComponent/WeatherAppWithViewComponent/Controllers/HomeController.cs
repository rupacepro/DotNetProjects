using Microsoft.AspNetCore.Mvc;
using WeatherAppWithViewComponent.Models;

namespace WeatherAppWithViewComponent.Controllers
{
    public class HomeController : Controller
    {
        //initialize hard-coded data as instructed in the requirement
        private List<CityWeather> cities = new List<CityWeather>() {
            new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33 },

            new CityWeather() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60 },

            new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82 }
        };
        [Route("/")]
        public IActionResult Index()
        {
            return View(cities);
        }
        [Route("/weather/{cityCode}")]
        public IActionResult Details(string cityCode)
        {
            CityWeather? city = cities.Where(city => city.CityUniqueCode == cityCode).FirstOrDefault();
            return View(city);
        }

        [Route("load")]

        public IActionResult Load()
        {
            return ViewComponent("Load", new {param = cities});
        }
    }
}
