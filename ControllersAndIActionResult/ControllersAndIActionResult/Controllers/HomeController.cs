using ControllersAndIActionResult.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ControllersAndIActionResult.Controllers
{
    public class HomeController: Controller
    {
        [Route("/")]
        [Route("home")]
        public IActionResult Greetings()
        {
            return Content("Namaste!", "text/plain"); // text/html
        }

        [Route("person")]
        public IActionResult PersonInfo()
        {
            Person person = new Person() { Id = 1, Name = "Rupesh", Address = "Toronto" };
            return Json(person);
        }

        [Route("file-download")]
        public IActionResult download() // if file inside wwwroot folder
        {
            //return new VirtualFileResult("/Rupesh_Shrestha_Transcript.pdf", "application/pdf");
            return File("/Rupesh_Shrestha_Transcript.pdf", "application/pdf");
        }


        [Route("file2")]
        public IActionResult Download1() //from other directory
        {
            //return new PhysicalFileResult(@"C:\Users\rupac\Desktop\Coop CV\Rupesh_Shrestha_Eligibility_Letter.pdf", "application/pdf");
            return PhysicalFile(@"C:\Users\rupac\Desktop\Coop CV\Rupesh_Shrestha_Eligibility_Letter.pdf", "application/pdf");

        }

        [Route("filefromotherdatabase")]
        public IActionResult Download2()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\rupac\Desktop\Coop CV\Rupesh_Shrestha_Eligibility_Letter.pdf");
            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");

        }
    }
}
