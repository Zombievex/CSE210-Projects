using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment math = new MathAssignment(
            "Jimmy", "Math", "Math for dummides", "27-923"
        );

        math.GetSummary();
        math.GetHomeworkList();
    }
}