using OdeToFoodVisualStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodVisualStudio.ViewModels
{
    public class RestaurantEditModel
    {
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
