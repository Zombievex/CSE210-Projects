using System;
using System.IO; 

public class Journal
{

    // Make new list
    public List<Entry> _entries = new List<Entry>();

    // Prints to screen
    public void Display_all()
    {
        Console.WriteLine("Entries:");

        foreach (Entry get_entry in _entries)
        {
            get_entry.Display();
        }
    }


    public void add_entry(Entry _entry)
    {
        _entries.Add(_entry);
    }


    public void save_file()
    {

        Console.Write("What would you like to name your journal? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date},{entry._prompt},{entry._text}");
            }
        }
    }

    public void load_file()
    {

        Console.Write("What journal would you like to load? ");
        string filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(filename);

        Journal load_journal = new Journal();
        foreach (string line in lines)
        {
            Entry entry = new Entry();
            string[] parts = line.Split(",");

            entry._date = parts[0];
            entry._prompt = parts[1];
            entry._text = parts[2];

            _entries.Add(entry);
        }
    }

    //  public int GetStreak()
    // {
    //     List<DateTime> dates = _entries.Select(Entry => Entry._date).Distinct().OrderByDescending(_date => _date).ToList();

    //     if (dates.Count == 0)
    //     {
    //         return 0;
    //     }

    //     int streak = 1;

    //     for (int i = 1; i < dates.Count; i++)
    //     {
    //         if (dates[i] == dates[i - 1].AddDays(-1))
    //             {
    //                 streak++;
    //             }
    //             else
    //             {
    //                 break;
    //             }
    //         }

    //     return streak;
        
    // }
}