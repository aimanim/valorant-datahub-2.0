using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BarGraphDataController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BarGraphDataController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetBarGraphData()
        {
            var query = "SELECT agent_played as 'agent_name', COUNT(*) AS frequency FROM solo_matches GROUP BY agent_played";
            var data = _db.Set<SomeModel>().FromSqlRaw(query)
                .ToList();
            return Ok(data);
        }
    }
}
