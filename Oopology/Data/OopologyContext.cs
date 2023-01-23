using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oopology.Models;

namespace Oopology.Data
{
    public class OopologyContext : DbContext
    {

        public OopologyContext(DbContextOptions<OopologyContext> options)
            : base(options)
        {
        }

        public DbSet<Oopology.Models.Comment> Comment { get; set; }

        public DbSet<Oopology.Models.Course> Course { get; set; }

        public DbSet<Oopology.Models.Post> Post { get; set; }

        public DbSet<Oopology.Models.Purchase> Purchase { get; set; }

        public DbSet<Oopology.Models.User> User { get; set; }

        public DbSet<Oopology.Models.ShoppingCartItem> ShoppingCartItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Course)
                .WithMany(c => c.Purchases)
                .HasForeignKey(p => p.CourseId);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.User)
                .WithMany(u => u.Purchases)
                .HasForeignKey(p => p.UserId);

            // any other existing configuration can go here
        }
    }
}
