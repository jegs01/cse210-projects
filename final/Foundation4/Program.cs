using System;
using System.Collections.Generic;

public abstract class Activity
{
    private DateTime date;
    private int lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        this.date = date;
        this.lengthInMinutes = lengthInMinutes;
    }

    public DateTime GetDate() => date;
    public int GetLengthInMinutes() => lengthInMinutes;

    public abstract double GetDistance(); // in kilometers
    public abstract double GetSpeed(); // in kilometers per hour
    public abstract double GetPace(); // in minutes per kilometer

    public virtual string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} {this.GetType().Name} ({lengthInMinutes} min): Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Activity running = new Running(new DateTime(2024, 5, 25), 30, 4.8);
        Activity cycling = new Cycling(new DateTime(2024, 5, 25), 45, 25.0); 
        Activity swimming = new Swimming(new DateTime(2024, 5, 25), 60, 40); 

        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
