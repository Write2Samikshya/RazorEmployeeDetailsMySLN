using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEmployeeDetailsMyProj.Models;
using RazorEmployeeDetailsMyProj.Services;

namespace RazorEmployeeDetailsMyProj.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepositoryint employeeRepositoryint;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditModel(IEmployeeRepositoryint employeeRepositoryint, IWebHostEnvironment webHostEnvironment)
        {
            this.employeeRepositoryint = employeeRepositoryint;
            this.webHostEnvironment = webHostEnvironment;
        }

        //public Employee empeditprop { get; private set; }
        [BindProperty]
        public Employee empeditprop { get; private set; }

        [BindProperty]

        public IFormFile Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

        public string Message { get; set; }

        public IActionResult OnGet( int id )
        {
            empeditprop= employeeRepositoryint.GetEmployee( id);

            if (empeditprop==null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(Employee empeditprop)
        {

            

                if (Photo != null)

                {
                    if (empeditprop.PhotoPath != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", empeditprop.PhotoPath);

                        System.IO.File.Delete(filePath);

                    }


                    empeditprop.PhotoPath = ProcessUploadedFile();

                }
                empeditprop = employeeRepositoryint.Update(empeditprop);
                return RedirectToPage("Index");

          
        }

        public IActionResult OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notifications";
            }
            else
            {
                Message = "You have turned off email notifications";
            }

            //empeditprop = employeeRepositoryint.GetEmployee(id);

            //return RedirectToPage("Details", new { id = id, message = Message });

            TempData["message"] = Message;

           
            return RedirectToPage("Details", new { id = id });

        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFollder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFollder, uniqueFileName);
                using(var fileStream=new FileStream(filePath,FileMode.Create))
                {

                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
