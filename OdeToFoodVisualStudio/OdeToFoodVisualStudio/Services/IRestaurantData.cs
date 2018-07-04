using OdeToFoodVisualStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodVisualStudio.Services
{
    // VSRD: "Go to Implementation" is available in Visual Studio
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
    }
}
