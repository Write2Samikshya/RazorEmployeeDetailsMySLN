using Microsoft.AspNetCore.Mvc;
using RazorEmployeeDetailsMyProj.Models;
using RazorEmployeeDetailsMyProj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorEmployeeDetailsMyProj.ViewComponents
{
    public class HeadCountViewComponent:ViewComponent
    {
        private readonly IEmployeeRepositoryint employeeRepositoryint;

        public HeadCountViewComponent(IEmployeeRepositoryint employeeRepositoryint)
        {
            this.employeeRepositoryint = employeeRepositoryint;
        }
        public IViewComponentResult Invoke(Dept? department =null)
        {
            var result = employeeRepositoryint.EmployeeCountByDept(department);
            return View(result);
        }


    }
}
