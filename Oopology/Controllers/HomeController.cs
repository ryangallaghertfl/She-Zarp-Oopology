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
            if (question1 == "A") score++;
            if (question2 == "A") score++;
            if (question3 == "A") score++;
            if (question4 == "A") score++;
            if (question5 == "A") score++;
            
            //Redirect to results view and pass score as parameter
            var questions = new List<string> { "question1", "question2", "question3", "question4", "question5" };
            var correctAnswers = new List<string> { "A", "A", "A", "A", "A" };
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
            //Pass score and userAnswers to the view
            return View("Results", new { score = score, userAnswers = userAnswers });
        }
       
    }
}