public class Goal
{
    public string _name;
    public string _description;
    public int _points;

    public Goal(string name, string description, int points)
    {
      _name = name;
      _description = description;
      _points = points;
    }
    public virtual int RecordEvent()
    {
        return 0;
    }
    
    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual string GetDetailsString()
    {
        if (IsComplete()){
            return ($"{_name}: {_description} [x]");
        }else return ($"{_name}: {_description} [ ]");
    }

    public virtual string GetStringRepresentation()
    {
        return "";
    }
}

// a child class called Student
public class SimpleGoal : Goal
{   

    private bool _isComplete = false;
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"Simple,{_name},{_description},{_points},{_isComplete}";
    }
}

public class EternalGoal : Goal
{   
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"Eternal,{_name},{_description},{_points}";
    }
}

public class ChecklistGoal : Goal
{   

    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _amountCompleted += 1;

        int point_total = _points;
        
        if (_amountCompleted == _target)
        {
            point_total += _bonus;
        }

        return point_total;
    }

    public override bool IsComplete()
    {
        if (_amountCompleted >= _target){
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetDetailsString()
    {
        return ($"{_name}: {_description} [{_amountCompleted}/{_target}]");
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist,{_name},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
    }

    public void SetAmountCompleted(int number)
    {
        _amountCompleted = number;
    }
}