using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        [Route("/person/{id}")]
        public IActionResult Index(int? id, Person person)
        {
            //List<string> errors = new List<string>();
            if (!ModelState.IsValid)
            {
                string  errors = string.Join("\n", ModelState.Values.SelectMany(singleModel => singleModel.Errors).Select(value => value.ErrorMessage));
                //foreach(var singleModel in ModelState.Values)
                //{
                //    foreach(var error in singleModel.Errors)
                //    {
                //        if (error != null)
                //        {
                //            errors.Add(error.ErrorMessage);
                //        }
                //    }
                //}
                return BadRequest(errors);
            }
            return Content($"Id: {id}");
        }
    }
}
