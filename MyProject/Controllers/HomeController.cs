using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using MyProject.Entities;
using MyProject.Models;
using MyProject.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ICalculator _calculator;

        //public HomeController(ICalculator calculator)
        //{
        //    _calculator = calculator;
        //}

        private readonly ICalculator _calculator1;
        private readonly ICalculator _calculator2;

        public HomeController(ICalculator calculator1, ICalculator calculator2)
        {
            _calculator1 = calculator1;
            _calculator2 = calculator2;
        }

        public string Index()
        {
            _calculator2.Calculate(100);
            return $"Data is {_calculator1.Calculate(100)}";
        }

        public IActionResult Index2()
        {
            return Ok();
        }

        public IActionResult Index3()
        {
            return BadRequest();
        }

        public IActionResult Index4()
        {
            return NotFound();
        }

        private List<Employee> employees = new List<Employee>
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

        private List<string> cities = new List<string> { "Baku", "Oslo", "Dubai" };

        public IActionResult Employees()
        {
            var vm = new EmployeeListViewModel
            {
                Cities = cities,
                Employees = employees
            };
            //return View(employees);
            //return View(vm);
            return Json(employees);
        }

        public IActionResult Data()
        {
            var result = employees.Select(e => new EmployeeModel
            {
                Id = e.Id,
                Firstname = e.Firstname,
                Lastname = e.Lastname,
            });
            return Json(result);
        }


        public IActionResult Employee(int id)
        {
            var item = employees.SingleOrDefault(e => e.Id == id);
            return Json(item);
        }


        public IActionResult Search(string word, int id = 0)
        {
            var wordResult = word.Trim().ToLower();
            var result = employees.Where(e => (e.Id == id || id == 0) && (e.Firstname.ToLower().Contains(wordResult)
            || e.Lastname.ToLower().Contains(wordResult)));
            return Json(result);
        }

        public IActionResult Test()
        {
            //return Redirect("/home/employees");
            //return RedirectToAction("employees");
            //return RedirectToAction("employee", new { id = 1 });

            var routeValue = new RouteValueDictionary(new { action = "Employee", controller = "Home", id = 1 });
            return RedirectToRoute(routeValue);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
