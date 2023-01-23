using System.ComponentModel.DataAnnotations;

namespace Oopology.Models
{
    public class Course
    {
        [Key] public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public double Price { get; set; }

        public string? ImageThumbnailUrl { get; set; }
        public string? ThumbnailBack { get; set; }

    }

}
