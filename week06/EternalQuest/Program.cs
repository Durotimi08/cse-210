using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Eternal Quest!");
            Console.WriteLine("Your journey of personal growth and goal achievement begins here...\n");

            GoalManager goalManager = new GoalManager();
            goalManager.LoadGoals(); // Load existing goals if any

            bool running = true;
            while (running)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewGoal(goalManager);
                        break;
                    case "2":
                        RecordGoalEvent(goalManager);
                        break;
                    case "3":
                        goalManager.DisplayGoals();
                        break;
                    case "4":
                        goalManager.DisplayScore();
                        break;
                    case "5":
                        goalManager.SaveGoals();
                        break;
                    case "6":
                        goalManager.LoadGoals();
                        break;
                    case "7":
                        running = false;
                        Console.WriteLine("\nThank you for using Eternal Quest! Keep pursuing your goals!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("=== ETERNAL QUEST ===");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Goal Event");
            Console.WriteLine("3. View All Goals");
            Console.WriteLine("4. View Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("\nChoose an option: ");
        }

        static void CreateNewGoal(GoalManager goalManager)
        {
            Console.WriteLine("\nCreate New Goal");
            Console.WriteLine("===============");

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();

            Console.WriteLine("\nGoal Types:");
            Console.WriteLine("1. Simple Goal (one-time completion)");
            Console.WriteLine("2. Eternal Goal (never-ending, repeatable)");
            Console.WriteLine("3. Checklist Goal (complete multiple times)");

            Console.Write("Choose goal type (1-3): ");
            string typeChoice = Console.ReadLine();

            Goal newGoal = null;

            switch (typeChoice)
            {
                case "1":
                    Console.Write("Enter points for completion: ");
                    if (int.TryParse(Console.ReadLine(), out int simplePoints))
                    {
                        newGoal = new SimpleGoal(name, description, simplePoints);
                    }
                    break;

                case "2":
                    Console.Write("Enter points per completion: ");
                    if (int.TryParse(Console.ReadLine(), out int eternalPoints))
                    {
                        newGoal = new EternalGoal(name, description, eternalPoints);
                    }
                    break;

                case "3":
                    Console.Write("Enter points per completion: ");
                    if (int.TryParse(Console.ReadLine(), out int checklistPoints))
                    {
                        Console.Write("Enter target completion count: ");
                        if (int.TryParse(Console.ReadLine(), out int targetCount))
                        {
                            Console.Write("Enter bonus points for final completion: ");
                            if (int.TryParse(Console.ReadLine(), out int bonusPoints))
                            {
                                newGoal = new ChecklistGoal(name, description, checklistPoints, targetCount, bonusPoints);
                            }
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Invalid goal type selected.");
                    return;
            }

            if (newGoal != null)
            {
                goalManager.AddGoal(newGoal);
                Console.WriteLine($"\nGoal '{name}' created successfully!");
            }
            else
            {
                Console.WriteLine("Failed to create goal. Please check your input.");
            }
        }

        static void RecordGoalEvent(GoalManager goalManager)
        {
            if (goalManager.GetGoalCount() == 0)
            {
                Console.WriteLine("\nNo goals available. Create some goals first!");
                return;
            }

            Console.WriteLine("\nRecord Goal Event");
            Console.WriteLine("=================");

            goalManager.DisplayGoals();
            Console.Write("\nEnter the number of the goal to record: ");

            if (int.TryParse(Console.ReadLine(), out int goalNumber))
            {
                goalManager.RecordEvent(goalNumber - 1); // Convert to 0-based index
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
    }
}
