using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementSystem.Models;
using System.Web.Security;

namespace ProjectManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Authorize(Roles ="Developer,Project Manager,Team Lead, QA Engineer,UX Engineer, IT Admin")]
        public ActionResult Index()
        {
            return View();
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model, string returnUrl)
        {
            var data = db.User.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
            if (data != null)
            {
                FormsAuthentication.SetAuthCookie(Convert.ToString(data.UserID), false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                 && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return RedirectToAction(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid User name/password");
                return View();
            }

        }
        [Authorize]
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
        public ActionResult page()
        {
            return View();
        }

    }
}