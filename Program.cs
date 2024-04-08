using System.Text;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace AirlineManager;

internal class Program
{
    static List<Flight> flights = new List<Flight>();
    static int lastId = 0;
    static void Main()
    {
        Console.Title = "ButAirlines";
        //Console.InputEncoding = Encoding.UTF8;
        //Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.GetEncoding("UTF-16");
        Console.OutputEncoding = Encoding.GetEncoding("UTF-16");
        LoadData();
        while (true)
        {

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\t              Інформаційна система              ");
            Console.WriteLine("\t                 АВІАКОМПАНІЯ                   ");
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ВАС ВІТАЄ АВІАКОМПАНІЯ \"ButAirlines\"!");
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\tГОЛОВНЕ МЕНЮ АВІКОМПАНІЇ \"ButAirlines\"");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("┌───────────────────┬──────────────────────────────────────────┐");
            Console.WriteLine("│        Дiї        │             Пояснення                    │");
            Console.WriteLine("├───────┬───────────┼──────────────────────────────────────────┤");
            Console.WriteLine("│   1   │  CREATE   │ ДОДАННЯ РЕЙСУ                            │");
            Console.WriteLine("├───────┼───────────┼──────────────────────────────────────────┤");
            Console.WriteLine("│   2   │  READ     │ ВІДОБРАЖЕННЯ ДОСТУПНИХ РЕЙСІВ            │");
            Console.WriteLine("├───────┼───────────┼──────────────────────────────────────────┤");
            Console.WriteLine("│   3   │  UPDATE   │ ОНОВЛЕННЯ РЕЙСІВ                         │");
            Console.WriteLine("├───────┼───────────┼──────────────────────────────────────────┤");
            Console.WriteLine("│   4   │  SEARCH   │ ПОШУК ДОСТУПНИХ РЕЙСІВ                   │");
            Console.WriteLine("├───────┼───────────┼──────────────────────────────────────────┤");
            Console.WriteLine("│   5   │  DELETE   │ СКАСУВАННЯ РЕЙСІВ                        │");
            Console.WriteLine("├───────┼───────────┼──────────────────────────────────────────┤");
            Console.WriteLine("│   6   │  SORTING  │ СОРТУВАННЯ РЕЙСІВ ЗА АЛФАВІТОМ           │");
            Console.WriteLine("├───────┼───────────┼──────────────────────────────────────────┤");
            Console.WriteLine("│   7   │  EXIT     │ ВИХІД                                    │");
            Console.WriteLine("└───────┴───────────┴──────────────────────────────────────────┘");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" ОБЕРІТЬ НОМЕР ДІЇ: ");
            Console.ForegroundColor = ConsoleColor.White;
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1": CreateFlight(); break;
                case "2": ReadAllFlights(); break;
                case "3": UpdateFlight(); break;
                case "4": SearchFlight(); break;
                case "5": DeleteFlight(); break;
                case "6": SortingFlight(); break;
                case "7": Environment.Exit(0); break;
                default: Error(); break;
            }
        }
    }
    static public void CreateFlight()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\t              Інформаційна система              ");
        Console.WriteLine("\t                 АВІАКОМПАНІЯ                   ");
        Console.WriteLine();

        Console.BackgroundColor= ConsoleColor.DarkYellow;
        Console.ForegroundColor= ConsoleColor.White;
        Console.WriteLine("\t\t ДОДАННЯ РЕЙСУ ");
        Console.BackgroundColor = ConsoleColor.Black;

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Введіть назву рейсу: ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        string? name = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Red;

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Введіть номер рейсу: ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        string? namber = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Введіть час відправлення рейсу: ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        string? departureTime = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Введіть час прибуття рейсу: ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        string? arrivalTime = Console.ReadLine();

        lastId++;
        flights.Add(new Flight {ID = lastId,Namber = namber, Name = name, DepartureTime = departureTime, ArrivalTime = arrivalTime  });

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n РЕЙС УСПІШНО ДОДАНО! ");
        Console.WriteLine("\nДля повернення на головне меню натисніть \nбудь-яку клавішу...");
        Console.ReadKey();
        Console.Clear();

    }

    static public void ReadAllFlights()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\t              Інформаційна система              ");
        Console.WriteLine("\t                 АВІАКОМПАНІЯ                   ");
        Console.WriteLine();

        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\t\t ДОСТУПНІ РЕЙСИ ");
        Console.BackgroundColor = ConsoleColor.Black;

        if (flights.Count == 0) Console.WriteLine("\n ВИБАЧАЙТЕ, ВІЛЬНИХ РЕЙСІВ НЕМАЄ =(");
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(" \n ПЕРЕЛІК ДОСТУПНИХ РЕЙСІВ: \n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var flight in flights)
            {
                Console.WriteLine($"{flight.ID}) Номер рейсу \"{flight.Namber}\" | Назва рейсу \"{flight.Name}\" \n Час відправлення: {flight.DepartureTime} \n Час прибуття: {flight.ArrivalTime}\n");
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nДля повернення на головне меню натисніть \nбудь-яку клавішу...");
        Console.ReadKey();
        SaveData();
        Console.Clear();
    }
    static public void UpdateFlight()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\t              Інформаційна система              ");
        Console.WriteLine("\t                 АВІАКОМПАНІЯ                   ");
        Console.WriteLine();

        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\t\t ОНОВЛЕННЯ РЕЙСУ ");
        Console.BackgroundColor = ConsoleColor.Black;

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Введіть ID-рейсу для оновлення: ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        int id = Convert.ToInt32(Console.ReadLine());
        Flight flightsToUpdate = flights.Find(x => x.ID == id);
        if (flightsToUpdate == null) Console.WriteLine("\n РЕЙС НЕ ЗНАЙДЕНО!");
        else
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Введіть оновлену назву рейсу: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            flightsToUpdate.Name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Введіть оновлений номер рейсу: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            flightsToUpdate.Namber = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Введіть оновлений час відправлення рейсу: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            flightsToUpdate.DepartureTime = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Введіть оновлений час прибуття рейсу: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            flightsToUpdate.ArrivalTime = Console.ReadLine();
            SaveData();
        }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n РЕЙС УСПІШНО ОНОВЛЕНО! ");
            Console.WriteLine("\nДля повернення на головне меню натисніть \nбудь-яку клавішу...");
            Console.ReadKey();
            Console.Clear();
    }
    static public void SearchFlight()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\t              Інформаційна система              ");
        Console.WriteLine("\t                 АВІАКОМПАНІЯ                   ");
        Console.WriteLine();

        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\t\t ПОШУК ДОСТУПНОГО РЕЙСУ ");
        Console.BackgroundColor = ConsoleColor.Black;

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("\n Введіть номер рейсу: ");
        Console.ForegroundColor = ConsoleColor.White;
        string? namber = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(namber))
        {
            bool result = false;
            foreach (var flight in flights)
            {
                if (flight.Namber != null && flight.Namber.Contains(namber, StringComparison.OrdinalIgnoreCase))
                {
                    if (!result)
                    { 
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nРезультати пошуку:");
                        result = true;
                    }
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{flight.ID}) Номер рейсу \"{flight.Namber}\" | Назва рейсу \"{flight.Name}\" \n Час відправлення: {flight.DepartureTime} \n Час прибуття: {flight.ArrivalTime}\n");
                }
            }
        }
        else
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nВВЕДЕНО ПОРОЖНІЙ ЗАПИТ!");
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nДля повернення на головне меню натисніть \nбудь-яку клавішу...");
        Console.ReadKey();
        Console.Clear();
    }
    static public void DeleteFlight()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\t              Інформаційна система              ");
        Console.WriteLine("\t                 АВІАКОМПАНІЯ                   ");
        Console.WriteLine();

        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\t\t СКАСУВАННЯ РЕЙСУ ");
        Console.BackgroundColor = ConsoleColor.Black;

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("\n Введіть ID-рейсу для скасування: ");
        Console.ForegroundColor = ConsoleColor.White;
        int id = Convert.ToInt32(Console.ReadLine());
        Flight flightsToDelete = flights.Find(x => x.ID == id);
        Console.ForegroundColor = ConsoleColor.Red;
        if (flightsToDelete == null) Console.WriteLine("\n РЕЙС НЕ ЗНАЙДЕНО!");
        else
        {
            flights.Remove(flightsToDelete);
            UpdateIDs();
            SaveData();
            Console.WriteLine("\n РЕЙС УСПІШНО СКАСОВАНО!");
            Thread.Sleep(1000);
            Console.Clear();

        }
    }

    static public void SortingFlight()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\t              Інформаційна система              ");
        Console.WriteLine("\t                 АВІАКОМПАНІЯ                   ");
        Console.WriteLine();

        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\t\t СОРТУВАННЯ ДОСТУПНИХ РЕЙСІВ!");
        Console.BackgroundColor = ConsoleColor.Black;


        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n Очікуйте, виконується сортування рейсів за алфавітом...");
        Thread.Sleep(2000);
        Console.WriteLine("\n Сортування успішно виконано!");
        Thread.Sleep(2000);
        Console.Clear();

        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\t              Інформаційна система              ");
        Console.WriteLine("\t                 АВІАКОМПАНІЯ                   ");
        Console.WriteLine();

        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\t\t СОРТУВАННЯ ДОСТУПНИХ РЕЙСІВ!");
        Console.BackgroundColor = ConsoleColor.Black;

        var sortedFlights = flights.OrderBy(flight => flight.Name);
        UpdateIDs();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        foreach (var flight in sortedFlights)
        {
            Console.WriteLine($" ──> Номер рейсу \"{flight.Namber}\" | Назва рейсу \"{flight.Name}\" \n Час відправлення: {flight.DepartureTime} \n Час прибуття: {flight.ArrivalTime}\n");
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nДля повернення на головне меню натисніть \nбудь-яку клавішу...");
        Console.ReadKey();
        SaveData();
        Console.Clear();
    }

    static public void LoadData()
    {
        if (File.Exists("data.json"))
        {
            string json = File.ReadAllText("data.json");
            if (json != null)
            {
                flights = JsonSerializer.Deserialize<List<Flight>>(json);
            }
        }
        foreach (var flight in flights)
        {
            if (flight.ID > lastId)
            {
                lastId = flight.ID;
            }
        }
    }
    static public void SaveData()
    {
        string json = JsonSerializer.Serialize(flights);
        File.WriteAllText("data.json", json);
    }
    static public void UpdateIDs()
    {
        int newId = 1;
        foreach (var flight in flights)
        {
            flight.ID = newId;
            newId++;
        }
        lastId = newId - 1;
    }
    static public void Error()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n Неправильний вибір. Спробуйте ще раз...");
        Thread.Sleep(1700);
        Console.Clear();
    }
}
class Flight
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Namber { get; set; }
    public string? DepartureTime { get; set; }
    public string? ArrivalTime { get; set; }
    
}