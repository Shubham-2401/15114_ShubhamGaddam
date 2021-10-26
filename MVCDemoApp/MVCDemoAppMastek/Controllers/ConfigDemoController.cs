using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MVCDemoAppMastek.Controllers
{
    public class ConfigDemoController : Controller
    {
        public IConfiguration Config { get; private set; }
        public ConfigDemoController(IConfiguration _config)
        {
            Config = _config;  //DI
        }
        public IActionResult Index()
        {
            ViewBag.data = Config["CustomKey"];
            return View();
        }
    }
}
