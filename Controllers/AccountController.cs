using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using TripPlanner_1.Models;

namespace TripPlanner_1.Controllers
{
    public class AccountController : Controller
    {
        private readonly TripPlanner1Context _context;

        public AccountController(TripPlanner1Context context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(string username, string password, string loginAs)
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

            if (user != null)
            {
                if (loginAs == "user")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim("User", "true")
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Home");
                }
                else if (loginAs == "User")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim("User", "true")
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Home");
                }
            }

        
            return RedirectToAction("Login");
        }
    }
}
