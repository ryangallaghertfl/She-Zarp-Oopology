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
        public OopologyContext (DbContextOptions<OopologyContext> options)
            : base(options)
        {
        }

        public DbSet<Oopology.Models.Course> Course { get; set; } = default!;
    }
}
