using OdeToFoodVisualStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodVisualStudio.Services
{
    public class InMemoryRestaurantData : IRestaurantData // VSRD: GetAll() implementation generated with Visual Studio's "Implement interface" quick action
    {
        // VSRD: Scott creates this constructor with the ctor code snippet - that's the only option with VS as there's no context action to initialize a field from constructor.
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza Place"},
                new Restaurant {Id = 2, Name = "Tersiguels"}, // VSRD: Visual Studio's Shift+Enter doens't add a comma after an object initializer
                new Restaurant {Id = 3, Name = "King's Contrivance"}

            };
            // VSRD: in Scott's video, when creating the collection initializer (_restaurants = new List<Restaurant> {<Enter here>}), Visual Studio adds the closing semicolon, 
            // but my VS fails to do so.
        }

        List<Restaurant> _restaurants;

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }
    }
}
