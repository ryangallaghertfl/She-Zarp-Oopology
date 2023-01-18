﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Oopology.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Comment>? Comments { get; set; }

        public int? Likes { get; set; }
    }
}
