using Microsoft.AspNetCore.Mvc;

namespace Oopology.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //[Route("home/fundraiser")]
        //[HttpGet]
        public IActionResult Donation()
        {
            return View();
        }

        //[Route("home/fundraiserSuccess")]
        //[HttpGet]
        public IActionResult DonationSuccess()
        {
            return View();
        }

        public IActionResult Assessment()
        {
            return View();
        }
        //[HttpPost]
        public IActionResult AssessmentSubmitted()
        {
            return View();
        }
    }
}