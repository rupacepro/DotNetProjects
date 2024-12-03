using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
            if (!Request.Query.ContainsKey("bookId")){
                return BadRequest("Book Id must be supplied!");
            };
            if (string.IsNullOrEmpty(Request.Query["bookId"].ToString()))
            {
                return BadRequest("Book Id cannot be null or empty!");
            }
            int bookId = Convert.ToInt16(Request.Query["bookId"]);
            if (bookId < 0 || bookId > 1000)
            {
                return NotFound("Book not found!");
            }
            if (Convert.ToBoolean(Request.Query["isAuthorized"]) == false)
            {
                return Unauthorized("You must be authorized to access this file!");
            }
            return File("/Rupesh_Shrestha_Eligibility_Letter.pdf", "application/pdf");
        }
    }
}
