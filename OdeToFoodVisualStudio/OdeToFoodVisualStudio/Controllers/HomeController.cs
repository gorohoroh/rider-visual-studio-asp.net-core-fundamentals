using Microsoft.AspNetCore.Mvc;
using OdeToFoodVisualStudio.Models;
using OdeToFoodVisualStudio.Services;
using OdeToFoodVisualStudio.ViewModels;

namespace OdeToFoodVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        // VSRD: Visual Studio doesn't have import items in completion, which means that here and in other cases when referencing an unimported type, you have to make sure to spell
        // and capitalize it correctly, and then use a quick action to add an import. In Rider, import items are available in completion, which allows using camelHumps and abbreviations
        // without being precise with naming, and additionally, accepting an import symbol suggestion adds the necessary using statement without the need to explicitly invoke a quick action.
        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            // VSRD: VS provides a set of quick actions to generate _restaurantData (as a full or read-only field, full or read-only property, local variable), as well as explicit actions
            // to change _restaurantData to IRestaurantData or restaurantData
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();

            return View(model);

        }
    }
}
