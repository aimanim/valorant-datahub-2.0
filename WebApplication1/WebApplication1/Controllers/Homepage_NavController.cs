using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Homepage_NavController : Controller
    {
        private readonly ApplicationDbContext _db;
        private User user;
        public Homepage_NavController(ApplicationDbContext db)
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
    }
}
