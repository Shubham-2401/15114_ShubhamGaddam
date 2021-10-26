using Microsoft.AspNetCore.Mvc;
using MVCDemoAppMastek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemoAppMastek.Controllers
{
    public class DBController : Controller
    {
        ProductDataStore dataStore;

        public DBController(ProductDataStore store)
        {
            dataStore = store;
        }
        public IActionResult Index()
        {
            List<Product> products = dataStore.GetProducts();
            return View(products);
        }
    }
}
