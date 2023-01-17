using Microsoft.AspNetCore.Mvc;

namespace Oopology.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
