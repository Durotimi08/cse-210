using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private string _filename = "goals.txt";

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public int Score => _score;

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        public void RecordEvent(int goalIndex)
        {
            if (goalIndex >= 0 && goalIndex < _goals.Count)
            {
                int pointsEarned = _goals[goalIndex].RecordEvent();
                _score += pointsEarned;

                if (pointsEarned > 0)
                {
                    Console.WriteLine($"\nCongratulations! You earned {pointsEarned} points!");
                    Console.WriteLine($"Total score: {_score}");
                }
            }
        }

        public void DisplayGoals()
        {
            Console.WriteLine("\nYour Goals:");
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet. Create some goals to get started!");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"\nCurrent Score: {_score}");
        }

        public void SaveGoals()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filename))
                {
                    writer.WriteLine(_score);
                    foreach (Goal goal in _goals)
                    {
                        writer.WriteLine(goal.GetSaveString());
                    }
                }
                Console.WriteLine($"\nGoals saved successfully to {_filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError saving goals: {ex.Message}");
            }
        }

        public void LoadGoals()
        {
            try
            {
                if (File.Exists(_filename))
                {
                    string[] lines = File.ReadAllLines(_filename);
                    if (lines.Length > 0)
                    {
                        _score = int.Parse(lines[0]);
                        _goals.Clear();

                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] parts = lines[i].Split('|');
                            Goal goal = CreateGoalFromString(parts);
                            if (goal != null)
                            {
                                _goals.Add(goal);
                            }
                        }
                        Console.WriteLine($"\nGoals loaded successfully from {_filename}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError loading goals: {ex.Message}");
            }
        }

        private Goal CreateGoalFromString(string[] parts)
        {
            try
            {
                string goalType = parts[0];
                switch (goalType)
                {
                    case "SimpleGoal":
                        bool isCompleted = bool.Parse(parts[4]);
                        var simpleGoal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (isCompleted) simpleGoal.MarkComplete();
                        return simpleGoal;

                    case "EternalGoal":
                        return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));

                    case "ChecklistGoal":
                        var checklistGoal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                                           int.Parse(parts[4]), int.Parse(parts[6]));
                        // Set current count
                        var currentCount = int.Parse(parts[5]);
                        for (int i = 0; i < currentCount; i++)
                        {
                            checklistGoal.RecordEvent();
                        }
                        return checklistGoal;

                    default:
                        return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public int GetGoalCount()
        {
            return _goals.Count;
        }
    }
}