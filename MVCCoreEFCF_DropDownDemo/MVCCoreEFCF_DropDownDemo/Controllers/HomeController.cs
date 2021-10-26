using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MVCCoreEFCF_DropDownDemo.Models;
using MVCCoreEFCF_DropDownDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVCCoreEFCF_DropDownDemo.Controllers
{
    public class HomeController : Controller
    {
        private EFCFContext db;
        public HomeController(EFCFContext context)
        {
            db = context;
        }
        private void SeedDatabase()
        {
            if (db.Products.Any())
            {
                return;
            }
            List<Category> categoryList = new List<Category>();
            Category category1 = new Category() { CategoryId = 1, CategoryName = "electronics" };
            Category category2 = new Category() { CategoryId = 2, CategoryName = "beverages" };

            categoryList.Add(category1);
            categoryList.Add(category2);

            foreach (var item in categoryList)
            {
                db.Categories.Add(item);
            }
            db.SaveChanges();
            List<Product> productList = new List<Product>();
            Product product1 = new Product() { ProductId = 101, ProductName = "Laptop", Price = 25000, Category = category1 };
            Product product2 = new Product() { ProductId = 102, ProductName = "Mobile", Price = 35000, Category = category2 };

            Product product3 = new Product()
            {
                ProductId = 103,
                ProductName = "tea",
                Price = 50,
                Category = category2
            };
            Product product4 = new Product() { ProductId = 104, ProductName = "cofee", Price = 150, Category = category2 };
            productList.Add(product1);
            productList.Add(product2);
            productList.Add(product3);
            productList.Add(product4);

            foreach (var item in productList)
            {
                db.Products.Add(item);
            }
            db.SaveChanges();
        }

        public IActionResult Index()
        {
            SeedDatabase();
            return View(db.Products.ToList());
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
        
        [HttpGet]
        public IActionResult DropdownDemo()
        {
            var categoryList = (from c in db.Categories select new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList();
            categoryList.Insert(0, new SelectListItem() { Text = "-----Select-----", Value = string.Empty });

            DropdownViewModel dropdownViewModel = new DropdownViewModel();
            dropdownViewModel.CategoryList = categoryList;
            dropdownViewModel.ProductList = new List<Product>();
            
            //in view you are only binding dropdown with CategoryId property
            //So Model Binder will pass only CategoryId
            //Categorylist and ProductList will be null
            //So maintain CategoryList so do not require to populate on every postback from database in session variable
            string dataserializedata = JsonSerializer.Serialize(dropdownViewModel);
            HttpContext.Session.SetString("dataobj", dataserializedata);
            return View(dropdownViewModel);
        }

        [HttpPost]
        public IActionResult DropdownDemo(DropdownViewModel viewmodel)
        {
            string catid = viewmodel.CategoryId;

            //read session variable
            string data = HttpContext.Session.GetString("dataobj");
            DropdownViewModel dropDownViewModel = JsonSerializer.Deserialize<DropdownViewModel>(data);

            //populate CategoryList from session variable else we will get null error for dropdown SelectList
            viewmodel.CategoryList = dropDownViewModel.CategoryList;

            //for the catid fetch data from database and populate ProductList
            if (catid != null)
            {
                var productdata = (from p in db.Products where p.Category.CategoryId == int.Parse(catid) select p).ToList();
                viewmodel.ProductList = productdata;
            }
            else
            {
                viewmodel.ProductList = new List<Product>();
            }
            return View(viewmodel);
        }
    }
}