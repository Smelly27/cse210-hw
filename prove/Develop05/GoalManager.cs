using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Eternal Quest!");
            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Thanks for playing Eternal Quest!");
                    break;
                default:
                    Console.WriteLine("Please choose a number from 1 to 6.");
                    break;
            }
        }
    }

    private string GetRank()
    {
        if (_score >= 4000)
            return "Level 5 - Master";
        if (_score >= 2000)
            return "Level 4 - Guardian";
        if (_score >= 1000)
            return "Level 3 - Adventurer";
        if (_score >= 500)
            return "Level 2 - Apprentice";

        return "Level 1 - Beginner";
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your Score: {_score} XP");
        Console.WriteLine($"Journey Rank: {GetRank()}");
    }

    private void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("Types of Goals:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        if (!int.TryParse(Console.ReadLine(), out int type) || type < 1 || type > 3)
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? "";

        Console.Write("How many points is this goal worth? ");
        if (!int.TryParse(Console.ReadLine(), out int points) || points < 0)
        {
            Console.WriteLine("Please enter a valid point value.");
            return;
        }

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else
        {
            Console.Write("How many times must this goal be completed? ");
            if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
            {
                Console.WriteLine("Please enter a number greater than zero.");
                return;
            }

            Console.Write("What is the bonus for completing the goal? ");
            if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
            {
                Console.WriteLine("Please enter a valid bonus.");
                return;
            }

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal created successfully!");
    }

    private void ListGoals()
    {
        Console.WriteLine();
        Console.WriteLine("Your Current Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You haven't created any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal first!");
            return;
        }

        ListGoals();

        Console.Write("Which goal did you accomplish? ");
        if (!int.TryParse(Console.ReadLine(), out int choice) ||
            choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        string oldRank = GetRank();
        int earnedPoints = _goals[choice - 1].RecordEvent();

        if (earnedPoints == 0)
        {
            Console.WriteLine("This goal is already completed or awards no XP.");
            return;
        }

        _score += earnedPoints;

        Console.WriteLine();
        Console.WriteLine("Mission accomplished!");
        Console.WriteLine($"You earned {earnedPoints} XP.");
        Console.WriteLine($"Total XP: {_score}");

        if (GetRank() != oldRank)
        {
            Console.WriteLine();
            Console.WriteLine("LEVEL UP!");
            Console.WriteLine($"You are now {GetRank()}!");
        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter a filename to save your goals: ");
        string filename = Console.ReadLine() ?? "";

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception)
        {
            Console.WriteLine("Could not save the file. Check the filename.");
        }
    }

    private void LoadGoals()
    {
        Console.Write("Enter the filename to load your goals: ");
        string filename = Console.ReadLine() ?? "";

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0)
            {
                Console.WriteLine("The file is empty.");
                return;
            }

            int loadedScore = int.Parse(lines[0]);
            List<Goal> loadedGoals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] goalParts = lines[i].Split(':', 2);
                if (goalParts.Length != 2)
                    continue;

                string[] details = goalParts[1].Split('|');

                if (goalParts[0] == "SimpleGoal" && details.Length == 4)
                {
                    loadedGoals.Add(new SimpleGoal(
                        details[0], details[1], int.Parse(details[2]),
                        bool.Parse(details[3])));
                }
                else if (goalParts[0] == "EternalGoal" && details.Length == 3)
                {
                    loadedGoals.Add(new EternalGoal(
                        details[0], details[1], int.Parse(details[2])));
                }
                else if (goalParts[0] == "ChecklistGoal" && details.Length == 6)
                {
                    loadedGoals.Add(new ChecklistGoal(
                        details[0], details[1], int.Parse(details[2]),
                        int.Parse(details[3]), int.Parse(details[4]),
                        int.Parse(details[5])));
                }
            }

            _score = loadedScore;
            _goals = loadedGoals;

            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception)
        {
            Console.WriteLine("Could not load the file. Check its contents.");
        }
    }
}