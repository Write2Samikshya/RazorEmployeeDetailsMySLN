using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEmployeeDetailsMyProj.Models;
using RazorEmployeeDetailsMyProj.Services;

namespace RazorEmployeeDetailsMyProj.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepositoryint employeeRepositoryint;

        public DetailsModel(IEmployeeRepositoryint employeeRepositoryint)
        {
            this.employeeRepositoryint = employeeRepositoryint;
        }


        [BindProperty(SupportsGet = true)]
        public string Message { get; set; }
        public Employee Employeepropdetail { get; private set; }
        public IActionResult OnGet(int id)
        {
            Employeepropdetail = employeeRepositoryint.GetEmployee(id);
            if (Employeepropdetail == null)
            {

                return RedirectToPage("/NotFound");

            }

            return Page();
        }
    }
}
