namespace OdeToFoodRider
{
    public interface IGreeter
    {
        string GetMessageOfTheDay();
    }

    class Greeter : IGreeter
    {
        public string GetMessageOfTheDay()
        {
            throw new System.NotImplementedException();
            
        }
    }
}