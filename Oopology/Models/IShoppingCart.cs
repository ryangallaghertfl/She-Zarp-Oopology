using System.IO.Pipelines;

namespace Oopology.Models;

public interface IShoppingCart
{
    void AddToCart(Course course);
    int RemoveFromCart(Course Course);
    List<ShoppingCartItem> GetShoppingCartItems();
    void ClearCart();
    decimal GetShoppingCartTotal();
    List<ShoppingCartItem> ShoppingCartItems { get; set; }
}