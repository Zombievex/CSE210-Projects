using System;

public class Video
{
    // gets list of variables
    private string _title;
    private string _author;
    private int _length;

    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public string GetDisplayText()
    {   
        int comment_count = GetCommentCount();
        string text = $"{_title}, {_author}, {_length} seconds, {comment_count} Comments";
        return text;
    }

    public void DisplayComments()
    {
        foreach (Comment get_comment in _comments)
        {
            Console.WriteLine(get_comment.DisplayComment());
        }
    }
    
    public int GetCommentCount()
    {   
        return _comments.Count();
    }

    public void AddComment(string name, string text)
    {
        Comment comment = new Comment(name, text);
        _comments.Add(comment);
    }

}