using ConfigurationExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IConfiguration _configuration;

        //public HomeController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        //[Route("/")]
        //public IActionResult Index()
        //{
        //    ViewBag.name = _configuration["myname"];
        //    ViewBag.nameUsingGetValue = _configuration.GetValue<string>("myname");

        //    //getting hirarchical values
        //    ViewBag.clientId = _configuration["client:clientId"];

        //    //another way
        //    var options = _configuration.GetSection("client").Get<Weather>();
        //    ViewBag.clientSecret = options.clientSecret;

        //    return View();
        //}

        //another easy and straignt forward approach
        //add as a service in program.js and use Dependency injection

        private readonly Weather _weather;
        public HomeController(IOptions<Weather> weather)
        {
            _weather = weather.Value;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.clientSecret = _weather.clientSecret;
            return View();
        }
    }
}
