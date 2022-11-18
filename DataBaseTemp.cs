namespace AirportManager
{
    public class Flight
    {
        public string Airline { get; set; }
        public string Destination { get; set; }
        public string AircraftType { get; set; }
        public PlaneStatus Status { get; set; }
        public string Terminal { get; set; }
        public string Gate { get; set; }
        public string FlightNumber { get; set; }
        public string Time { get; set; }
    }
    class Passengers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Seat { get; set; }
        public string Destination { get; set; }
        public bool CheckedIn { get; set; }
        public int CheckedBags { get; set; }
    }
    public enum PlaneStatus
    {
        OnTime,
        Delayed10m,
        Delayed30m,
        Delayed,
        Cancelled
    }
}
