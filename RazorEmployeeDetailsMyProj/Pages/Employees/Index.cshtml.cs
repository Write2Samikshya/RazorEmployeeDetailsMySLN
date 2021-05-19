using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEmployeeDetailsMyProj.Services;
using RazorEmployeeDetailsMyProj.Models;

namespace RazorEmployeeDetailsMyProj.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepositoryint employeeRepositoryint;
        public IEnumerable<Employee> Employeesprop { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }


        public IndexModel(IEmployeeRepositoryint employeeRepositoryint)
        {
            this.employeeRepositoryint = employeeRepositoryint;
        }
        public void OnGet()
        {
            //Employeesprop = employeeRepositoryint.GetAllEmployees();

            Employeesprop = employeeRepositoryint.Search(SearchTerm);
        }
    }
}
