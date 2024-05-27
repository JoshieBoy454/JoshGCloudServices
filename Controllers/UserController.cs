using JoshGCloudServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace JoshGCloudServices.Controllers
{
    public class UserController : Controller
    {

        public Users usrtbl = new Users();



        [HttpPost]
        public ActionResult About(Users Users)
        {
            var result = usrtbl.insert_User(Users);
            return RedirectToAction("Privacy", "Home");
        }

        [HttpGet]
        public ActionResult About()
        {
            return View(usrtbl);
        }


    }
}
