using Microsoft.AspNetCore.Mvc;

namespace ViewFirst.Controllers
{
    public class HomeController : Controller
    {
        [Route("/home")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
