using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace RazorEmployeeDetailsMyProj.Models
{
   public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
       
        [Display(Name="Office Email")]
        public string Email { get; set; }

        public string PhotoPath { get; set; }

        [Required(ErrorMessage ="Department required")]
        public Dept? Department { get; set; }
    }
}
