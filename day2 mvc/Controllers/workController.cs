using day2_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day2_mvc.Controllers
{
    public class workController : Controller
    {
        private CompanyDbContext context;
        public workController()
        {
            context = new CompanyDbContext();
        }
        //get all
        public IActionResult Index()
        {
            List<Works_For> works = context.WorkFor.Include(e => e.employee).Include(p => p.project).ToList();
            // Create ViewBag to store colors
            List<string> colors = new List<string>();
            foreach (var work in works)
            {
                if (work.Hours > 50)
                {
                    colors.Add("green");

                }
                else
                {
                    colors.Add("red");
                }
            }

            ViewBag.Colors = colors;

            return View(works);
        }
        //get By Id
        public IActionResult Details(int id)
        {
            Employee employee = context.Employees .SingleOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            List<Works_For> worksForList = context.WorkFor.Include(p => p.project)
                                              .Where(w => w.ESSN== id)
                                              .ToList();

            ViewBag.EmployeeName = $"{employee.Fname} {employee.Lname}";
            List<string> colors = new List<string>();
            foreach (var work in worksForList)
            {
                if (work.Hours > 50)
                {
                    colors.Add("green");

                }
                else
                {
                    colors.Add("red");
                }
            }

            ViewBag.Colors = colors;

            return View(worksForList);
        }
        //======================================================================
        //edit operaion
        public IActionResult Edit(int id)
        {
            Employee emp = context.Employees.Where(p => p.Id == id).SingleOrDefault();
            List<Project> project = context.WorkFor.Include(w => w.project).Where(w => w.ESSN == id).Select(p => p.project).ToList();

            ViewBag.project = project;
            ViewBag.employee = emp;
            return View();
        }
        public IActionResult EditDB(Works_For works)
        {
            context.WorkFor.Update(works);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult editscript(int id, int ssn)
        {
            Works_For hours = context.WorkFor.Where(w => w.Pno == id && w.ESSN == ssn).FirstOrDefault();

            return PartialView("_editpartial", hours);

        }
    }
}
