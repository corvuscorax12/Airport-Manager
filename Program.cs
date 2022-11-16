namespace AirportManager
{
    internal class Program
    {
        public static List<Flight> flights = new List<Flight>();

        static void Main(string[] args)
        {

            Menu menu = new MainMenu();
            string choice;
            int result;
            Console.WriteLine(menu.Print());
            Console.Write("Enter a choice 3 to quit:");
            choice = Console.ReadLine();
            while (choice != "3")
            {
                Console.Clear();
                Console.WriteLine(menu.Print());

                if (int.TryParse(choice, out result) == false)
                {
                    Console.WriteLine("Invalid");
                }
                else
                {
                    menu.Selection(result);
                }
                Console.Clear();
                Console.WriteLine(menu.Print());
                Console.Write("Enter a choice 3 to quit:");
                choice = Console.ReadLine();


            }

        }


    }
}