namespace CarRentalApp.Models
{
    public class BookingItem
    {
        public Car Car;
        public int Days;

        public BookingItem(Car car, int days)
        {
            Car = car;
            Days = days;
        }

        public double TotalPrice()
        {
            return Days * Car.PricePerDay;
        }

        public override string ToString()
        {
            return $"{Car.Name} - {Days} Days - Rs {TotalPrice()}";
        }
    }
}
