using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace day2_mvc.Models
{
    public class Departments
    {
        [Key ]
        public int Id { get; set; }
        public string Dname { get; set; }
        //[ForeignKey("manger")]
        //public int? MGRSSN { get; set; }
        //public DateOnly MGRStartDate { get; set; }
        //public List<Project> projects { get; set; }

        ////[InverseProperty("mangedept")]
        //public Employee manger { get; set; }

        //[InverseProperty("departments")]
        //public List<Employee> employees { get; set; }



        [ForeignKey("manger")]
        public int? MGRSSN { get; set; }
        public DateOnly MGRStartDate { get; set; }
        public List<Project> projects { get; set; }

        [InverseProperty("mangeDepartment")]
        public Employee manger { get; set; }

        [InverseProperty("workDepartment")]
        public List<Employee> employees { get; set; }


    }
}

