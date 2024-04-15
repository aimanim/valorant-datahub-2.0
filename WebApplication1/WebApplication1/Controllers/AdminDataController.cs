using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminDataController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminDataController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string option)
        {
            var ViewModel = new GenericModel();
            ViewModel.optionClicked = option;
            switch (option)
            {
                case "agents":
                    
                    ViewModel.agents = _db.Agents.ToList();
                    break;
                case "soloMatches":
                    ViewModel.soloMatches = _db.solomatches.ToList();
                    break;
                case "Weapons":
                    ViewModel.Weapons = _db.weapons.ToList();
                    break;
            }
            return View(ViewModel);
        }
    }
}
