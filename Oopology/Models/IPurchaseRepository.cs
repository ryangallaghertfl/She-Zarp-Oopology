using static Oopology.Models.Purchase;

namespace Oopology.Models
{
    public interface IPurchaseRepository
    {
        void CreatePurchase(Purchase purchase);
    }
}
