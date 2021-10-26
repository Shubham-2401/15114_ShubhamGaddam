using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDemoAppMastek.Models;

namespace MVCDemoAppMastek.Controllers
{
    public class DIDemoController : Controller
    {
        private readonly ITransientService _transientService1, _transientService2;

        private readonly IScopedService _scopedService1, _scopedService2;

        private readonly ISingletonService _singletonService1, _singletonService2;
        public DIDemoController(
            ITransientService transientService1,
            ITransientService transientService2,
            IScopedService scopedService1,
            IScopedService scopedService2,
            ISingletonService singletonService1,
            ISingletonService singletonService2)
        {
            _transientService1 = transientService1;
            _transientService2 = transientService2;

            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;

            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }
        public IActionResult Index()
        {
            //each object is a different object
            //left is each call
            ViewBag.transient1 = _transientService1.GetOperationID().ToString();
            ViewBag.transient2 = _transientService2.GetOperationID().ToString();

            //for entire request one object is provided
            //left is request
            ViewBag.scoped1 = _scopedService1.GetOperationID().ToString();
            ViewBag.scoped2 = _scopedService2.GetOperationID().ToString();

            //for entire application one object is provided
            //life is application running
            ViewBag.singleton1 = _singletonService1.GetOperationID().ToString();
            ViewBag.singleton2 = _singletonService2.GetOperationID().ToString();
            
            return View();
        }
    }
}
