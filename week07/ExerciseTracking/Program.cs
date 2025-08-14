using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise Tracking Program");
            Console.WriteLine("========================\n");

            Running running = new Running(new DateTime(2022, 11, 3), 30, 3.0);
            Cycling cycling = new Cycling(new DateTime(2022, 11, 3), 30, 6.0);
            Swimming swimming = new Swimming(new DateTime(2022, 11, 3), 30, 20);

            List<Activity> activities = new List<Activity>
            {
                running,
                cycling,
                swimming
            };

            Console.WriteLine("Activity Summaries:");
            Console.WriteLine("==================\n");

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
                Console.WriteLine();
            }

            Console.WriteLine("Individual Calculations:");
            Console.WriteLine("======================\n");

            Console.WriteLine($"Running - Distance: {running.GetDistance():F1} miles, Speed: {running.GetSpeed():F1} mph, Pace: {running.GetPace():F1} min/mile");
            Console.WriteLine($"Cycling - Distance: {cycling.GetDistance():F1} miles, Speed: {cycling.GetSpeed():F1} mph, Pace: {cycling.GetPace():F1} min/mile");
            Console.WriteLine($"Swimming - Distance: {swimming.GetDistance():F1} miles, Speed: {swimming.GetSpeed():F1} mph, Pace: {swimming.GetPace():F1} min/mile");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}