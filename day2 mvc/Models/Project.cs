using System.ComponentModel.DataAnnotations.Schema;

namespace day2_mvc.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Pname { get; set; }
        
        public string? Plocation { get; set; }
        public string? City { get; set; }
        [ForeignKey("departments")]
        public int? Dnum { get; set; }
        public List<Works_For> works_Fors { get; set; }
        public Departments departments { get; set; }
    }
}

