using JoshGCloudServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace JoshGCloudServices.Controllers
{
    public class ProductController : Controller
    {
        public Products prodtbl = new Products();



        [HttpPost]
        public ActionResult MyWork(Products products)
        {
            var result2 = prodtbl.insert_product(products);
            return RedirectToAction("Home", "Home");
        }

        [HttpGet]
        public ActionResult MyWork()
        {
            return View(prodtbl);
        }
    }
}
