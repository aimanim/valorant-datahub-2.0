using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomepageController : Controller
    {
        private readonly ApplicationDbContext _db;


        private User user;
        public HomepageController(ApplicationDbContext db)
        {
            _db = db;
            user = new User();
            user.Username = "Guest Mode";
        }

        public IActionResult Index(string Username = "Guest Mode")
        {
            user.Username = Username;
            return View("Index",user);
        }
        public IActionResult Verified()
        {
            user.Username = TempData["Username"] as string;
            Console.WriteLine("Inside verified method" + user.Username);
            return RedirectToAction("Index", new { Username = user.Username });

        }
        





    }
}
