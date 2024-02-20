using day2_mvc.Models;
using day2_mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace day2_mvc.Controllers
{
    public class EmployeelistController : Controller
    {

        CompanyDbContext context = new CompanyDbContext();


        public IActionResult Index()
        {
            List<Employee> employees = context.Employees.ToList();
            return View(employees);
        }



        [HttpGet]
        public IActionResult Add()
        {
           

            EmployeeVM empVM = new EmployeeVM()
            {
                departments = new SelectList(context.Departments, nameof(Departments.Id), nameof(Departments.Dname))
            };
            return View(empVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Add(EmployeeVM empVM)
        {
            

            if (ModelState.IsValid)
            {
                Employee employee = new Employee()
                {
                   
                    Fname = empVM.Fname,
                    Lname = empVM.Lname,
                    Address = empVM.Address,
                    Salary = empVM.Salary,
                    Dno = empVM.Dno,
                };
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
          
            List<Departments> departments = context.Departments.ToList();
            empVM.departments = new SelectList(departments, nameof(Departments.Id), nameof(Departments.Dname));
            return View(empVM);


        }
    }
}