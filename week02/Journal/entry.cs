using System;

public class Entry
{
    // gets list of variables
    public string _date;
    public string _prompt;
    public string _text;

    public void Display(){
        Console.WriteLine($"{_date} - Prompt: ({_prompt})");
        Console.WriteLine($"{_text}");
    }
}