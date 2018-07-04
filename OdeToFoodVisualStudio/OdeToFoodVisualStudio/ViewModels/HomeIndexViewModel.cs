using OdeToFoodVisualStudio.Models;
using System.Collections.Generic;

namespace OdeToFoodVisualStudio.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }
    }
}
