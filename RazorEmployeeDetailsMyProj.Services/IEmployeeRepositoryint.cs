using RazorEmployeeDetailsMyProj.Models;
using System;
using System.Collections.Generic;

namespace RazorEmployeeDetailsMyProj.Services
{
    public interface IEmployeeRepositoryint
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployee(int id);

        Employee Update(Employee updatedEmployee);

        Employee Delete(int id);

        IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept);

        IEnumerable<Employee> Search(string searchTerm);

        Employee Add(Employee newEmployee);
    }
}
