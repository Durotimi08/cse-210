using System;

/*
 * W05 Project: Mindfulness Program
 *
 * This program provides three different mindfulness activities to help users
 * relax, reflect, and practice mindfulness in their daily lives.
 *
 * Features that exceed requirements:
 * 1. Activity logging: tracks how many times each activity has been performed
 * 2. Session based prompt rotation: ensures all prompts are used before repeating
 * 3. Enhanced breathing animation: visual breathing guide with expanding/shrinking text
 * 4. Activity statistics display: shows user their activity history
 * 5. Graceful exit option: allows users to quit the program cleanly
 */

namespace Mindfulness
{
    class Program
    {
        static void Main(string[] args)
        {
            MindfulnessApp app = new MindfulnessApp();
            app.Run();
        }
    }
}