using day2_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day2_mvc.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyDbContext context;
        public DepartmentController()
        {
            context = new CompanyDbContext();
        }
        public IActionResult Index()
        {
            List<Departments> departments = context.Departments.Include(i => i.manger).ToList();

            return View(departments);


        }
        public IActionResult Details(int id)
        {
            Departments departments = context.Departments. SingleOrDefault(i => i.Id == id);
            List<Employee> employees = context.Employees.ToList();
            List<Employee> manger = context.Departments.Select(i => i.manger).ToList();

            List<Employee> UNmange = employees.Except(manger).ToList();

            return View(departments);
        }

        //public IActionResult GetAddForm()
        //{
        //    Departments department=CompanyDbContext.


        //    //List<Employee> employee = context.Employees.ToList();



        //    //ViewData["departments"] = departments;
        //    return View();
        //}
        public IActionResult Add()
        {
            //Departments departments = context.Departments.SingleOrDefault(i => i.Id == id);
            List<Employee> employees = context.Employees.ToList();
            List<Employee> manger = context.Departments.Select(i => i.manger).ToList();

            List<Employee> UNmange = employees.Except(manger).ToList();


            ViewBag.UNmange = UNmange.ToList();
            return View();
        }
        public IActionResult AddDB(Departments departments)
        {
            context.Departments .Add(departments);
            context.SaveChanges();

            return RedirectToAction("Index","Department");

            
        }

        // Edit 
        public IActionResult Edit(int id)
        {
            Departments departments = context.Departments.SingleOrDefault(i => i.Id == id);
            //ViewBag.departments = context.Departments.ToList();
            //return View(departments);
            List<Employee> employees = context.Employees.ToList();
            List<Employee> manger = context.Departments.Select(i => i.manger).ToList();

            List<Employee> UNmange = employees.Except(manger).ToList();


            ViewBag.UNmange = UNmange.ToList();
            return View(departments);
        }
        public IActionResult EditDB(Departments departments)
        {
          
                context.Departments.Update(departments);
                context.SaveChanges();

                return RedirectToAction("Index");
           
           

        }
        public IActionResult Delete(int id)
        {
            Departments departments = context.Departments.SingleOrDefault(i => i.Id == id);
            context.Departments.Remove(departments);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
