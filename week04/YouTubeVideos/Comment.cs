using System;

public class Comment
{
    // gets list of variables
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }
   
   public string DisplayComment()
    {   
        string text = $"{_name}: {_text}";
        return text;
    }
}