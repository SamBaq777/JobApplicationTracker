using System;

class Program
{
    static void Main(string[] args)
    {
        var manager = new JobManager();
        bool running = true;

        while (running)
        {
            //Improved menu readability
            Console.WriteLine("=== Job Application Tracker ===");
            Console.WriteLine("1. Lägg till ny ansökan");
            Console.WriteLine("2. Visa alla ansökningar");
            Console.WriteLine("3. Filtrera ansökningar efter status");
            Console.WriteLine("4. Sortera ansökningar efter datum");
            Console.WriteLine("5. Visa statistik");
            Console.WriteLine("6. Uppdatera status på en ansökan");
            Console.WriteLine("7. Ta bort en ansökan");
            Console.WriteLine("8. Avsluta programmet");
            Console.Write("Välj ett alternativ: ");

            var input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    manager.AddJob();
                    break;
                case "2":
                    manager.ShowAll();
                    break;
                case "3":
                    manager.ShowByStatus();
                    break;
                case "4":
                    manager.SortByDate();
                    break;
                case "5":
                    manager.ShowStatistics();
                    break;
                case "6":
                    manager.UpdateStatus();
                    break;
                case "7":
                    manager.RemoveJob();
                    break;
                case "8":
                    running = false;
                    Console.WriteLine("Avslutar...");
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.\n");
                    break;
            }
        }
    }
}
