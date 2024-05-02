using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
