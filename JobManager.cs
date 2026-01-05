using System;
using System.Collections.Generic;
using System.Linq;

public class JobManager
{
    public List<JobApplication> Applications { get; set; } = new List<JobApplication>();

    public void AddJob()
    {
        var job = new JobApplication();

        Console.Write("Företag: ");
        job.CompanyName = Console.ReadLine();

        Console.Write("Tjänst: ");
        job.PositionTitle = Console.ReadLine();

        Console.Write("Önskad lön (kr): ");
        job.SalaryExpectation = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Ansökningsdatum (yyyy-mm-dd): ");
        job.ApplicationDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("yyyy-MM-dd"));

        job.Status = ApplicationStatus.Applied;
        job.ResponseDate = null;

        Applications.Add(job);
        Console.WriteLine("Ansökan tillagd!\n");
    }

    public void ShowAll()
    {
        if (!Applications.Any())
        {
            Console.WriteLine("Inga ansökningar registrerade.\n");
            return;
        }

        foreach (var app in Applications)
        {
            Console.WriteLine(app.GetSummary());
        }

        Console.WriteLine();
    }

    public void UpdateStatus()
    {
        ShowAll();

        Console.Write("Vilket företag vill du uppdatera? ");
        string name = Console.ReadLine();

        var app = Applications.FirstOrDefault(a => a.CompanyName.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (app == null)
        {
            Console.WriteLine("Ingen ansökan hittades.\n");
            return;
        }

        Console.WriteLine("Ny status: 0=Applied, 1=Interview, 2=Offer, 3=Rejected");
        if (!int.TryParse(Console.ReadLine(), out int statusIndex) ||
            statusIndex < 0 || statusIndex > 3)
        {
            Console.WriteLine("Ogiltigt val.\n");
            return;
        }

        app.Status = (ApplicationStatus)statusIndex;

        Console.Write("Har du fått svar? (j/n): ");
        var resp = Console.ReadLine();
        if (resp?.ToLower() == "j")
        {
            app.ResponseDate = DateTime.Now;
        }

        Console.WriteLine("Status uppdaterad!\n");
    }

    public void RemoveJob()
    {
        ShowAll();

        Console.Write("Vilket företag vill du ta bort? ");
        string name = Console.ReadLine();

        var app = Applications.FirstOrDefault(a => a.CompanyName.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (app == null)
        {
            Console.WriteLine("Ingen ansökan hittades.\n");
            return;
        }

        Applications.Remove(app);
        Console.WriteLine("Ansökan borttagen.\n");
    }

    public void ShowByStatus()
    {
        Console.WriteLine("Välj status: 0=Applied, 1=Interview, 2=Offer, 3=Rejected");
        if (!int.TryParse(Console.ReadLine(), out int statusIndex) ||
            statusIndex < 0 || statusIndex > 3)
        {
            Console.WriteLine("Ogiltigt val.\n");
            return;
        }

        var status = (ApplicationStatus)statusIndex;

        var filtered = Applications
            .Where(a => a.Status == status)
            .ToList();

        if (!filtered.Any())
        {
            Console.WriteLine("Inga ansökningar med den statusen.\n");
            return;
        }

        foreach (var app in filtered)
        {
            Console.WriteLine(app.GetSummary());
        }

        Console.WriteLine();
    }

    public void SortByDate()
    {
        var sorted = Applications
            .OrderBy(a => a.ApplicationDate)
            .ToList();

        if (!sorted.Any())
        {
            Console.WriteLine("Inga ansökningar att visa.\n");
            return;
        }

        foreach (var app in sorted)
        {
            Console.WriteLine(app.GetSummary());
        }

        Console.WriteLine();
    }

    public void ShowStatistics()
    //Added LINQ improvement for clearer statistics
    {
        Console.WriteLine($"Totalt antal ansökningar: {Applications.Count}");

        if (!Applications.Any())
        {
            Console.WriteLine("Ingen mer statistik tillgänglig.\n");
            return;
        }

        var byStatus = Applications
            .GroupBy(a => a.Status)
            .Select(g => new { Status = g.Key, Count = g.Count() });

        Console.WriteLine("Antal per status:");
        foreach (var item in byStatus)
        {
            Console.WriteLine($"- {item.Status}: {item.Count}");
        }

        var answered = Applications
            .Where(a => a.ResponseDate.HasValue)
            .Select(a => (a.ResponseDate.Value - a.ApplicationDate).TotalDays);

        if (answered.Any())
        {
            var avgDays = answered.Average();
            Console.WriteLine($"Genomsnittlig svarstid: {avgDays:F1} dagar");
        }
        else
        {
            Console.WriteLine("Inga svar ännu – kan inte beräkna genomsnittlig svarstid.");
        }

        Console.WriteLine();
    }
}
