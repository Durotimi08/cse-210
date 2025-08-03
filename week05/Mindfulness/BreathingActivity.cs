using System;
using System.Threading;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        protected override void RunActivity()
        {
            int breathCount = 0;
            int totalTime = 0;
            bool breathingIn = true;

            while (totalTime < _duration)
            {
                if (breathingIn)
                {
                    Console.WriteLine("\nBreathe in...");
                    ShowBreathingAnimation(4, true);
                    totalTime += 4;
                    breathingIn = false;
                }
                else
                {
                    Console.WriteLine("\nBreathe out...");
                    ShowBreathingAnimation(6, false);
                    totalTime += 6;
                    breathingIn = true;
                    breathCount++;
                }
            }
        }

        private void ShowBreathingAnimation(int seconds, bool breathingIn)
        {
            string breathText = breathingIn ? "Breathe in..." : "Breathe out...";

            for (int i = 0; i < seconds; i++)
            {
                int size = breathingIn ? (i + 1) * 2 : (seconds - i) * 2;
                string spaces = new string(' ', size);
                Console.Write($"\r{spaces}{breathText}{spaces}");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }
}