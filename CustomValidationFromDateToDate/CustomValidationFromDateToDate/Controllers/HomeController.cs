using CustomValidationFromDateToDate.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomValidationFromDateToDate.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index(Bill bill)
        {
            if(!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(model => model.Errors).Select(error => error.ErrorMessage));
                return BadRequest(errors);
            }
            return Content("Success");
        }
    }
}
