namespace AirportManager
{
    /// <summary>
    /// Menu abstract class
    /// </summary>
    abstract class Menu
    {
        public Menu() => MenuAdd();
        protected abstract void MenuAdd();
        protected List<string> items;
        
        /// <summary>
        /// Interprets the users selection
        /// </summary>
        /// <param name="index"></param>
        /// <returns> </returns>
        public abstract int Selection(int index);
        public string Print()
        {
            string? str = null;
            int i = 1;
            foreach (var item in items)
            {

                str += string.Format("{0}.) {1}\n", i, item);
                i++;
            }
            return str;
        }

    }
    /// <summary>
    /// not used
    /// </summary>
    public struct Box
    {
        public const string HORIZONTAL = "─";
        public const string VERTICAL = "│";
        public const string UPPERRIGHT = "┌";
        public const string UPPERLEFT = "┐";
        public const string LOWERLEFT = "┘";
        public const string LOWERRIGHT = "└";


    }


    /// <summary>
    /// Main Menu to access data
    /// </summary>
    class MainMenu : Menu
    {

        public MainMenu()
        {

            string choice;
            int result;


            Console.WriteLine(this.Print());
            Console.Write("Enter a choice 99 to quit:");
            choice = Console.ReadLine();


            while (choice != "4")
            {
                Console.Clear();
                Console.WriteLine(this.Print());

                if (int.TryParse(choice, out result) == false)
                {
                    Console.WriteLine("Invalid");
                }
                else
                {
                    this.Selection(result);
                }

                Console.Clear();
                Console.WriteLine(this.Print());
                Console.Write("Enter a choice 99 to quit:");
                choice = Console.ReadLine();


            }
        }
        protected override void MenuAdd()
        {
            items = new List<string>();
            items.Add("Add Flight Info:");
            items.Add("View Flight Schedule");
            items.Add("Passenger Info");
            items.Add("Quit");
        }
        public override int Selection(int index)
        {
            switch (index)
            {
                case 1:
                    MainMenuHelpers.FlightInfo();
                    return 0;
                case 2:
                    MainMenuHelpers.FlightSchedule();
                    Console.Clear();
                    return 1;
                case 3:
                    return 0;
                default:
                    return 1;
            }
        }
    }
    class FlightSelector : Menu
    {
        protected override void MenuAdd()
        {

            items = new List<string>();
            foreach (var item in FlightMenuHelpers.GetFlights())
            {
                items.Add(string.Format("{0}/{1}", item.Airline, item.FlightNumber));
            }
        }
        public override int Selection(int index)
        {
            return 0;
        }
    }
    class FlightMenu : Menu
    {
        protected override void MenuAdd()
        {
            items = new List<string>();
            items.Add("Add Flight");
            items.Add("Add Passengers to Flight");
            items.Add("Save Flights");
            items.Add("Load Flights");
            items.Add("Edit Flight");
            items.Add("Delete Flight");
            items.Add("Quit");
        }

        public override int Selection(int index)
        {
            switch (index)
            {
                case 1:
                    Program.flights.Add(FlightMenuHelpers.AddFlight());
                    Console.Clear();

                    return 1;
                case 2:
                    return 1;
                case 3:
                    FlightMenuHelpers.SaveFlight();
                    Console.Clear();
                    return 0;
                case 4:
                    FlightMenuHelpers.LoadFlight();
                    return 0;
                case 5:
                    Menu fs = new FlightSelector();
                    Console.Clear();
                    Console.WriteLine(fs.Print());
                    
                    string selFlight;
                    Console.Write("Select flight to edit on list:");
                    selFlight = Console.ReadLine();

                    while (selFlight != "-99")
                    {
                        if (int.TryParse(selFlight, out int result) == false)
                        {
                            Console.WriteLine("Invalid Flight");
                        }
                        else
                        {
                            FlightMenuHelpers.EditFlights(result);

                        }
                        Console.Write("Select flight to edit on list:");
                        selFlight = Console.ReadLine(); 

                    }


                    Console.Clear();                   
                    return 0;
                default:
                    Console.Clear();
                    return 1;
            }
        }
    }
}

