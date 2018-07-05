using System.ComponentModel.DataAnnotations;
using OdeToFoodRider.Models;

namespace OdeToFoodRider.ViewModels
{
    public class RestaurantEditModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}