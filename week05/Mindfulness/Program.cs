// Reflection activity doesn't repeat questions, unless it runs out, then recycles through all the questions
using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathing = new BreathingActivity(
        "Breathing activity",
        "Focus your mind by breathing in and out deeply",
        60);

        ReflectingActivity reflecting = new ReflectingActivity(
        "Reflecting activity",
        "Focus your thoughts and think about the following prompt",
        60);

        ListingActivity listing = new ListingActivity(
        "Listing activity",
        "Focus your thoughts, and think about the following prompt",
        60);


        while (true)
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1: Start Breathing Activity");
            Console.WriteLine("2: Start Reflecting Activity");
            Console.WriteLine("3: Start Listing Activity");
            Console.WriteLine("4: Quit");


            Console.WriteLine("Please select one of the options above: ");
            string menu_task = Console.ReadLine();

            // Makes sure user input if a number, and not something stupid, like hamburbur
            if (!int.TryParse(menu_task, out int task_chosen))
                {
                    Console.WriteLine("Please enter a number.");
                    Console.WriteLine();
                    continue;
                }
            
            Console.WriteLine($"You selected {task_chosen}");
            if (task_chosen == 1){
                breathing.Run();

            }else if (task_chosen == 2){
                reflecting.Run();

            }else if (task_chosen == 3){
                listing.Run();

            }else if (task_chosen == 4){
                Console.WriteLine("Bye bye");
                break;
   
            }else{
                Console.WriteLine("Please select one of the options above");
            }
        }
    }
}