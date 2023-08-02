using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        private readonly List<User> _users = new List<User>();
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // In a real app, you would hash the password before saving it.
                _users.Add(user);

                return RedirectToAction("Login");
            }

            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string emailOrUsername, string password)
        {
            var user = _users.FirstOrDefault(u => u.Email == emailOrUsername || u.Username == emailOrUsername);

            if (user != null && user.Password == password)
            {
                // In a real app, you would set authentication cookies or tokens.
                return RedirectToAction("Profile");
            }

            ViewBag.ErrorMessage = "Invalid credentials. Please try again.";
            return View();
        }

    }
}
