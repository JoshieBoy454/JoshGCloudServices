using JoshGCloudServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace JoshGCloudServices.Controllers
{
    public class ProductDisplayController : Controller
    {
        [HttpGet]
        public IActionResult MyWork()
        {
            var products = ProductDisplayModel.SelectProducts();
            return View(products);
        }
    }
}
