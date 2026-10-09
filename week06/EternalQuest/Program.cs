// the goalManager saves it's filename, so the user doesn't have to add it everytime
// Asks user to save before they leave
// Added a basic leveling system
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();


        while (true)
        {
            Console.WriteLine("");
            goalManager.DisplayPlayerInfo();
            Console.WriteLine("");

            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("1: Create new goal");
            Console.WriteLine("2: List Goals");
            Console.WriteLine("3: Save Goals");
            Console.WriteLine("4: Load Goals");
            Console.WriteLine("5: Record Event");
            Console.WriteLine("6: Quit");


            Console.WriteLine("Please select one of the options above: ");
            string menu_task = Console.ReadLine();


            // Makes sure user input if a number, and not something stupid, like hamburbur
            if (!int.TryParse(menu_task, out int task_chosen))
                {
                    Console.WriteLine("Please enter a number.");
                    Console.WriteLine();
                    continue;
                }

            Console.Clear();            
            if (task_chosen == 1){
                goalManager.CreateGoal();

            }else if (task_chosen == 2){
                goalManager.ListGoalDetails();

            }else if (task_chosen == 3){
                goalManager.SaveGoals();

            }else if (task_chosen == 4){
                goalManager.LoadGoals();
            // close the journal

            }else if (task_chosen == 5){
                goalManager.RecordEvent();
            }else if (task_chosen == 6){
                goalManager.QuickSave();
                Console.WriteLine("Goal Program Closing");
                Console.WriteLine("Bye bye");
                break;
            }
            else
            {
                Console.WriteLine("Please select one of the options above");
            }
        }
    }
}