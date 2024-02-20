using Microsoft.AspNetCore.Mvc.Rendering;

namespace day2_mvc.Models
{
    public class EmployeeEditViewModel
    {

        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public int SelectedProject { get; set; }
        public List<SelectListItem> Projects { get; set; }
        public int Hours { get; set; }
    }
}
