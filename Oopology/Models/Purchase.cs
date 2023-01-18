using System.ComponentModel.DataAnnotations;
using Oopology.Models;

namespace Oopology.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? UserId { get; set; }

        public double? Price { get; set; }
    }
}