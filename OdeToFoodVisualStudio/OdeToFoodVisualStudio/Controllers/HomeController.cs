using Microsoft.AspNetCore.Mvc;
using OdeToFoodVisualStudio.Models;

namespace OdeToFoodVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Restaurant { Id = 1, Name = "Scott's Pizza Place" };

            return new ObjectResult(model);

            // VSRD: Visual Studio doesn't have a quick action to change return type if you try to return something that doesn't match it
            // VSRD: Visual Studio's take on Extend/Shrink Selection (Shift+Alt+Plus/Minus) can't extend to a string literal except quotes,
            // making it non-trivial to paste text into string literals - it can only extend to the whole string literal
            //return Content("Hello from Visual Studio's Home controller");


        }
    }
}
