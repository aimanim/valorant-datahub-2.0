using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        public User user;
        public LeaderboardController(ApplicationDbContext db)
        {
            _db = db;
            user = new User();
        }
        public IActionResult Index(string Username = "Guest Mode")
        {
            user.Username = Username;
            List<Leaderboards> objLeaderboardRecords = _db.leaderboards.ToList();
            Tuple<User,List<Leaderboards>> aModel = new Tuple<User, List<Leaderboards>>(user, objLeaderboardRecords);
            return View(aModel);
             

        }
    }
}
