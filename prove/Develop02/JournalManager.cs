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
        journal.AddEntry(new JournalEntry(prompt, response, DateTime.Now));
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
                writer.WriteLine($"{entry.Prompt}~|~{entry.Response}~|~{entry.Date}");
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
                    if (parts.Length == 3)
                    {
                        string prompt = parts[0];
                        string response = parts[1];
                        DateTime date;
                        if (DateTime.TryParse(parts[2], out date))
                        {
                            journal.AddEntry(new JournalEntry(prompt, response, date));
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