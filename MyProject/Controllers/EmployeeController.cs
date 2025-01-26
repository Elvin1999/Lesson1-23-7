using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProject.Entities;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id=1,
                Firstname="Aysel",
                Lastname="Aliyeva",
                CityId=1,
                Point=10
            },
            new Employee
            {
                Id=2,
                Firstname="Leyla",
                Lastname="Mammadova",
                CityId=77,
                Point=98
            },
            new Employee
            {
                Id=3,
                Firstname="Huseyn",
                Lastname="Huseynzade",
                CityId=1,
                Point=90
            },
        };
        public IActionResult Index()
        {
            var vm = new EmployeeListViewModel
            {
                Employees = employees
            };
            return View(vm);
        }

        public IActionResult Delete(int id)
        {
            var item = employees.FirstOrDefault(e => e.Id == id);
            if (item != null)
            {
                employees.Remove(item);
                TempData["Message"] = $"{item.Firstname} deleted successfully";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new EmployeeAddViewModel
            {
                Employee = new Employee(),
                Cities=new List<SelectListItem>
                {
                    new SelectListItem{Text="Baku",Value="10"},
                    new SelectListItem{Text="Sumqayit",Value="50"},
                    new SelectListItem{Text="Khirdalan",Value="1"},
                }
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(EmployeeAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Employee.Id = (new Random()).Next(1, 10000);
                employees.Add(vm.Employee);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

    }
}
