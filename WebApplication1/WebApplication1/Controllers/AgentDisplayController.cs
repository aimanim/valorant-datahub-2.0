using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AgentDisplayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
