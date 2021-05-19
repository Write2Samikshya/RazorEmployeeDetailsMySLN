using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEmployeeDetailsMyProj.Models;
using RazorEmployeeDetailsMyProj.Services;

namespace RazorEmployeeDetailsMyProj.Pages.Employees
{
    public class EditTrialModel : PageModel
    {
        private readonly IEmployeeRepositoryint employeeRepositoryint;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditTrialModel(IEmployeeRepositoryint employeeRepositoryint, IWebHostEnvironment webHostEnvironment)
        {
            this.employeeRepositoryint = employeeRepositoryint;
            this.webHostEnvironment = webHostEnvironment;
        }

        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile EmpPhoto { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

        public string Message { get; set; }


        public IActionResult OnGet(int id)
        {
            Employee = employeeRepositoryint.GetEmployee(id);

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }


        public IActionResult Onpost(Employee employee)
        {

            if (EmpPhoto != null)
            {
                if (employee.PhotoPath != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", employee.PhotoPath);
                    System.IO.File.Delete(filePath);
                }

                employee.PhotoPath = ProcessUploadedFile();
            }

            Employee = employeeRepositoryint.Update(employee);
            return RedirectToPage("Index");

        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if(EmpPhoto != null)

            {
                string uploadsfolder = Path.Combine(webHostEnvironment.WebRootPath,"images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + EmpPhoto.FileName;
                string filepath = Path.Combine(uploadsfolder,uniqueFileName);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    EmpPhoto.CopyTo(filestream);
                }


            }
            return uniqueFileName;
        }

        public void OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notifications";
            }
            else
            {
                Message = "You have turned off email notifications";
            }

            Employee = employeeRepositoryint.GetEmployee(id);
        }


    }
}
