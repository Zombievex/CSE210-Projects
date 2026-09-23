// Added easy mode, where it shows the first letter of each word
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What Book are you reading from? ");
        string _book = Console.ReadLine();

        Console.WriteLine("What Chapter are you reading from? ");
        string get_chapter = Console.ReadLine();
        int _chapter = int.Parse(get_chapter);

        Console.WriteLine("What Verse(s) are you reading from? ");
        string get_verses = Console.ReadLine();
        string[] verses = get_verses.Split('-');

        Reference reference;

        if (verses.Length > 1)
        {
            int _verse = int.Parse(verses[0]);
            int _endVerse = int.Parse(verses[1]);
            reference = new Reference(_book, _chapter, _verse, _endVerse);
        }
        else
        {
            int _verse = int.Parse(verses[0]);
            reference = new Reference(_book, _chapter, _verse);
        }

        Console.WriteLine("Please Input verse(s) text ");
        string all_verses = Console.ReadLine();

        Scripture scripture = new Scripture(reference, all_verses);

        // Clears console and writes scripture to console
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        while (true)
        {
            Console.WriteLine("Press Enter to continue, type easy for easy mode, or type exit to leave");
            string user_input = Console.ReadLine();
            user_input = user_input.ToLower();

            if (user_input == "exit")
            {
                break;
            }else if (user_input == "easy" && !scripture.IsEasy())
            {
                scripture.EasyMode();
                Console.Clear();
                Console.WriteLine("Easy mode enabled");
                Console.WriteLine(scripture.GetDisplayText());
                continue;
            }
            
            scripture.HideRandomWords();
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden()){
                break;
            }
        }
    }
}