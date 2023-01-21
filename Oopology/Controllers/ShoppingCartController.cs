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



        public RedirectToActionResult AddToShoppingCart(int courseId)
        {
            var courseList = _oopologyContext.Course.ToList();
            
            var selectedCourse = courseList.FirstOrDefault(p => p.Id == courseId);

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
