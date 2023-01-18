using Microsoft.AspNetCore.Mvc;

namespace Oopology.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
