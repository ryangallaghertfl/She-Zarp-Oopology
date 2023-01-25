using Microsoft.AspNetCore.Mvc;
using Oopology.Models;

namespace Oopology.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IShoppingCart _shoppingCart;
        private readonly OopologyContext _oopologyContext;

        public PurchaseController(IPurchaseRepository purchaseRepository, IShoppingCart shoppingCart, OopologyContext oopologyContext)
        {
            _purchaseRepository = purchaseRepository;
            _shoppingCart = shoppingCart;
            _oopologyContext = oopologyContext;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, elevate your consciousness now by purchasing our courses");
            }

        
            if (ModelState.IsValid)
            {
                _purchaseRepository.CreatePurchase(purchase);
                int? userId = HttpContext.Session.GetInt32("User_Id");
                var user = _oopologyContext.User.Find(userId);
                decimal tempNum = purchase.PurchaseTotal;
                int newNum = (int)tempNum;
                user.XpLevel += newNum;
                _shoppingCart.ClearCart();
                _oopologyContext.SaveChanges();
                return RedirectToAction("CheckoutComplete");
            }
            return View(purchase);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your purchase. An OOPOLOGY agent is on their way to visit you in person with your course(s)!";
            return View();
        }
    }
}
    

