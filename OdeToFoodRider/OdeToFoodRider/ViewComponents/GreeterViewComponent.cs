using Microsoft.AspNetCore.Mvc;
 using OdeToFoodRider.Services;
 
 namespace OdeToFoodRider.ViewComponents
 {
     public class GreeterViewComponent : ViewComponent
     {
         private readonly IGreeter _greeter;
 
         public GreeterViewComponent(IGreeter greeter)
         {
             _greeter = greeter;
         }
         
         public IViewComponentResult Invoke()
         {
             var model = _greeter.GetMessageOfTheDay();
             return View("Default", model);
         }
     }
 }