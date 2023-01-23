using static Oopology.Models.Purchase;
using System.IO.Pipelines;

namespace Oopology.Models
{
    public class PurchaseDetail
    {
        public int PurchaseDetailId { get; set; }
        public int PurchaseId { get; set; }
        public int CourseId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Course Course { get; set; } = default!;
        public Purchase Purchase { get; set; } = default!;
        
    }
}
