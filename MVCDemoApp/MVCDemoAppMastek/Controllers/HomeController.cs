using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCDemoAppMastek.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemoAppMastek.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Demo()
        {
            return View();
        }

        //custom route
        //attribute base routing
        [Route("home/greet/{name?}")]
        public IActionResult Greet(string name)
        {
            ViewBag.msg = "Hello " + name;
            return View("Wish");
        }

        //parameterized action
        public IActionResult GetData(int id)
        {
            ViewBag.msg = "data = " + id;
            return View();
        }

        [Route("[controller]/[action]/{first:int:range(1,10)}/{second:int}")]
        public IActionResult AddNumbers(int first, int second)
        {
            ViewBag.msg = $"Addition of {first} + {second} = {first + second}";
            return View();
        }


        public IActionResult ModelDemo()
        {
            Employee employee = new Employee()
            {
                EmpId = 101,
                EmpName = "Shubham",
                Salary = 10000
            };
            ViewBag.emp = employee;
            return View();
        }

        public IActionResult GetEmployeeData()
        {
            return View();
        }

        public IActionResult DisplayEmployeeData()
        {
            Employee emp = new Employee();
            emp.EmpId = Convert.ToInt32(Request.Form["txtEmpID"]);
            emp.EmpName = Request.Form["txtEmpName"];
            emp.Salary = Convert.ToDouble(Request.Form["txtSalary"]);
            ViewBag.emp = emp;
            return View();
        }

        public IActionResult STGetEmployeeForm()
        {
            return View(new Employee() );
        }

        public IActionResult STDisplayEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                return View(emp);
            }
            else
            {
                return View("STGetEmployeeForm");
            }
        }
        
    }
}
