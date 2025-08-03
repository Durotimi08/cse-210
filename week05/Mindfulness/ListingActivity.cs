using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        protected override void RunActivity()
        {
            string prompt = GetRandomPrompt(_prompts);
            Console.WriteLine($"\n{prompt}");
            Console.WriteLine("\nYou will have several seconds to think about the prompt.");
            ShowCountdown(5);

            Console.WriteLine("\nNow list as many items as you can:");
            List<string> items = new List<string>();
            DateTime startTime = DateTime.Now;

            while ((DateTime.Now - startTime).TotalSeconds < _duration)
            {
                Console.Write("> ");
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                }
            }

            Console.WriteLine($"\nYou listed {items.Count} items!");
        }
    }
}