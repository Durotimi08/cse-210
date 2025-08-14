using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            if (!_isCompleted)
            {
                _isCompleted = true;
                return _points;
            }
            return 0;
        }

        public override string GetDisplayString()
        {
            string checkbox = _isCompleted ? "[X]" : "[ ]";
            return $"{checkbox} {_name} - {_description}";
        }

        public override string GetSaveString()
        {
            return $"SimpleGoal|{_name}|{_description}|{_points}|{_isCompleted}";
        }
    }
}