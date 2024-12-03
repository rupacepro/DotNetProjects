using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WeatherApplication.Models;

namespace WeatherApplication.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> cityWeathers = new List<CityWeather>()
            {
                new CityWeather()
                {
                    CityUniqueCode = "LDN",
                    CityName = "London",
                    DateAndTime = new DateTime(2030,1,1,8,0,0),
                    TemperatureFahrenheit = 33,

                },
                new CityWeather()
                {
                    CityUniqueCode = "NYC",
                    CityName = "New York",
                    DateAndTime = new DateTime(2030, 1, 1, 3, 0, 0),
                    TemperatureFahrenheit = 60
                },
                new CityWeather()
                {
                    CityUniqueCode = "PAR",
                    CityName = "Paris",
                    DateAndTime = new DateTime(2030, 1, 1, 9, 0, 0),
                    TemperatureFahrenheit = 82

                }
            };
            


            return View(cityWeathers);
        }

        [Route("/weather/{cityCode}")]
        public IActionResult CityWeatherDetails(string cityCode)
        {
            List<CityWeather> cityWeathers = new List<CityWeather>()
            {
                new CityWeather()
                {
                    CityUniqueCode = "LDN",
                    CityName = "London",
                    DateAndTime = new DateTime(2030,1,1,8,0,0),
                    TemperatureFahrenheit = 33,

                },
                new CityWeather()
                {
                    CityUniqueCode = "NYC",
                    CityName = "New York",
                    DateAndTime = new DateTime(2030, 1, 1, 3, 0, 0),
                    TemperatureFahrenheit = 60
                },
                new CityWeather()
                {
                    CityUniqueCode = "PAR",
                    CityName = "Paris",
                    DateAndTime = new DateTime(2030, 1, 1, 9, 0, 0),
                    TemperatureFahrenheit = 82

                }
            };
            foreach(var cityWeather in cityWeathers)
            {
                if(cityWeather.CityUniqueCode == cityCode)
                {
                    return View(cityWeather);
                }
            }
            return BadRequest("City does not exists!");
        }
    }
}
