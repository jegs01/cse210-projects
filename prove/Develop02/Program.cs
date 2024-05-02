using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was the highlight of today?",
        "Describe a random act of kindness you witnessed or performed.",
        "Reflect on a challenge you faced today and how you overcame it.",
        "Share a moment of gratitude from today.",
        "Write about a new skill or lesson you learned recently.",
        "Describe a place you visited today and how it made you feel.",
        "Write about something that made you laugh today.",
        "Reflect on a goal you accomplished recently and how it felt.",
        "Describe an inspiring conversation you had today.",
        "Write about a book, movie, or song that moved you recently."
    };

    static JournalManager journalManager = new JournalManager();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Journal Prompt!");
        
        int choice;
        do
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    journalManager.WriteEntry(prompts);
                    break;
                case 2:
                    journalManager.DisplayJournal();
                    break;
                case 3:
                    LoadJournal();
                    break;
                case 4:
                    SaveJournal();
                    break;
                case 5:
                    Console.WriteLine("Exiting program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 5);
    }

    static void SaveJournal()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        journalManager.SaveJournal(filename);
    }

    static void LoadJournal()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        journalManager.LoadJournal(filename);
    }
}
