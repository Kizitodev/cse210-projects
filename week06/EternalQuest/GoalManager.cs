using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (choice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (choice == "3")
        {
            Console.Write("How many times does this goal need to be completed? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for completing it? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(
                name,
                description,
                points,
                target,
                bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        ListGoals();

        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());

        if (choice >= 1 && choice <= _goals.Count)
        {
            int pointsEarned = _goals[choice - 1].RecordEvent();

            if (pointsEarned > 0)
            {
                _score += pointsEarned;
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            }
            else
            {
                Console.WriteLine("This goal has already been completed.");
            }

            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Score|{_score}");

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts[0] == "Score")
            {
                _score = int.Parse(parts[1]);
            }
            else if (parts[0] == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]));

                if (bool.Parse(parts[4]))
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
            else if (parts[0] == "EternalGoal")
            {
                EternalGoal goal = new EternalGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]));

                _goals.Add(goal);
            }
            else if (parts[0] == "ChecklistGoal")
            {
                ChecklistGoal goal = new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5]));

                int completed = int.Parse(parts[6]);

                for (int i = 0; i < completed; i++)
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Your current score is: {_score}");
        Console.WriteLine($"Your current level is: {GetLevel()}");
    }
}