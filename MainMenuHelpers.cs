using AirportManager;

internal static class MainMenuHelpers
{
    /// <summary>
    /// Prints Flight Schedule
    /// </summary>
    public static void FlightSchedule()
    {
        var queryFlights =
                from flight in Program.flights
                select flight;
        var listFlights = queryFlights.ToList();
        Console.Clear();
        Console.Write("DepartingTo");
        Console.Write("\tAirline");
        Console.Write("\tFlight#");
        Console.Write("\tGate");
        Console.Write("\tTime\n");
        foreach (var item in listFlights)
        {
            Console.Write("{0}", item.Destination);
            Console.Write("\t\t{0}", item.Airline);
            Console.Write("\t{0}", item.FlightNumber);
            Console.Write("\t{0}{1}", item.Terminal, item.Gate);
            Console.Write("\t{0:T}\n", item.Time);
        }
        Console.ReadKey();
        Console.Clear();
    }

    public static void FlightInfo()
        {
            string choice;
            int result;
            Menu fm = new FlightMenu();
            Console.Clear();
            Console.WriteLine(fm.Print());
            Console.Write("Enter a choice 7 to quit:");
            choice = Console.ReadLine();
            while (choice != "7")
            {
                if (int.TryParse(choice, out result) == false)
                {
                    Console.WriteLine("Invalid");
                    Console.Clear();
                }
                else
                {
                    fm.Selection(result);
                }
                Console.WriteLine(fm.Print());
                Console.Write("Enter a choice 7 to quit:");
                choice = Console.ReadLine();
            }
            Console.Clear();
        }
}