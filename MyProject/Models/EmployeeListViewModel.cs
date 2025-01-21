using MyProject.Entities;
using System.Collections;
using System.Collections.Generic;

namespace MyProject.Models
{
    public class EmployeeListViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<string> Cities { get; set; }
    }
}
