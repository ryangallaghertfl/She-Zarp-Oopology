using Microsoft.AspNetCore.Mvc;
using Oopology.Models;

namespace Oopology.Controllers
{
    public class PurchaseController : Controller
    {

        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IShoppingCart _shoppingCart;

        public PurchaseController(IPurchaseRepository purchaseRepository, IShoppingCart shoppingCart)
        {
            _purchaseRepository = purchaseRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Checkout(Purchase purchase)
        //{
        //    var items = _shoppingCart.GetShoppingCartItems();
        //    _shoppingCart.ShoppingCartItems = items;

        //    if (_shoppingCart.ShoppingCartItems.Count == 0)
        //    {
        //        ModelState.AddModelError("", "Your cart is empty, elevate your consciousness now by purchasing our courses");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _purchaseRepository.CreatePurchase(purchase);
        //        _shoppingCart.ClearCart();
        //        return RedirectToAction("CheckoutComplete");
        //    }
        //    return View(purchase);
        //}

        //public IActionResult CheckoutComplete()
        //{
        //    ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!";
        //    return View();
        //}
    }
}
    

