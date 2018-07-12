using System.Collections.Generic;
using System.Linq;
using OdeToFoodRider.Models;

namespace OdeToFoodRider.Services
{
    class InMemoryRestaurantData : IRestaurantData
    {
        // VSRD: Quick-fix "Initialize field from constructor" is available after declaring the _restaurants field.
        // However, the created constructor takes a list of restaurants as a parameter; what we need instead is a parameterless constructor
        // with a field inside that is initialized with a new list. No context action or refactoring to convert parameter to
        // field initialization, and Change Signature doesn't do that, too. No big deal to do this by hand though.
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                // VSRD: Rider's code completion after "new" results in "new Restaurant()", where parentheses become redundant once braces are added for initializing properties.
                // A typing assistant that removes redundant parentheses wouldn't hurt here.
                new Restaurant {Id = 1, Name = "Scott's Pizza Place"}, // VSRD: Rider's Complete Statement here doesn't add a comma either but instead, moves the caret beyond the scope of the collection initializer - looks like a bug
                new Restaurant() {Id = 2, Name = "Tersiguels"},
                new Restaurant() {Id = 3, Name = "King's Contrivance"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(restaurant);
            return restaurant;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            throw new System.NotImplementedException();
        }
    }
}