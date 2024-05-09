using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WeaponDisplayController : Controller
    {
        private readonly ApplicationDbContext _db;
        private User user;
        public WeaponDisplayController(ApplicationDbContext db)
        {
            _db = db;
            user = new User();
            user.Username = "Guest Mode";
        }
        public IActionResult Index(string option,string Username = "Guest Mode")
        {
            user.Username = Username;
            var query = "SELECT * FROM weaponary WHERE weapon_name = @Name";
            List<Weaponary> w = _db.Set<Weaponary>().FromSqlRaw(query, new SqlParameter("@Name", option)).ToList();
            w[0].user = user;
            return View(w[0]);
        }
    }
}
