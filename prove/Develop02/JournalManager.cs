using System;
using System.Collections.Generic;
using System.IO;

public class JournalManager
{
    private Journal journal;

    public JournalManager()
    {
        journal = new Journal();
    }

    public void WriteEntry(List<string> prompts)
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine();
        
        Console.Write("Location: ");
        string location = Console.ReadLine();

        Console.Write("Mood: ");
        string mood = Console.ReadLine();

        Console.Write("Weather: ");
        string weather = Console.ReadLine();

        journal.AddEntry(new JournalEntry(prompt, response, DateTime.Now, location, mood, weather));
    }

    public void DisplayJournal()
    {
        List<JournalEntry> entries = journal.GetEntries();
        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveJournal(string filename)
    {
        FileMode fileMode = File.Exists(filename) ? FileMode.Append : FileMode.Create;
        using (StreamWriter writer = new StreamWriter(filename, append: true))
        {
            foreach (var entry in journal.GetEntries())
            {
                writer.WriteLine($"{entry.Prompt}~|~{entry.Response}~|~{entry.Date}~|~{entry.Location}~|~{entry.Mood}~|~{entry.Weather}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadJournal(string filename)
    {
        if (File.Exists(filename))
        {
            journal.ClearEntries();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
                    if (parts.Length == 6)
                    {
                        string prompt = parts[0];
                        string response = parts[1];
                        DateTime date;
                        if (DateTime.TryParse(parts[2], out date))
                        {
                            string location = parts[3];
                            string mood = parts[4];
                            string weather = parts[5];
                            journal.AddEntry(new JournalEntry(prompt, response, date, location, mood, weather));
                        }
                        else
                        {
                            Console.WriteLine($"Invalid date format in line: {line}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid entry format in line: {line}");
                    }
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
