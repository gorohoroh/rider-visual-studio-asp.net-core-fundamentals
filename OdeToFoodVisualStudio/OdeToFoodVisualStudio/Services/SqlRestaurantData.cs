using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFoodVisualStudio.Data;
using OdeToFoodVisualStudio.Models;

namespace OdeToFoodVisualStudio.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        // Possible performance issues if returning an IEnumerable with large data sets - IQueryable is performance-safer
        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy(r => r.Name);
        }
    }
}
