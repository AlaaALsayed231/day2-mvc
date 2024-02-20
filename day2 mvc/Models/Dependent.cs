using Microsoft.EntityFrameworkCore;

namespace day2_mvc.Models
{
    [PrimaryKey("ESSN", "Department_name")]
    public class Dependent
    {

        public int? ESSN { get; set; }
        public string? Department_name { get; set; }
        public string? Sex { get; set; }
        public DateOnly? Bdate { get; set; }
        public Employee employee { get; set;}
    }
} 
