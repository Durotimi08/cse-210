using System;

namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int lengthInMinutes, int laps) : base(date, lengthInMinutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            double distanceInKm = _laps * 50.0 / 1000.0;
            return distanceInKm * 0.62;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / LengthInMinutes) * 60;
        }

        public override double GetPace()
        {
            return LengthInMinutes / GetDistance();
        }

        protected override string GetActivityType()
        {
            return "Swimming";
        }
    }
}