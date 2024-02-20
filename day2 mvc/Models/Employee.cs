using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace day2_mvc.Models
{
    public class Employee
    {
      
        public int Id { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public DateOnly? Bdate { get; set; }
        public string Address { get; set; }
        public string? Sex { get; set; }
        [Column(TypeName ="money")]
        public decimal? Salary { get; set; }
        [ForeignKey("workDepartment")]
        public int? Dno { get; set; }
        //[ForeignKey("leader")]
        //public int? Superssn { get; set; }


        //public Employee leader { get; set; }
        //[InverseProperty("leader")]
        // public List<Employee> group { get; set; }

        ////public Departments mangedept { get; set; }
        //public List<Works_For> works_Fors { get; set; }
        //public Departments departments { get; set; }
        //public List<Dependent> dependents { get; set; }


        [ForeignKey("leader")]
        public int? Superssn { get; set; }

        public Employee leader { get; set; }
        [InverseProperty("leader")]
        public List<Employee> group { get; set; }

        public Departments workDepartment { get; set; }
        public Departments mangeDepartment { get; set; }
        public List<Works_For> works_Fors { get; set; }
        //public Departments departments { get; set; }
        public List<Dependent> dependents { get; set; }

    }
}
