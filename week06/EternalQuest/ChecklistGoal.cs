using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _bonusPoints = bonusPoints;
        }

        public int TargetCount => _targetCount;
        public int CurrentCount => _currentCount;
        public int BonusPoints => _bonusPoints;

        public override int RecordEvent()
        {
            if (!_isCompleted)
            {
                _currentCount++;

                if (_currentCount >= _targetCount)
                {
                    _isCompleted = true;
                    return _points + _bonusPoints; // Regular points + bonus
                }

                return _points; // Just regular points
            }
            return 0;
        }

        public override string GetDisplayString()
        {
            string checkbox = _isCompleted ? "[X]" : "[ ]";
            return $"{checkbox} {_name} - {_description} (Completed {_currentCount}/{_targetCount} times)";
        }

        public override string GetSaveString()
        {
            return $"ChecklistGoal|{_name}|{_description}|{_points}|{_targetCount}|{_currentCount}|{_bonusPoints}";
        }
    }
}