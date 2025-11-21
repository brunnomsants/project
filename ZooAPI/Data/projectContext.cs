using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project.API.Models;

namespace project.API.Data
{
    public class projectContext : DbContext
    {
        public projectContext (DbContextOptions<projectContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animal { get; set; } = default!;
        public DbSet<Cares> Cares { get; set; } = default!;
    }
}
