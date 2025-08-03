using System;
using System.Collections.Generic;
using System.Threading;

namespace Mindfulness
{
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;
        protected List<string> _usedPrompts;

        public string Name => _name;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
            _usedPrompts = new List<string>();
        }

        public virtual void Run()
        {
            DisplayStartingMessage();
            PrepareToBegin();
            RunActivity();
            DisplayEndingMessage();
        }

        protected virtual void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"╔══════════════════════════════════════════╗");
            Console.WriteLine($"║              {_name.ToUpper()}              ║");
            Console.WriteLine($"╚══════════════════════════════════════════╝");
            Console.WriteLine($"\n{_description}");
            Console.Write("\nHow long, in seconds, would you like for your session? ");

            while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
            {
                Console.Write("Please enter a valid positive number: ");
            }
        }

        protected virtual void PrepareToBegin()
        {
            Console.WriteLine("\nGet ready...");
            ShowSpinner(3);
        }

        protected virtual void DisplayEndingMessage()
        {
            Console.WriteLine("\nWell done!");
            ShowSpinner(2);
            Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
            ShowSpinner(3);
        }

        protected abstract void RunActivity();

        protected void ShowSpinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            int index = 0;

            for (int i = 0; i < seconds * 10; i++)
            {
                Console.Write($"\r{spinner[index]} ");
                Thread.Sleep(100);
                index = (index + 1) % spinner.Length;
            }
            Console.WriteLine();
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"\r{i} ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        protected string GetRandomPrompt(List<string> prompts)
        {
            // If all prompts have been used, reset the used list
            if (_usedPrompts.Count >= prompts.Count)
            {
                _usedPrompts.Clear();
            }

            // Find a prompt that hasn't been used yet
            List<string> availablePrompts = prompts.FindAll(p => !_usedPrompts.Contains(p));
            string selectedPrompt = availablePrompts[new Random().Next(availablePrompts.Count)];
            _usedPrompts.Add(selectedPrompt);

            return selectedPrompt;
        }
    }
}