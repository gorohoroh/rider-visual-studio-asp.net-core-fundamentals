namespace OdeToFoodVisualStudio
{
    public interface IGreeter
    {
        string GetMessageOfTheDay();
    }

    // VSvsRider: Visual Studio does allow implementing IGreeter from usage when the Greeter class has been declared; however, Rider does have the advantage of providing the "Create derived type"
    // context action upon the IGreeter declaration.
    // Presentation: proceed in "Creating and injecting greeting service" at 1:25
    class Greeter : IGreeter
    {
        public string GetMessageOfTheDay()
        {
            return "Greetings from Visual Studio!";
        }
    }
}