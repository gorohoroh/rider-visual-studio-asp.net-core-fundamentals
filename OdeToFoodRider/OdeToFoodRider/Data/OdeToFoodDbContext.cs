using Microsoft.EntityFrameworkCore;
using OdeToFoodRider.Models;

namespace OdeToFoodRider.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}