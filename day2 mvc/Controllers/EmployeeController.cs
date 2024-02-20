using day2_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace day2_mvc.Controllers
{
    public class EmployeeController : Controller
    {


        private CompanyDbContext context;

        public EmployeeController()
        {
            context = new CompanyDbContext();

        }

        public IActionResult emp()
        {
            var employeesWithProjects = context.Employees
           .Include(e => e.works_Fors)
           .ThenInclude(wf => wf.project)
           .Select(e => new EmployeeProjectViewModel
           {
               EmployeeId = e.Id,
               EmployeeFullName = $"{e.Fname} {e.Lname}",
               Projects = e.works_Fors.Select(wf => new ProjectHoursViewModel
               {
                   ProjectId = wf.project.Id,
                   ProjectName = wf.project.Pname,
                   Hours = wf.Hours
               }).ToList()
           })
           .ToList();

            return View(employeesWithProjects);
        }










       

        public IActionResult Index()
        {
            List<Employee> employees = context.Employees.ToList();
            return View(employees);
        }
        public IActionResult Details(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(s => s.Id == id);

            return View(employee);
        }


        public IActionResult empwithHour()
        {



            var employeesWithProjects = context.Employees
            .Include(e => e.works_Fors)
            .ThenInclude(wf => wf.project)
            .Select(e => new
            {
                EmployeeId = e.Id,
                EmployeeFullName = $"{e.Fname} {e.Lname}",
                Projects = e.works_Fors.Select(wf => new
                {
                    ProjectId = wf.project.Id,
                    ProjectName = wf.project.Pname,
                    Hours = wf.Hours
                }).ToList()
            })
            .ToList();

            return View(employeesWithProjects);
        }

        public IActionResult Edit(int id)
        {
          
            var employee = context.Employees.Find(id);
            var projects = context.Projects.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Pname }).ToList();

            var viewModel = new EmployeeEditViewModel
            {
                EmployeeId = employee.Id,
                EmployeeFullName = $"{employee.Fname} {employee.Lname}",
                Projects = projects
            };

            return View(viewModel);
        }

        //// POST: Employee/Edit
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(EmployeeEditViewModel model)
        //{
        //    // Update employee information here (e.g., name, project, hours)
        //    // ...

        //    return RedirectToAction("Index"); // Redirect to the employee list or another appropriate action
        //}
  
    }


    }

