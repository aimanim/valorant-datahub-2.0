using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
namespace WebApplication1.Controllers
{
    public class AgentDisplayController : Controller
    {
        private readonly ApplicationDbContext _db;
        private User user;
        public AgentDisplayController(ApplicationDbContext db)
        {
            _db = db;
            user = new User();
            user.Username = "Guest Mode";
        }
        public IActionResult Index(string option,string Username = "Guest Mode")
        {
            
            Console.Write("THIS IS THE AGENT NAME: " + option);
            var query = "SELECT * FROM agents WHERE agent_name = @Name";
            var data = _db.Set<agents>().FromSqlRaw(query, new SqlParameter("@Name", option)).ToList();
            query = "Select * from agent_abilities where name = @Name";
            var abilities = _db.Set<AgentAbilities>().FromSqlRaw(query, new SqlParameter("@Name", option)).ToList();
            Agent_And_Abilities hehe = new Agent_And_Abilities();
            Console.WriteLine(data[0]);
            Console.WriteLine(abilities[0]);
            hehe.agent = data[0];
            hehe.abilities = abilities[0];
            user.Username = Username;
            hehe.user = user;
            Console.WriteLine(Username);
            return View(hehe);
        }
    }
}
