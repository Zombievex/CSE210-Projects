using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("red", 12.34);

        Console.WriteLine(square.GetArea());
    }
}