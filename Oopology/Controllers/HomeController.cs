using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Oopology.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("/signout")]
        [HttpGet]

        public IActionResult SignOut()
        {
            return View();
        }
        [Route("/signout2")]
        [HttpGet]

        public IActionResult SignOut2()
        {
            return View();
        }
        [Route("/signout3")]
        [HttpGet]

        public IActionResult SignOut3()
        {
            return View();
        }
        [Route("/signout4")]
        [HttpGet]

        public IActionResult SignOut4()
        {
            return View();
        }
        [Route("/signout5")]
        [HttpGet]

        public IActionResult SignOut5()
        {
            return View();
        }
        [Route("/signoutfrfr")]
        [HttpGet]

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

       
    }
}
