using Oopology.Data;
using static Oopology.Models.Purchase;

namespace Oopology.Models
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly OopologyContext _oopologyContext;
        private readonly IShoppingCart _shoppingCart;

        public PurchaseRepository(OopologyContext oopologyContext, IShoppingCart shoppingCart)
        {
            _oopologyContext = oopologyContext;
            _shoppingCart = shoppingCart;
        }

        public void CreatePurchase(Purchase purchase)
        {
            purchase.PurchasePlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            purchase.PurchaseTotal = _shoppingCart.GetShoppingCartTotal();

            purchase.PurchaseDetails = new List<PurchaseDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var purchaseDetail = new PurchaseDetail
                {
                    Amount = shoppingCartItem.Amount,
                    CourseId = shoppingCartItem.Course.Id,
                    Price = (decimal)shoppingCartItem.Course.Price
                };

                purchase.PurchaseDetails.Add(purchaseDetail);
            }

            _oopologyContext.Purchases.Add(purchase);

            _oopologyContext.SaveChanges();
        }
    }
}
