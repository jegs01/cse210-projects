using System;
using System.Collections.Generic;
using System.IO;

public class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Mood { get; set; }
    public string Weather { get; set; }

    public JournalEntry(string prompt, string response, DateTime date, string location, string mood, string weather)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Location = location;
        Mood = mood;
        Weather = weather;
    }

    public override string ToString()
    {
        return $"{Date.ToShortDateString()} - {Prompt}: {Response}\nLocation: {Location}\nMood: {Mood}\nWeather: {Weather}";
    }
}