using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome to the Best Bank");
        }
        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            var bankAccount = new
            {
                accountNumber = 1001,
                accountHolderName = "Example Name",
                currentBalace = 5000
            };
            return Json(bankAccount);
        }
        [Route("/account-statement")]
        public IActionResult AccountStatement()
        {
            return File("Rupesh_Shrestha_Transcript.pdf", "application/pdf");
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance(int? accountNumber)
        {
            var bankAccount = new
            {
                accountNumber = 1001,
                accountHolderName = "Example Name",
                currentBalace = 5000
            };
            if(accountNumber.HasValue)
            {
                if (Convert.ToInt16(Request.RouteValues["accountNumber"]) == 1001)
                {
                    return Content(bankAccount.currentBalace.ToString());
                }
                else
                {
                    Response.StatusCode = 404;
                    return Content("Account Number should be 1001");
                }
            }
            else
            {
                Response.StatusCode = 404;
                return Content("Account Number should be supplied", "text/plain");
            }
        }
    }
}
