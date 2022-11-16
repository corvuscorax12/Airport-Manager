using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AirportManager
{
    abstract class Menu
    {
        public Menu() => MenuAdd();
        protected abstract void MenuAdd();
        protected List<string> items;


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
    public struct Box
    {
        public const string HORIZONTAL = "─";
        public const string VERTICAL = "│";
        public const string UPPERRIGHT = "┌";
        public const string UPPERLEFT = "┐";
        public const string LOWERLEFT = "┘";
        public const string LOWERRIGHT = "└";


    }



    class MainMenu : Menu
    {
        protected override void MenuAdd()
        {
            items = new List<string>();
            items.Add("Add Flight Info:");
            items.Add("View Flight Schedule");
            items.Add("Check-in View");
            items.Add("Quit");
        }
        public override int Selection(int index)
        {
            switch (index)
            {
                case 1:
                    string choice;
                    int result;
                    Menu fm = new FlightMenu();
                    Console.Clear();
                    Console.WriteLine(fm.Print());
                    Console.Write("Enter a choice 3 to quit:");
                    choice = Console.ReadLine();
                    while (choice != "3")
                    {
                        if (int.TryParse(choice, out result) == false)
                        {
                            Console.WriteLine("Invalid");
                        }
                        else
                        {
                            fm.Selection(result);
                        }
                        Console.Write("Enter a choice 3 to quit:");
                        choice = Console.ReadLine();
                    }
                    Console.Clear();
                    return 0;
                case 2:
                    //view checkin
                    return 1;
                case 3:
                    return 0;
                default:
                    return 1;
            }

        }
    }


    class FlightMenu : Menu
    {
        protected override void MenuAdd()
        {
            items = new List<string>();
            items.Add("Add Flight");
            items.Add("Add Passengers To flight");
            items.Add("Quit");
        }
        static Flight addflight()
        {
            Flight flight = new Flight();
            Console.Write("Enter Airline:");
            flight.Airline = Console.ReadLine();
            Console.Write("Enter Aircraft Type:");
            flight.AircraftType = Console.ReadLine();
            Console.Write("Enter Destination:");
            flight.Destination = Console.ReadLine();
            flight.Status = PlaneStatus.OnTime;

            return flight;
        }

        public override int Selection(int index)
        {
            switch (index)
            {
                case 1:

                    Program.flights.Add(addflight());
                    return 1;
                case 2:
                    //view checkin
                    return 1;
                case 3:
                    return 0;
                default:
                    return 1;
            }

        }
    }
}

