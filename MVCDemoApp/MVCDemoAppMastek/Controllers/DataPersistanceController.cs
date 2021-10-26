using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCDemoAppMastek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;


namespace MVCDemoAppMastek.Controllers
{
    public class DataPersistanceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.datetime = System.DateTime.Now;
            return View();
        }

        public IActionResult WriteCookies(string setting, string settingValue, bool isPersistent)
        {
            if (isPersistent == true)  //persistant cookie
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(2);
                Response.Cookies.Append(setting, settingValue, options); // add cookie on client machine
            }
            else //session cookie
            {
                Response.Cookies.Append(setting, settingValue);
            }
            ViewBag.Message = "Cookie written successfully!";
            return View("Index");
        }

        public IActionResult ReadCookies()
        {
            //reading cookie values

            ViewBag.FontName = Request.Cookies["fontName"];
            ViewBag.FontSize = Request.Cookies["fontSize"];
            ViewBag.Color = Request.Cookies["color"];

            if (string.IsNullOrEmpty(ViewBag.FontName))
            {
                ViewBag.FontName = "Arial";
            }
            if (string.IsNullOrEmpty(ViewBag.FontSize))
            {
                ViewBag.FontSize = "22px";
            }
            if (string.IsNullOrEmpty(ViewBag.Color))
            {
                ViewBag.Color = "Blue";
            }
            return View();
        }
   
    
    public IActionResult SetSessionValues()
        {
            HttpContext.Session.SetString("message", "Session test value");
            HttpContext.Session.SetInt32("count", 5);

            HttpContext.Session.SetString("dateobj", JsonSerializer.Serialize(DateTime.Now));

            Employee employee = new Employee() { EmpId = 101, EmpName = "Shubham", Salary = 300000 };
            string empserializedata = JsonSerializer.Serialize(employee);
            HttpContext.Session.SetString("empobj", empserializedata);

            return RedirectToAction("GetSessionValues");
        }

        public IActionResult GetSessionValues()
        {
            ViewBag.message = HttpContext.Session.GetString("message");
            ViewBag.count = HttpContext.Session.GetInt32("count");

            var dateobj = HttpContext.Session.GetString("dateobj");
            ViewBag.date = JsonSerializer.Deserialize<DateTime>(dateobj);

            string emp = HttpContext.Session.GetString("empobj");
            Employee empobj = JsonSerializer.Deserialize<Employee>(emp);
            ViewBag.emp = empobj;
            
            return View();
        }
    }
}
