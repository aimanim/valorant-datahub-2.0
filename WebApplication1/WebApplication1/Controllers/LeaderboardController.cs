using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LeaderboardController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objLeaderboardRecords = _db.leaderboards.ToList();
            return View(objLeaderboardRecords);
        }
    }
}
