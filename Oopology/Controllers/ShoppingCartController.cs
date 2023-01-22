using Microsoft.AspNetCore.Mvc;
using Oopology.Data;
using Oopology.Models;
using Oopology.ViewModels;

namespace Oopology.Controllers
{
    public class ShoppingCartController : Controller
    {
        //private readonly OopologyContext _context;
        private readonly IShoppingCart _shoppingCart;
        private readonly OopologyContext _oopologyContext;

        public ShoppingCartController(OopologyContext oopologyContext, IShoppingCart shoppingCart)
        {
            _oopologyContext = oopologyContext;
            _shoppingCart = shoppingCart;

        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }


        //int courseId keeps being null when passed in
        //public RedirectToActionResult AddToShoppingCart(int courseId)
        public RedirectToActionResult AddToShoppingCart(Course course)

        {
            var courseList = _oopologyContext.Course.ToList();
            Console.WriteLine($"courseList is{courseList}");

            //var selectedCourse = courseList.FirstOrDefault(p => p.Id == courseId);
            var selectedCourse = courseList.FirstOrDefault(p => p.Id == course.Id);
            Console.WriteLine($"selectedCourse is {selectedCourse}"); 
            if (selectedCourse != null)
            {
                _shoppingCart.AddToCart(selectedCourse);
            }

            return RedirectToAction("Index");
        }



        public RedirectToActionResult RemoveFromShoppingCart(int courseId)
        {
            var selectedCourse = _oopologyContext.Course.FirstOrDefault(p => p.Id == courseId);

            if (selectedCourse != null)
            {
                _shoppingCart.RemoveFromCart(selectedCourse);
            }
            return RedirectToAction("Index");
        }
    }
}
