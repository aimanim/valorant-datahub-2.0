using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
