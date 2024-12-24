using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private IVehicleService _vehicleService1;
        private IVehicleService _vehicleService2;
        private readonly IServiceScopeFactory _scopeFactory;
        public HomeController(IVehicleService carService1, IVehicleService carService2,
            IServiceScopeFactory serviceScopeFactory)
        {
            _vehicleService1 = carService1;
           
            _vehicleService2 = carService2;
            _scopeFactory = serviceScopeFactory; 
        }
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.result = _vehicleService1.GetWheelCount();
            ViewBag.id1 = _vehicleService1.id;
            ViewBag.id2 = _vehicleService2.id;

            using(IServiceScope scope = _scopeFactory.CreateScope())
            {
                //inject carservice
                IVehicleService vehicleService = scope.ServiceProvider.GetRequiredService<IVehicleService>();
                //db work
                ViewBag.idFromNewScope = vehicleService.id;
            }//end of the scope; it calls the carService.Dospose();
            return View();
        }
    }
}
