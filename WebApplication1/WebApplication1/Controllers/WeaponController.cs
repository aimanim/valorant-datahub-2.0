using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class WeaponController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
