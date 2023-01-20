using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oopology.Models;

namespace Oopology.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public double? Price { get; set; }
    }
}