using JoshGCloudServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace JoshGCloudServices.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModel login;

        public LoginController()
        {
            login = new LoginModel();
        }

        [HttpPost]
        public ActionResult Privacy(string email, string password)
        {
            var loginModel = new LoginModel();
            int userID = loginModel.SelectUser(email, password);
            if (userID != -1)
            {
                HttpContext.Session.SetInt32("UserID", userID);
                //Successful login
                return RedirectToAction("Home", "Home");
            }
            else
            {
                //Failed login
                return View("Privacy");
            }
        }

    }
}
