using AirportManager;
using System.Xml.Serialization;

public static class FlightMenuHelpers
{


    public static Flight AddFlight()
    {
        Flight flight = new Flight();

        Airline(flight);
        AircraftType(flight);
        Destination(flight);
        FlightNumber(flight);
        Terminal(flight);
        Gate(flight);
        DepartTime(flight);

        //flights are on time by default but they are edited later
        flight.Status = PlaneStatus.OnTime;

        return flight;


    }


    /// <summary>
    /// Use Icao designators found here @
    /// https://en.wikipedia.org/wiki/List_of_aircraft_type_designators
    /// </summary>
    /// <param name="flight"></param>
    private static void AircraftType(Flight flight)
    {
        Console.Write("Enter Aircraft Type:");
        flight.AircraftType = Console.ReadLine().ToUpper();
    }
    /// <summary>
    /// Enter In ICAO format
    /// </summary>
    /// <param name="flight"></param>
    private static void Airline(Flight flight)
    {
        Console.Write("Enter Airline:");
        flight.Airline = Console.ReadLine().ToUpper();
    }

    /// <summary>
    /// 24hr format no colon
    /// </summary>
    /// <param name="flight"></param>
    private static void DepartTime(Flight flight)
    {
        string departTime;
        Console.Write(value: "Enter Departure Time in 24 hour format:");
        while (true)
        {
            departTime = Console.ReadLine();

            if (int.TryParse(departTime, out int result) == false)
            {
                Console.WriteLine("Enter valid format");

            }
            else
            {
                if (departTime.Length > 4)
                {
                    Console.WriteLine("Enter valid format");
                }
                else
                {
                    departTime = string.Format("{0:D4}", result);


                    string mm = departTime.Substring(2);
                    int i_mm = int.Parse(mm);
                    string hh = departTime.Substring(0, 2);
                    int i_hh = int.Parse(hh);

                    if (i_hh < 0 || i_hh > 23 && i_mm < 0 || i_mm > 59)
                    {
                        Console.WriteLine("Invalid Output");
                    }
                    else
                    {
                        flight.Time = string.Format("{0}:{1}", hh, mm);
                        break;
                    }

                }
            }
        }
    }
    /// <summary>
    /// Gate number
    /// </summary>
    /// <param name="flight"></param>
    private static void Gate(Flight flight)
    {
        Console.Write("Enter Gate:");
        string gateNum;
        bool gateLoop = true;

        while (gateLoop == true)
        {
            gateNum = Console.ReadLine();
            if (int.TryParse(gateNum, out int result) == false)
            {
                Console.Write("Enter Gate Excluding Terminal Letter:");

            }
            else
            {
                flight.Gate = string.Format("{0:D2}", result);
                break;
            }


        }
    }

    /// <summary>
    /// Single Letter Terminal
    /// </summary>
    /// <param name="flight"></param>
    private static void Terminal(Flight flight)
    {
        Console.Write("Enter Terminal:");
        flight.Terminal = Console.ReadLine().ToUpper();
    }

    /// <summary>
    /// Flight Number
    /// </summary>
    /// <param name="flight"></param>

    private static void FlightNumber(Flight flight)
    {
        Console.Write("Enter Flight#:");
        flight.FlightNumber = Console.ReadLine();
    }

    /// <summary>
    /// Icao Airport Code
    /// </summary>
    /// <param name="flight"></param>
    private static void Destination(Flight flight)
    {
        Console.Write("Enter Destination:");
        flight.Destination = Console.ReadLine().ToUpper();
    }


    public static List<Flight> GetFlights() 
    {
        var queryFlights =
            from flight in Program.flights
            select flight;
        var list = queryFlights.ToList();
        return list;
    }


