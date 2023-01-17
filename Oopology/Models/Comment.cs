using System.ComponentModel.DataAnnotations;

namespace Oopology.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int PostID { get; set; }
        public Post? Post { get; set; }

    }
}
