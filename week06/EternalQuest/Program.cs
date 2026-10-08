using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Eternal Quest");
            Console.WriteLine();
            Console.WriteLine($"Score: {goalManager.GetScore()}");
            Console.WriteLine($"Level: {goalManager.GetLevel()}");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            Console.WriteLine();

            if (choice == "1")
            {
                goalManager.CreateGoal();
            }
            else if (choice == "2")
            {
                goalManager.ListGoals();
            }
            else if (choice == "3")
            {
                goalManager.SaveGoals();
            }
            else if (choice == "4")
            {
                goalManager.LoadGoals();
            }
            else if (choice == "5")
            {
                goalManager.RecordEvent();
            }
            else if (choice == "6")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}

/*
Creativity:
I added a level system to the Eternal Quest program.
The user's level increases based on their score, giving them
an additional reward and motivation as they complete goals.
*/