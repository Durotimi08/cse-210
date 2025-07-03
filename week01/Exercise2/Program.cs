using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);

        string letter = "";
        string sign = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int lastDigit = grade % 10;

        // Determine sign, with exceptions for A+ and F+/F-
        if (letter != "F")
        {
            if (lastDigit >= 7 && letter != "A")
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        // Special case: A- is allowed for 90-99 with lastDigit < 3, but not for 100
        if (letter == "A")
        {
            if (grade >= 90 && grade < 100 && lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
        }
        // No sign for F
        if (letter == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't give up! Better luck next time.");
        }
    }
}