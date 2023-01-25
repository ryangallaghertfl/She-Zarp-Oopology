using System.IO.Pipelines;

namespace Oopology.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Course Course { get; set; } = default!;
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; }

    }
}
