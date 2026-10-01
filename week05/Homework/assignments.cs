// a parent class called Person
public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
      _studentName = studentName;
      _topic = topic;
    }
    public void GetSummary()
    {
        Console.WriteLine($"{_studentName}: {_topic}");
    }

}

// a child class called Student
public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    // calling the parent constructor using "base"!
    public MathAssignment(string studentName, string topic, string textbook, string problems) : base(studentName, topic)
    {
      _textbookSection = textbook;
      _problems = problems;
    }

    public void GetHomeworkList()
    {
        Console.WriteLine($"{_textbookSection}: {_problems}");
    }
}

public class WritingAssignment : Assignment
{
    private string _title;

    // calling the parent constructor using "base"!
    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }

    public void GetHomeworkList()
    {
        Console.WriteLine($"{_title}");
    }
}