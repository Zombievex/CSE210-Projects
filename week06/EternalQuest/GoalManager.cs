using System.Diagnostics;
using System.Drawing;
using System.Reflection.Emit;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    private string _fileName;

    public GoalManager()
    {

    }
    public void Start()
    {

    }
    
    public void DisplayPlayerInfo()
    {
        Console.WriteLine("");
        Console.WriteLine($"Total Points: {_score}");
        int level = (_score / 500) + 1;
        Console.WriteLine($"Level: {level}");
        int nextLevel = 500 - (_score%500);

        Console.WriteLine($"Points to next level: {nextLevel}");
        Console.WriteLine("");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Choose a goal to record: ");

        int goal_number = 0;
        foreach (Goal goal in _goals)
        {
            goal_number += 1;
            Console.WriteLine($"{goal_number}. {goal.GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Your goals are: ");
        foreach (Goal goal in _goals)
        {
                
            Console.WriteLine(goal.GetDetailsString());
                 
        }
    }

    public void CreateGoal()
    {
        while (true)
        {
            
    
            Console.WriteLine("What kind of goal would you like to create?");
            Console.WriteLine("1: Simple Goal");
            Console.WriteLine("2: Eternal Goal");
            Console.WriteLine("3: Checklist Goal");

            string menu_task = Console.ReadLine();

            if (!int.TryParse(menu_task, out int task_chosen))
                {
                    Console.WriteLine("Please enter a number.");
                    Console.WriteLine();
                    continue;
                }
            
            Console.WriteLine($"You selected {task_chosen}");
            if (task_chosen == 1){
                Console.WriteLine("Name of goal: ");
                string name = Console.ReadLine();

                Console.WriteLine("Goal description: ");
                string description = Console.ReadLine();

                Console.WriteLine("Points for completion (int): ");
                string points = Console.ReadLine();

                SimpleGoal goal = new SimpleGoal(name, description, int.Parse(points));
                _goals.Add(goal);

            }else if (task_chosen == 2){
                Console.WriteLine("Name of goal: ");
                string name = Console.ReadLine();

                Console.WriteLine("Goal description: ");
                string description = Console.ReadLine();

                Console.WriteLine("Points per completion (int): ");
                string points = Console.ReadLine();

                EternalGoal goal = new EternalGoal(name, description, int.Parse(points));
                _goals.Add(goal);

            }else if (task_chosen == 3){
                Console.WriteLine("Name of goal: ");
                string name = Console.ReadLine();

                Console.WriteLine("Goal description: ");
                string description = Console.ReadLine();

                Console.WriteLine("Points per completion (int): ");
                string points = Console.ReadLine();

                Console.WriteLine("Target towards bonus goal (int): ");
                string target_goal = Console.ReadLine();

                Console.WriteLine("Bonus points for final completion: ");
                string bonus = Console.ReadLine();

                ChecklistGoal goal = new ChecklistGoal(name, description, int.Parse(points), int.Parse(target_goal), int.Parse(bonus));
                _goals.Add(goal);
            }
            else
            {
                Console.WriteLine($"Choose a number next time");
            }
            break;
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();

        string get_record = Console.ReadLine();
        int record = int.Parse(get_record);

        if (record <= _goals.Count)
        {
            if (!_goals[record-1].IsComplete())
            {
                int points_gained = _goals[record-1].RecordEvent();
                _score += points_gained;
                Console.WriteLine($"You earned {points_gained} points!");
            }
            else
            {
                Console.WriteLine("Good Job! But you already completed this goal. Try to stretch yourself!");
            }
        }else{Console.WriteLine("Unfortunately that's not a goal");}
    }

    public void SaveGoals()
    {
        string filename;
        if (_fileName != null)
        {
            Console.WriteLine("Quick Save? y=yes: ");
            string quicksave = Console.ReadLine();

            if(quicksave.ToLower() == "y")
            {
                filename = _fileName;
            }else
            {
                Console.Write("What would you like to name your file for your goals? ");
                filename = Console.ReadLine();
            }
        }else{
            Console.Write("What would you like to name your file for your goals? ");
            filename = Console.ReadLine();
            _fileName = filename;
        }

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
                 
            }
        }
    }

    public void QuickSave()
    {
        Console.WriteLine("Save before you leave? y=yes: ");
        string save = Console.ReadLine();

        if(save.ToLower() == "y")
        {
            if (_fileName != null)
            {

                using (StreamWriter outputFile = new StreamWriter(_fileName))
                {
                    outputFile.WriteLine(_score);
                    foreach (Goal goal in _goals)
                    {
                        outputFile.WriteLine(goal.GetStringRepresentation());
                        
                    }
                }
            }
            else
            {
                Console.Write("What would you like to name your file for your goals? ");
                string filename = Console.ReadLine();
                _fileName = filename;

                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    outputFile.WriteLine(_score);
                    foreach (Goal goal in _goals)
                    {
                        outputFile.WriteLine(goal.GetStringRepresentation());
                        
                    }
                }
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What goal file would you like to load? ");
        string filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(filename);

        GoalManager goalManager = new GoalManager();
        
        string firstLine = lines[0];
        _score = int.Parse(firstLine);

        foreach (string line in lines.Skip(1))
        {
            // Entry entry = new Entry();
            string[] parts = line.Split(",");

            if (parts[0] == "Simple")
            {
                SimpleGoal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                if (bool.Parse(parts[4])){
                    goal.RecordEvent();
                }
                _goals.Add(goal);
            }else if (parts[0] == "Eternal")
            {
                EternalGoal goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                _goals.Add(goal);
            }else if (parts[0] == "Checklist")
            {
                ChecklistGoal goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]));
                goal.SetAmountCompleted(int.Parse(parts[4]));

                _goals.Add(goal);
            }

        }
        _fileName = filename;
    }
}