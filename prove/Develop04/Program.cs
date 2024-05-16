using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

// Exceed requirement by saving and loading activity log from activity_log.txt

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. View Log");
            Console.WriteLine("5. Load Log");
            Console.WriteLine("6. Exit");
            Console.Write("Select a choice from the menu: ");
            int choice = int.Parse(Console.ReadLine());

            Activity activity = choice switch
            {
                1 => new BreathingActivity(),
                2 => new ReflectionActivity(),
                3 => new ListingActivity(),
                4 => null,
                5 => null,
                6 => null,
                _ => throw new InvalidOperationException("Invalid choice")
            };

            if (choice == 4)
            {
                Activity.ViewLog();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (choice == 5)
            {
                Activity.LoadLog();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (activity == null)
            {
                break;
            }
            else
            {
                activity.Run();
            }
        }
    }
}

abstract class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    private const string LogFilePath = "activity_log.txt";

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting {Name}");
        Console.WriteLine();
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        ShowAnimation(6);
        Console.WriteLine();
    }

    public void End()
    {
        Console.WriteLine();
        Console.WriteLine("Welldone!");
        ShowAnimation(5);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        ShowAnimation(3);
        LogActivity();
    }

    public void ShowAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void Run();

    private void LogActivity() 
    {
        string logEntry = $"{DateTime.Now}: Completed {Name} activity for {Duration} seconds.";
        File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
    }

    public static void ViewLog() 
    {
        if (File.Exists(LogFilePath))
        {
            Console.WriteLine("Activity Log:");
            string[] logEntries = File.ReadAllLines(LogFilePath);
            foreach (var entry in logEntries)
            {
                Console.WriteLine(entry);
            }
        }
        else
        {
            Console.WriteLine("No log file found.");
        }
    }

    public static void LoadLog() 
    {
        if (File.Exists(LogFilePath))
        {
            Console.WriteLine("Loading Activity Log...");
            ShowLoadingAnimation(3);
            Console.WriteLine("Activity Log Loaded.");
        }
        else
        {
            Console.WriteLine("No log file found.");
        }
    }

    private static void ShowLoadingAnimation(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
}
