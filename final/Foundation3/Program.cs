using System;
using System.Collections.Generic;
public abstract class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetTitle() => title;
    public string GetDescription() => description;
    public DateTime GetDate() => date;
    public TimeSpan GetTime() => time;
    public Address GetAddress() => address;

    public string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address.GetFullAddress()}";
    }

    public abstract string GetFullDetails();
    public abstract string GetShortDescription();
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Lagos Street", "Lagos", "Lagos State", "Nigeria");
        Address address2 = new Address("456 Abuja Road", "Abuja", "FCT", "Nigeria");
        Address address3 = new Address("789 Port Harcourt Avenue", "Port Harcourt", "Rivers State", "Nigeria");

        Lecture lecture = new Lecture("Tech Innovation Summit", "An insightful tech lecture on innovation", new DateTime(2024, 5, 28), new TimeSpan(14, 0, 0), address1, "Dr. Okafor", 100);
        Reception reception = new Reception("Corporate Networking Event", "Annual corporate networking gala", new DateTime(2024, 5, 29), new TimeSpan(18, 30, 0), address2, "rsvp@corporate.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Beach Festival", "Fun outdoor activities at the beach", new DateTime(2024, 5, 30), new TimeSpan(10, 0, 0), address3, "Sunny with a light breeze");

        List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

        foreach (var eventItem in events)
        {
            Console.WriteLine(eventItem.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(eventItem.GetShortDescription());
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
