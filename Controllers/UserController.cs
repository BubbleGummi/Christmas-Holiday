using System.Security.Claims;
using Christmas_Holiday.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Christmas_Holiday.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(string returnUrl = "")
        {
            @ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserModel userModel, string returnUrl ="")
        {
            bool validUser = CheckUserCredentials(userModel);

            if (validUser == true)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, userModel.Username));

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                if (returnUrl != "")
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                ViewBag.ErrorMessage = "Fel användarnamn eller lösenord";
                @ViewData["ReturnUrl"] = returnUrl;
                return View();
            }
        }

        private bool CheckUserCredentials(UserModel userModel)
        {
            if (userModel.Username.ToUpper() == "ADMIN" && userModel.Password == "password")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<IActionResult> SignOutUser()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");

        }
    }
}
