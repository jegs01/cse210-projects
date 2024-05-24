using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Exceed requirement by saving data as Json

abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public abstract bool IsComplete();
    public abstract void RecordEvent();
    public abstract string GetStatus();
}

class Program
{
    private static int points = 0;
    private static List<Goal> goals = new List<Goal>();

    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"You have {points} points");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create a New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public static void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }

    private static void CreateNewGoal()
    {
        Console.Clear();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create: ");
        string choice = Console.ReadLine();

        Console.Write("Enter the goal name and describe it: ");
        string name = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter the points for this goal: ");
                int simplePoints = int.Parse(Console.ReadLine());
                goals.Add(new SimpleGoal(name, simplePoints));
                break;
            case "2":
                Console.Write("Enter the points for each occurrence: ");
                int eternalPoints = int.Parse(Console.ReadLine());
                goals.Add(new EternalGoal(name, eternalPoints));
                break;
            case "3":
                Console.Write("Enter the points for each occurrence: ");
                int checklistPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter the number of times needed to complete: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus points upon completion: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, checklistPoints, targetCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private static void ListGoals()
    {
        Console.Clear();
        Console.WriteLine("Your goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.GetStatus()} {goal.Name}");
        }
        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    private static void SaveGoals()
    {
        Console.Write("Enter the filename to save goals: ");
        string filename = Console.ReadLine();
        var saveData = new SaveData
        {
            Points = points,
            Goals = new List<GoalData>()
        };

        foreach (var goal in goals)
        {
            if (goal is SimpleGoal simpleGoal)
            {
                saveData.Goals.Add(new GoalData
                {
                    Type = "SimpleGoal",
                    Name = simpleGoal.Name,
                    Points = simpleGoal.Points,
                    Completed = simpleGoal.GetCompletedStatus()
                });
            }
            else if (goal is EternalGoal eternalGoal)
            {
                saveData.Goals.Add(new GoalData
                {
                    Type = "EternalGoal",
                    Name = eternalGoal.Name,
                    Points = eternalGoal.Points
                });
            }
            else if (goal is ChecklistGoal checklistGoal)
            {
                saveData.Goals.Add(new GoalData
                {
                    Type = "ChecklistGoal",
                    Name = checklistGoal.Name,
                    Points = checklistGoal.Points,
                    CurrentCount = checklistGoal.GetCurrentCount(),
                    TargetCount = checklistGoal.GetTargetCount(),
                    BonusPoints = checklistGoal.GetBonusPoints()
                });
            }
        }

        string json = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);

        Console.WriteLine("Goals saved.");
        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    private static void LoadGoals()
    {
        Console.Write("Enter the filename to load goals: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            var saveData = JsonSerializer.Deserialize<SaveData>(json);

            points = 0; 
            goals = new List<Goal>();

            foreach (var goalData in saveData.Goals)
            {
                switch (goalData.Type)
                {
                    case "SimpleGoal":
                        var simpleGoal = new SimpleGoal(goalData.Name, goalData.Points);
                        if (goalData.Completed)
                        {
                            simpleGoal.RecordEvent(); 
                        }
                        goals.Add(simpleGoal);
                        break;
                    case "EternalGoal":
                        goals.Add(new EternalGoal(goalData.Name, goalData.Points));
                        break;
                    case "ChecklistGoal":
                        var checklistGoal = new ChecklistGoal(goalData.Name, goalData.Points, goalData.TargetCount, goalData.BonusPoints);
                        for (int i = 0; i < goalData.CurrentCount; i++)
                        {
                            checklistGoal.RecordEvent();
                        }
                        goals.Add(checklistGoal);
                        break;
                }
            }

            points = saveData.Points;
        }
        else
        {
            Console.WriteLine("File not found.");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }
    }

    private static void RecordEvent()
    {
        Console.Clear();
        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }
        int choice = int.Parse(Console.ReadLine());

        if (choice >= 1 && choice <= goals.Count)
        {
            goals[choice - 1].RecordEvent();
            Console.WriteLine("Event recorded. Congrstulations, you have earned a new point");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }
}
