using Microsoft.AspNetCore.Mvc;
using OdeToFoodRider.Models;

namespace OdeToFoodRider.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Restaurant() {Id = 1, Name = "Scott's Pizza Place"};
            
            return View(model);
        }
    }
}