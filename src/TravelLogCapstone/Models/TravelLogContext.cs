using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelLogCapstone.Models
{
    public class TravelLogContext : DbContext
    {
        public TravelLogContext(DbContextOptions<TravelLogContext> options)
            : base(options)
        { }

        public DbSet<AppUsers> AppUsers { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
    }
}
