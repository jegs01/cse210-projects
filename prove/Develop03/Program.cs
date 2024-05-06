using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// The scripture load from scriptures.txt file

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        Random random = new Random();

        foreach (var scripture in scriptures)
        {
            Console.Clear();
            scripture.DisplayWithReference();
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine().ToLower();
            if (input == "quit")
                return;
        }

        while (scriptures.Any(scripture => !scripture.AllWordsHidden))
        {
            Console.Clear();
            Scripture randomScripture = scriptures[random.Next(scriptures.Count)];
            randomScripture.HideRandomWords();
            randomScripture.Display();
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine().ToLower();
            if (input == "quit")
                break;
        }
    }

    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                int pipeIndex = line.IndexOf('|');
                if (pipeIndex != -1)
                {
                    string reference = line.Substring(0, pipeIndex).Trim();
                    string text = line.Substring(pipeIndex + 1).Trim();
                    scriptures.Add(new Scripture(reference, text));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading scriptures from file: {ex.Message}");
        }

        return scriptures;
    }
}
