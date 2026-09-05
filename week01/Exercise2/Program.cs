using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        string get_grade = Console.ReadLine();
        int grade = int.Parse(get_grade);

        bool passed = false;
        string letter = "";
        if (grade >= 90)
        {
            letter = "A";
            passed = true;
        }
        else if (grade >= 80)
        {
            letter = "B";
            passed = true;
        }
        else if (grade >= 70)
        {
            letter = "C";
            passed = true;
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.Write($"Your grade is {letter}.");
        if (passed)
        {
            Console.Write(" You Passed!");
        }
        else
        {
            Console.Write(" You did not pass. Better luck next time.");
        }


    }
}