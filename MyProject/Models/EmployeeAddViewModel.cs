using Microsoft.AspNetCore.Mvc.Rendering;
using MyProject.Entities;
using System.Collections.Generic;

namespace MyProject
{
    public class EmployeeAddViewModel
    {
        public Employee Employee { get; set; }
        public List<SelectListItem> Cities { get; set; }
    }
}