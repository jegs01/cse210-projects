using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

class ListingActivity : Activity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void Run()
    {
        Start();
        var random = new Random();
        Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
        ShowAnimation(5);
        Console.WriteLine();
        Console.WriteLine("Start listing items:");
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        List<string> items = new List<string>();

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }
        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items.");
        End();
    }
}