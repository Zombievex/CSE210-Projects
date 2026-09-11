// Added a check so if the user accidently doesn't input a menu number, it asks again instead of crashing
using System;
using System.Net.Http.Headers;

class Program
{
    static void Main(string[] args)
    {
        
        Journal journal = new Journal();

        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("1: Write");
            Console.WriteLine("2: Display");
            Console.WriteLine("3: Save");
            Console.WriteLine("4: Load");
            Console.WriteLine("5: Quit");


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
                // gets/prints prompts
                string prompt = promptGenerator.get_prompt();
                Console.WriteLine($"{prompt}");

                string writing = Console.ReadLine();

                // gets current date
                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();
                
                Entry entry = new Entry();
                entry._date = dateText;
                entry._prompt = prompt;
                entry._text = writing;

                journal.add_entry(entry);

            }else if (task_chosen == 2){
                journal.Display_all();
                Console.WriteLine("");

            }else if (task_chosen == 3){
                journal.save_file();

            }else if (task_chosen == 4){
                journal.load_file();
            // close the journal
            }else if (task_chosen == 5){
                Console.WriteLine("Journal Closing");
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