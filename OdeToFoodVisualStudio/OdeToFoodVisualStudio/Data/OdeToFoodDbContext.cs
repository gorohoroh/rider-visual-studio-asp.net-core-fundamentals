using Microsoft.EntityFrameworkCore;
using OdeToFoodVisualStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodVisualStudio.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
