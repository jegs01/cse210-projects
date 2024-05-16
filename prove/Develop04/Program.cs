using System;
using System.Collections.Generic;
using System.Threading;

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
                Console.WriteLine("4. Quit");
                Console.Write("Select a choice from the menu: ");
                int choice = int.Parse(Console.ReadLine());

                Activity activity = choice switch
                {
                    1 => new BreathingActivity(),
                    2 => new ReflectionActivity(),
                    3 => new ListingActivity(),
                    4 => null,
                    _ => throw new InvalidOperationException("Invalid choice")
                };

                if (activity == null) break;

                activity.Run();
            }
    }
}

abstract class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

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
}
