using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers. When finished, enter 0");
        List<int> number_list = new List<int>();

        bool end = false;
        while (end == false)
        {
            Console.Write("Enter Number: ");
            string get_number = Console.ReadLine();
            int number = int.Parse(get_number);

            if (number == 0)
            {
                end = true;
            }
            else
            {
                number_list.Add(number);
            }
            
        }
    
        // total
        int total = 0;
        foreach (int number in number_list)
        {
            total += number;
        }
        Console.WriteLine($"Total: {total}");

        // average
        float avg = ((float)total) / number_list.Count;
        Console.WriteLine($"Average: {avg}");

        // highest
        int highest = number_list.Max();
        Console.WriteLine($"Highest: {highest}");
    }
}