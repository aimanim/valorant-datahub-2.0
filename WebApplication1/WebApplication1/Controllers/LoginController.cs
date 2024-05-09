using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;
        private User user;
        public LoginController(ApplicationDbContext db)
        {
            _db = db;
            user = new User();
            user.Username = "Guest Mode";
        }
        public IActionResult Index(string Username = "Guest Mode")
        {
            user.Username = Username;
            return View(user);
        }
        [HttpPost]
        public IActionResult Verify(string username, string password)
        {
            User RegisteredUser = new User();
            RegisteredUser.Username = username;
            RegisteredUser.Password = password;
            Console.WriteLine("Inside verify method, Username: " + username);
            if (IsValidUser(RegisteredUser))
            {
                Console.WriteLine("Verified");
                TempData["Username"] = RegisteredUser.Username;
                return RedirectToAction("Verified", "Homepage");

            }
            else
            {
                Console.WriteLine("SUCCESS NOT");
                ViewBag.ErrorMessage = "Invalid username or password";
                return BadRequest(new { ErrorMessage = "Invalid username or password" });
            }
        }


        private bool IsValidUser(User user)
        {
            var allUsers = _db.users.ToList();
            if (user.Username == "admin" && user.Password == "admin")
                return true;
            foreach (var db_user in allUsers)
            {
                if (db_user.Username == user.Username && db_user.Password == user.Password)
                {
                    return true;
                }
                
            }
            return false;
        }
    }
}
