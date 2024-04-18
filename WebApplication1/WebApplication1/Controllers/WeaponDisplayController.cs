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
        public WeaponDisplayController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string option)
        {
            var query = "SELECT * FROM weaponary WHERE weapon_name = @Name";
            var data = _db.Set<Weapons>().FromSqlRaw(query, new SqlParameter("@Name", option)).ToList();
            return View(data[0]);
        }
    }
}
