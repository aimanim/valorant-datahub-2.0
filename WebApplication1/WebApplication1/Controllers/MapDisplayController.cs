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
        public MapDisplayController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string option)
        {
            Console.WriteLine(option);
            var query = "SELECT * FROM maps WHERE map_name = @Name";
            var data = _db.Set<Maps>().FromSqlRaw(query, new SqlParameter("@Name", option)).ToList();
            query = "Select * from location where location_id = @id";
            var loc = _db.Set<Location>().FromSqlRaw(query, new SqlParameter("id", data[0].Location_id)).ToList();
            data[0].location = loc[0].City + ", " + loc[0].Country;
            return View(data[0]);
        }
    }
}
