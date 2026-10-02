public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description, int duration)
    {
      _name = name;
      _description = description;
      _duration = duration;
    }
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"{_name}!");
        Console.WriteLine($"{_description}!");
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Finished!");
    }
    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "-", "/", "|", "\\" };

        for (int i = 0; i < seconds*4; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }
    public void ShowCountdown(int seconds)
    {
        
    }
}

// a child class called Student
public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description, int duration) : base(name, description, duration)
    {
    }

    public void Run()
    {
      DisplayStartingMessage();
      Console.WriteLine("How many seconds?: ");
      string get_seconds = Console.ReadLine();
      int seconds = int.Parse(get_seconds);

      Console.Clear();

      Console.WriteLine("Getting ready");
      ShowSpinner(4);

      Random random = new Random();
      
      while (seconds > 0){

        int breath_in = random.Next(4, 9);
        breath_in = Math.Min(breath_in, seconds);
        Console.WriteLine("");
        Console.Write("Breath in...");
        while (breath_in > 0){

          Console.Write($"{breath_in}");
          Thread.Sleep(1000);
          breath_in -= 1;
          seconds -= 1;
          Console.Write("\b \b");
        }
        
        Console.WriteLine("");
        int breath_out = random.Next(4, 9);
        breath_out = Math.Min(breath_out, seconds);

        Console.Write("Breath out...");
        while (breath_out > 0){

          Console.Write($"{breath_out}");
          Thread.Sleep(1000);
          breath_out -= 1;
          seconds -= 1;
          Console.Write("\b \b");
        }
      }
      DisplayEndingMessage();
    }
}

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    public ReflectingActivity(string name, string description, int duration) : base(name, description, duration)
    {
      _prompts = new List<string>
      {
          "Think of a time you stood alone for what you believed in.",
          "Think of a time you did something difficult.",
          "Think of a time you helped another person."
      };

      
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("How many seconds?: ");
        string get_seconds = Console.ReadLine();
        int seconds = int.Parse(get_seconds);

        Console.Clear();

        DisplayPrompt();

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();

        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);

        ResetQuestions();
        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime)
        {
          DisplayQuestions();
          ShowSpinner(8);
          currentTime = DateTime.Now;
        }

        DisplayEndingMessage();
        ShowSpinner(3);
    }
    public void ResetQuestions()
    {
      _questions = new List<string>
      {
          "How did you feel when it was complete?",
          "How did you grow from the experience?",
          "What did you learn?.",
          "Do you remember the time fondly? Why or why not?"
      };
    }
    public string GetRandomPrompt()
    {
      Random random = new Random();
      return _prompts[random.Next(_prompts.Count)];
    }
    public string GetRandomQuestion()
    {
      if (_questions.Count == 0)
      {
        ResetQuestions();
      }

      Random random = new Random();

      int randomIndex = random.Next(_questions.Count);
      string question = _questions[randomIndex];

      _questions.RemoveAt(randomIndex);

      return question;
    }
    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"--{prompt}--");
    }
    public void DisplayQuestions()
    {
    string question = GetRandomQuestion();
        Console.WriteLine(question);
    }
}

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    
    public ListingActivity(string name, string description, int duration) : base(name, description, duration)
    {

      _prompts = new List<string>
      {
          "What made you feel happy today?",
          "When did you feel the spirit this month?",
          "How many numbers can you think of?"
      };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("How many seconds?: ");
        string get_seconds = Console.ReadLine();
        int seconds = int.Parse(get_seconds);

        Console.Clear();

        GetRandomPrompt();

        Console.WriteLine();
        Console.Write("Start in...");
        int start_in = 3;
        while (start_in > 0){

          Console.Write($"{start_in}");
          Thread.Sleep(1000);
          start_in -= 1;
          Console.Write("\b \b");
        }

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);

        _count = 0;
        Console.WriteLine();
        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime)
        {
          Console.Write("> ");
          string response = Console.ReadLine();

          _count += 1;
          currentTime = DateTime.Now;
        }

        Console.WriteLine($"You wrote {_count} response(s)");
        DisplayEndingMessage();
        ShowSpinner(3);
    }

    public void GetRandomPrompt()
    {
      Random random = new Random();
      Console.WriteLine(_prompts[random.Next(_prompts.Count)]);
    }
}