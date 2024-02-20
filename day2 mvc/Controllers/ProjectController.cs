using day2_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day2_mvc.Controllers
{
    public class ProjectController : Controller
    {
        CompanyDbContext context;
        public ProjectController()
        {
            context = new CompanyDbContext();
        }
        public IActionResult Index()
        {
            List<Project> projects = context.Projects.Include(i => i.departments).ToList();
            return View(projects);

            return View();
        }


        public IActionResult Details(int id)
        {
            Project oneproject = context.Projects.Include(i => i.departments).SingleOrDefault(i => i.Id == id);
            return View(oneproject);
        }

        // Create 
        // display form
        public IActionResult GetAddForm()
        {
            List<Departments> departments = context.Departments.ToList();

            ViewData["departments"] = departments;
            return View();
        }

        //// get form data
        public IActionResult GetFormData(string name, string location, string city, int deptId)
        {
            Project project = new()
            {
                Pname = name,
                Plocation = location,
                City = city,
            Dnum = deptId
            };

            context.Projects .Add(project);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        // display form
        public IActionResult GetEditForm(int id)
        {
            Project project = context.Projects.SingleOrDefault(i => i.Id == id);
            List<Departments> departments = context.Departments.ToList();

            ViewData["departments"] = departments;
            return View(project);
        }
        public IActionResult Update(int id, string name, string location, string city, int deptId)
        {

            Project project = context.Projects.SingleOrDefault(i => i.Id == id);
            project.Pname= name;
            project.Plocation =location;
            project.City = city;
            project.Dnum = deptId;

            context.SaveChanges();

            return RedirectToAction("Index");
        }


        // Delete 

        public IActionResult Delete(int id)
        {
            Project project = context.Projects.SingleOrDefault(i => i.Id == id);
            context.Projects .Remove(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
    }

