using System.IO.Pipelines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oopology.Data;

namespace Oopology.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly OopologyContext _oopologyContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        public ShoppingCart(OopologyContext oopologyContext)
        {
            _oopologyContext = oopologyContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            OopologyContext context = services.GetService<OopologyContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        

        public void AddToCart(Course course)
        {
            var shoppingCartItem =
                    _oopologyContext.ShoppingCartItem.SingleOrDefault(
                        s => s.Course.Id == course.Id && s.ShoppingCartId == ShoppingCartId);

            

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Course = course,
                    Amount = 1
                };

                _oopologyContext.ShoppingCartItem.Add(shoppingCartItem);
                _oopologyContext.SaveChanges();

            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _oopologyContext.SaveChanges();
        }






        public int RemoveFromCart(Course course)
        {
            var shoppingCartItem =
                _oopologyContext.ShoppingCartItem.SingleOrDefault(
                        s => s.Course.Id == course.Id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _oopologyContext.ShoppingCartItem.Remove(shoppingCartItem);
                }
            }

            _oopologyContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                _oopologyContext.ShoppingCartItem.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Course)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _oopologyContext
                .ShoppingCartItem
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _oopologyContext.ShoppingCartItem.RemoveRange(cartItems);

            _oopologyContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _oopologyContext.ShoppingCartItem.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Course.Price * c.Amount).Sum();
            return (decimal)total;
        }
    }
}
