using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;
using System.Web.Mvc;

namespace RegisterAndLoginApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessLogin(UserModel user)
        {
            /*            SecurityService securityService = new SecurityService();
                        if (securityService.IsValid(user))
                        {
                            return View("LoginSuccess", user);
                        }
                        else
                        {
                            return View("LoginFailure", user);
                        }*/
            if (ModelState.IsValid)
            {
                SecurityService securityService = new SecurityService();
                if (securityService.IsValid(user))
                {
                    return View("LoginSuccess", user);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View("Index", user); // Return to the login page with validation errors

        }

        public ActionResult LoginSuccess(UserModel user)
        {
            return View(user);
        }

        public ActionResult LoginFailure(UserModel user)
        {
            return View(user);
        }
    }
}
