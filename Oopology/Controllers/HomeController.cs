using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Oopology.Data;


namespace Oopology.Controllers
{
    public class HomeController : Controller
    {
        private readonly OopologyContext _oopologyContext;

        public HomeController(OopologyContext oopologyContext)
        {
            _oopologyContext = oopologyContext;
        }

         public IActionResult Index()
        {
            bool isUserLoggedIn = (HttpContext.Session.GetInt32("User_Id")) != null;
            ViewBag.IsLoggedIn = isUserLoggedIn;
            return View();
        }

        //[Route("home/fundraiser")]
        //[HttpGet]
        public IActionResult Donation()
        {
            return View();
        }

        [Route("home/DonationSend")]
        [HttpPost]
        public IActionResult DonationSend(int donationAmount)
        {
            int? user_id = HttpContext.Session.GetInt32("User_Id");
            var user = _oopologyContext.User.Find(user_id);
            user.XpLevel += donationAmount;
            _oopologyContext.SaveChanges();
            return RedirectToAction("DonationSuccess");
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
        [HttpPost]
        public ActionResult Results()
        {
            int score = 0;
            //Retrieve answers from form
            string question1 = Request.Form["question1"];
            string question2 = Request.Form["question2"];
            string question3 = Request.Form["question3"];
            string question4 = Request.Form["question4"];
            string question5 = Request.Form["question5"];
            //Check answers against correct answers and increment score
            if (question1 == "C") score++;
            if (question2 == "B") score++;
            if (question3 == "A") score++;
            if (question4 == "D") score++;
            if (question5 == "A") score++;



            //Redirect to results view and pass score as parameter
            var questions = new List<string> { "question1", "question2", "question3", "question4", "question5" };
            var correctAnswers = new List<string> { "C", "B", "A", "D", "A" };
            var userAnswers = new List<string>();
            //Retrieve answers from form
            for (int i = 0; i < questions.Count; i++)
            {
                var userAnswer = Request.Form[questions[i]];
                userAnswers.Add(userAnswer);
                if (userAnswer == correctAnswers[i])
                {
                    score++;
                }
            }

            ViewBag.CorrectAnswers = correctAnswers;
            //Pass score and userAnswers to the view
            return View("Results", new { score = score, userAnswers = userAnswers });
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
            foreach (var entity in _oopologyContext.ShoppingCartItem)
            {
                _oopologyContext.ShoppingCartItem.Remove(entity);
                _oopologyContext.SaveChanges();
            }
            
            HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }
       
        [Route("/doctrine")]
        [HttpGet]
        public IActionResult Doctrine()
        {
            return View();
        }
    }
}
