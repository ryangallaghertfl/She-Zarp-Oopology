using Oopology.Models;

namespace Oopology.Models
{
    public class Purchase
    {
        public string? Id { get; set; }
        public string? CourseId { get; set; }
        public string? UserId { get; set; }

        public double Price { get; set; }
    }
}


