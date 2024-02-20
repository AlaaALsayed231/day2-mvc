using day2_mvc.Models;
using day2_mvc.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace day2_mvc.serverside
{
    public class uniqe : ValidationAttribute

    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            EmployeeVM employee = (EmployeeVM)validationContext.ObjectInstance;
            CompanyDbContext context = new();

            // Get the department ID from the employeeVM instance
            int departmentId = (int)employee.Dno;

            // Check if there is any employee with the same name in the same department
            var result = context.Employees.Any(e => e.Fname == value.ToString() && e.Dno == departmentId);

            if (result)
            {
                return new ValidationResult("Not unique within the department");
            }

            return ValidationResult.Success;
        }

    }
}
