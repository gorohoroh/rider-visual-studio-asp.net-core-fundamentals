using Microsoft.AspNetCore.Mvc;
using OdeToFoodRider.Models;
using OdeToFoodRider.Services;

namespace OdeToFoodRider.Controllers
{
    public class HomeController : Controller
    {
        // VSRD: This time, "Initialize field from constructor" does exactly what we want.
        IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }


        public IActionResult Index()
        {
            var model = _restaurantData.GetAll();            
            return View(model);
        }
    }
}