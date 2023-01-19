using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Oopology.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? Content { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
        [AllowNull]
        public int? PostId { get; set; }
        public Post? Post { get; set; }

    }
}
