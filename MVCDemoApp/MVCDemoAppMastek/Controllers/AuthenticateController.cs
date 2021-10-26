using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDemoAppMastek.Models;
using Microsoft.Extensions.Configuration;



namespace MVCDemoAppMastek.Controllers
{
    public class AuthenticateController : Controller
    {
        TrainingContext db;
        public AuthenticateController(TrainingContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Userdatum());
        }
        [HttpPost]
        public IActionResult Index(Userdatum user)
        {
            Userdatum obj = db.Userdata.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (obj != null)
            {
                return RedirectToAction("Index", "Emp");
            }
            else
            {
                ModelState.AddModelError("error", "Invalid username pr password");
            }
            return View(user);
        }
    }
}