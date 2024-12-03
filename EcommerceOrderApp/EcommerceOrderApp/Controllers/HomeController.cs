using EcommerceOrderApp.CustomValidators;
using EcommerceOrderApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceOrderApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("/order")]
        public IActionResult Index(Order order)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(model => model.Errors).Select(error => error.ErrorMessage));
                return BadRequest(errors);
            }
            Random rnd = new Random(); 
            int randomNo = rnd.Next(1, 100000);
            return Content(randomNo.ToString() + " " +  order.InvoicePrice);
        }
    }
}
