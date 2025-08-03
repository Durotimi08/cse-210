using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class MindfulnessApp
    {
        private List<Activity> _activities;
        private Dictionary<string, int> _activityLog;

        public MindfulnessApp()
        {
            _activities = new List<Activity>
            {
                new BreathingActivity(),
                new ReflectionActivity(),
                new ListingActivity()
            };

            _activityLog = new Dictionary<string, int>
            {
                {"Breathing", 0},
                {"Reflection", 0},
                {"Listing", 0}
            };
        }

        public void Run()
        {
            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                if (choice == "4")
                {
                    DisplayStatistics();
                    continue;
                }
                else if (choice == "5")
                {
                    Console.WriteLine("\nThank you for using the Mindfulness Program. Take care!");
                    break;
                }

                if (!int.TryParse(choice, out int activityIndex) || activityIndex < 1 || activityIndex > _activities.Count)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                activityIndex--; // Convert to 0-based index
                _activities[activityIndex].Run();
                _activityLog[_activities[activityIndex].Name]++;
            }
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║           MINDFULNESS PROGRAM            ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Breathing Activity                    ║");
            Console.WriteLine("║ 2. Reflection Activity                   ║");
            Console.WriteLine("║ 3. Listing Activity                      ║");
            Console.WriteLine("║ 4. View Statistics                       ║");
            Console.WriteLine("║ 5. Quit                                  ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("\nSelect an activity (1-5): ");
        }

        private void DisplayStatistics()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║              ACTIVITY STATISTICS         ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");

            foreach (var entry in _activityLog)
            {
                Console.WriteLine($"║ {entry.Key,-20} | {entry.Value,8} times    ║");
            }

            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}