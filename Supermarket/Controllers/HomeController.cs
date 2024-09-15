using Microsoft.AspNetCore.Mvc;

namespace Supermarket.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
