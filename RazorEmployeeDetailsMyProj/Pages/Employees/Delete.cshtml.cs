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
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepositoryint employeeRepositoryint;

        public DeleteModel(IEmployeeRepositoryint employeeRepositoryint)
        {
            this.employeeRepositoryint = employeeRepositoryint;
        }

        [BindProperty]
        public Employee Employee { get; set; }


        public IActionResult OnGet(int id)
        {

            Employee = employeeRepositoryint.GetEmployee(id);

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            Employee deletedEmployee = employeeRepositoryint.Delete(Employee.Id);

            if (deletedEmployee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return RedirectToPage("Index");
        }
    }
}
