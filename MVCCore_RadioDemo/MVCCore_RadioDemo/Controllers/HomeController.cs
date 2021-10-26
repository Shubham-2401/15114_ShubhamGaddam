using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MVCCore_RadioDemo.Models;
using MVCCore_RadioDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;



namespace MVCCore_RadioDemo.Controllers
{
    public class HomeController : Controller
    {
        //private NorthwindContext db;
        //SqlConnection connection;
        //IConfiguration Config;



        //public HomeController(IConfiguration _config, NorthwindContext context)
        //{
        // db = context;
        // Config = _config;
        // connection = new SqlConnection(Config["ConnectionStrings:NorthwindConnection"]);
        //}
        public IConfiguration Config { get; private set; }
        northwindContext db;



        public HomeController(northwindContext context, IConfiguration _config)
        {
            Config = _config;
            db = context;
        }
        //private readonly ILogger<HomeController> _logger;



        //public HomeController(ILogger<HomeController> logger)
        //{
        // _logger = logger;
        //}



        [HttpGet]
        public IActionResult Index()
        {
            var countries = db.Employees.Select(e => e.Country).Distinct().ToList();
            RadioDemoViewModel radioDemoViewModel = new RadioDemoViewModel();
            radioDemoViewModel.CountryList = countries as List<string>;
            radioDemoViewModel.CountryList.Insert(0, "All");
            radioDemoViewModel.Employees = new List<Employee>();




            string dataserializedata = JsonSerializer.Serialize(radioDemoViewModel);
            HttpContext.Session.SetString("dataobj", dataserializedata);
            return View(radioDemoViewModel);
        }
        [HttpPost]
        public IActionResult Index(RadioDemoViewModel viewmodelobject)
        {
            string country = viewmodelobject.Country;
            string data = HttpContext.Session.GetString("dataobj");
            RadioDemoViewModel radioDemoViewModel = JsonSerializer.Deserialize<RadioDemoViewModel>(data);
            viewmodelobject.CountryList = radioDemoViewModel.CountryList;



            var employeedata = from e in db.Employees select e;
            if (country != "All")
            {
                employeedata = employeedata.Where(e => e.Country.ToUpper() == country.ToUpper());
            }
            radioDemoViewModel.Employees = employeedata.ToList();
            return View(radioDemoViewModel);
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