    public static void EditFlights(int selection)
    {
        string str = null;
        string option;
        List<Flight> getFlights = GetFlights();
        var getFlight = getFlights[selection-1];
        str += string.Format("1.) Airline: {0}\n", getFlight.Airline);
        str += string.Format("2.) FlightNumber: {0}\n", getFlight.FlightNumber);
        str += string.Format("3.) Aircraft Type: {0}\n", getFlight.AircraftType);
        str += string.Format("4.) Destination: {0}\n", getFlight.Destination);
        str += string.Format("5.) Terminal: {0}\n", getFlight.Terminal);
        str += string.Format("6.) Gate: {0}\n", getFlight.Gate);
        str += string.Format("7.) Departure Time: {0}\n", getFlight.Time);
        Console.Write(str);
        Console.Write("Enter option -99 to quit:");
        option = Console.ReadLine();    
        while (option != "-99")
        {
            if (int.TryParse(option,out int result) == false)
            {
                Console.WriteLine("Invalid Selection");
            }
            else
            {
                switch (result)
                {
                    case 1:
                        Console.Write("Editing Airline Currently {0}:", getFlight.Airline);
                        getFlight.Airline = Console.ReadLine().ToUpper();
                        break;
                    case 2:
                        Console.Write("Editing Flight Number Currently {0}:", getFlight.FlightNumber);
                        getFlight.FlightNumber = Console.ReadLine().ToUpper();
                        break;
                    case 3:
                        Console.Write("Editing Aircraft Type Currently {0}:", getFlight.AircraftType);
                        getFlight.AircraftType = Console.ReadLine().ToUpper();
                        break;
                    case 4:
                        Console.Write("Editing Destination Currently {0}:", getFlight.Destination);
                        getFlight.Destination = Console.ReadLine().ToUpper();
                        break;
                    case 5:
                        Console.Write("Editing Terminal Currently {0}:", getFlight.Terminal);
                        getFlight.Terminal = Console.ReadLine().ToUpper();
                        break;
                    case 6:
                        Console.Write("Editing Gate Currently {0}:", getFlight.Gate);
                        string gateNum;
                        bool gateLoop = true;

                        gateNum = Console.ReadLine();

                        while (int.TryParse(gateNum,out int gate) == false)
                        {
                            Console.Write("Enter Gate Excluding Terminal Letter:");
                            gateNum = Console.ReadLine();
                        }
                        getFlight.Gate = string.Format("{0:D2}", result);
                        break;
                    case 7:
                        string departTime;
                        Console.Write("Editing Time Currenly {0}", getFlight.Time);
                        while (true)
                        {
                            departTime = Console.ReadLine();

                            if (int.TryParse(departTime, out int time) == false)
                            {
                                Console.WriteLine("Enter valid format");

                            }
                            else
                            {
                                if (departTime.Length > 4)
                                {
                                    Console.WriteLine("Enter valid format");
                                }
                                else
                                {
                                    departTime = string.Format("{0:D4}", result);


                                    string mm = departTime.Substring(2);
                                    int i_mm = int.Parse(mm);
                                    string hh = departTime.Substring(0, 2);
                                    int i_hh = int.Parse(hh);

                                    if (i_hh < 0 || i_hh > 23 && i_mm < 0 || i_mm > 59)
                                    {
                                        Console.WriteLine("Invalid Output");
                                    }
                                    else
                                    {
                                        getFlight.Time = string.Format("{0}:{1}", hh, mm);
                                        break;
                                    }

                                }
                            }
                        }

                        break;
                    default:
                        break;
                }
            }
            Console.Write("Enter option -99 to quit:");
            option = Console.ReadLine();
        }


    }


    /// <summary>
    /// Load XML Flight
    /// </summary>
    public static void LoadFlight()
    {
        XmlSerializer reader = new XmlSerializer(typeof(Flight[]));
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "AirportD8ta.xml");

        StreamReader streamReader = new StreamReader(path);
        Program.flights = new List<Flight>((Flight[])reader.Deserialize(streamReader));
        streamReader.Close();
        Console.Clear();
    }
    /// <summary>
    /// Save To Xml
    /// </summary>
    public static void SaveFlight()
    {
        System.Xml.Serialization.XmlSerializer writer =
               new XmlSerializer(typeof(Flight[]));
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "AirportD8ta.xml");
        FileStream file;
        if (File.Exists(path) == true)
        {

            File.Delete(path);
            file = File.Create(path);

        }

        else
        {
            file = File.Create(path);

        }


        writer.Serialize(file, Program.flights.ToArray());


        file.Close();
        Console.Clear();
    }
}