namespace day2_mvc.Models
{
    public class EmployeeProjectViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public List<ProjectHoursViewModel> Projects { get; set; }
    }
}
