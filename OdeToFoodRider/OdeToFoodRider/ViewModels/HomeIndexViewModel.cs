using System.Collections.Generic;
using OdeToFoodRider.Models;

namespace OdeToFoodRider.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }
    }
}