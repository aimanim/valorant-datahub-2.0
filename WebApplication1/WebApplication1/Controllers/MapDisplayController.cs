using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MapDisplayController : Controller
    {
        private readonly ApplicationDbContext _db;
        private User user;
        public MapDisplayController(ApplicationDbContext db)
        {
            _db = db;
            user = new User();
            user.Username = "Guest Mode";
        }
        public IActionResult Index(string option,string Username = "Guest Mode")
        {
            user.Username = Username;
            var query = "SELECT * FROM maps WHERE map_name = @Name";
            var data = _db.Set<Maps>().FromSqlRaw(query, new SqlParameter("@Name", option)).ToList();
            query = "Select * from location where location_id = @id";
            var loc = _db.Set<Location>().FromSqlRaw(query, new SqlParameter("id", data[0].Location_id)).ToList();
            data[0].location = loc[0].City + ", " + loc[0].Country;
            data[0].user = user;
            return View(data[0]);
        }
    }
}
