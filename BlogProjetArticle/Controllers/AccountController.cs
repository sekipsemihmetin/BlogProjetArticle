using BlogProjetArticle.Data;
using BlogProjetArticle.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjetArticle.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        } 

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                TempData["UserId"] = user.Id;
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid credentials");
            return View();
        }

        public IActionResult Logout()
        {
            TempData.Remove("UserId");
            return RedirectToAction("Login");
        }
    }
}
