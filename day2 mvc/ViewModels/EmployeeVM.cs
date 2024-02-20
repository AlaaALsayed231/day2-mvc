using day2_mvc.Models;
using day2_mvc.serverside;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace day2_mvc.ViewModels
{
    public class EmployeeVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
       
        [uniqe(ErrorMessage = "Employee name must be unique within the department.")]
        public string? Fname { get; set; }
       
        [Required(ErrorMessage = "Enter Name")]
        [uniqe(ErrorMessage = "Employee name must be unique within the department.")]
        public string? Lname { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [Remote("ValidateAddress", "Client",  ErrorMessage = "Address must be in Alex or Cairo or Giza")]

        //[RegularExpression("^(Alex|Cairo|Giza)$")]
        //[Required(ErrorMessage = "Address must be cairo or Alex or Gize")]
        public string Address { get; set; }
     
        [Column(TypeName = "money")]
        [Range(1500, 30000, ErrorMessage = "Salary must be from 1500 to 30000")]
        public decimal? Salary { get; set; }
        [Required]
        public int? Dno { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "You must enter the email")]
        public string Email { get; set; }
        [Compare("ConfirmPassword", ErrorMessage = "Password must match confirm")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password must match confirm")]
        public string ConfirmPassword { get; set; }
        [ValidateNever]
        public SelectList departments { get; set; }
       
   

       



       
    }
}
