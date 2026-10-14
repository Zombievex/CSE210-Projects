using System;

class Program
{
    static void Main(string[] args)
    {
        Running run = new Running("Oct 18th, 2022", 65, 2.3f);
        run.GetSummary();
        Cycling cycle = new Cycling("Nov 12th, 2024", 12, 12.3f);
        cycle.GetSummary();
        Swimming swim = new Swimming("Oct 17th, 2022", 435, 986);
        swim.GetSummary();
    }
}