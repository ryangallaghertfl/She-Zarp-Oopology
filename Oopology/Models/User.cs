using System.ComponentModel.DataAnnotations;

namespace Oopology.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? XpLevel { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}