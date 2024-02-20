using day2_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace day2_mvc.Controllers
{
    public class AcountController : Controller
    {
      
        CompanyDbContext context = new();
       
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginDB(string name, string password)
        {
            
            Employee employee = context.Employees.SingleOrDefault(i => i.Fname == name && i.Id == int.Parse(password));

           
             
                HttpContext.Session.SetString("name", employee.Fname);
                HttpContext.Session.SetInt32("id", employee.Id);

             
                return RedirectToAction("Index","Employee");
           
        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }
    }
}
