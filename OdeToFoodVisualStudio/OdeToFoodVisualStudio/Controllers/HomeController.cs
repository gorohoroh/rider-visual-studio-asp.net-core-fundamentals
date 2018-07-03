using Microsoft.AspNetCore.Mvc;
using OdeToFoodVisualStudio.Models;

namespace OdeToFoodVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Restaurant { Id = 1, Name = "Scott's Pizza Place" };

            return View(model);

        }
    }
}
