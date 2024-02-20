using Microsoft.AspNetCore.Mvc;

namespace day2_mvc.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult ValidateAddress(string address)
        {
            
            bool isValid = (address == "Ale" || address == "Cairo" || address == "Giza");

            return Json(isValid);
        }

    }
}
