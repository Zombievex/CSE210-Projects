using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        int guess;

        bool correct = false;
        while (correct == false)
        {
            Console.Write("Can you guess my number? ");
            string get_guess = Console.ReadLine();
            guess = int.Parse(get_guess);

            if (guess == number)
            {
                correct = true;
                Console.WriteLine($"The number is {number}!");
            }
            else if (guess > number)
            {
                Console.WriteLine("The number is lower");
            }
            else if (guess < number)
            {
                Console.WriteLine("The number is higher");
            }
            else
            {
                Console.WriteLine("I don't even know how you got this error message");
            }
        }

    }
}