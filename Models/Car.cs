namespace CarRentalApp.Models
{
    public class Car
    {
        public string Name;
        public string Category;
        public double PricePerDay;
        public int Available;

        public Car(string name, string category, double pricePerDay, int available)
        {
            Name = name;
            Category = category;
            PricePerDay = pricePerDay;
            Available = available;
        }
    }
}
