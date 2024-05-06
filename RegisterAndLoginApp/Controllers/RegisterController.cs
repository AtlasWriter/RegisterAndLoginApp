using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterAndLoginApp.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        private readonly SecurityDAO securityDAO = new SecurityDAO();

        // after successfully inserting the user data into the database (isInserted is true), the user is redirected to the RegistrationSuccess action method of the RegisterController. The RegistrationSuccess action method then returns the RegistrationSuccess view, where you can display a success message or any other relevant information to the user.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessRegistration(RegisterationModel user)
        {
            if (ModelState.IsValid)
            {

                bool isInserted = securityDAO.InsertUser(user);

                if (isInserted)
                {
                    return RedirectToAction("RegistrationSuccess", "Register");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to register user. Please try again.");
                }
            }

            // If the ModelState is not valid, return to the registration page with validation errors
            return View("Index", user);
        }

        public ActionResult RegistrationSuccess(RegisterationModel user)
        {
            return View(user);
        }

    }

}