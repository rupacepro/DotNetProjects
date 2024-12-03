using CustomModelBinding.CustomModelBinder;
using CustomModelBinding.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomModelBinding.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        //[ModelBinder(BinderType = typeof(PersonModelBinder))]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                string Errors = string.Join("\n", ModelState.Values.SelectMany(singleProp => singleProp.Errors).Select(error => error.ErrorMessage));
                return BadRequest(Errors);
            }
            return Content($"hi {person.FullName}, {person.Phone}");
        }
    }
}
