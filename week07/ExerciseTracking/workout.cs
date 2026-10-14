public class Activity 
{
    protected string _date;
    protected int _length;

    public Activity(string date, int length)
    {
        _date = date;
        _length = length;
    }
    
    public virtual void GetSummary()
    {
        Console.WriteLine($"{_date}: {_length} minutes");
    }

}

// a child class called Student
public class Running : Activity
{
    private float _distance;

    // calling the parent constructor using "base"!
    public Running(string date, int length, float distance) : base(date, length)
    {
      _distance = distance;
    }

    public float GetSpeed()
    {
        return (_distance / _length) * 60.0f;
    }

    public float GetPace()
    {
        return (_length / _distance);
    }

    public override void GetSummary()
    {
        var _speed = GetSpeed();
        var _pace = GetPace();
        Console.WriteLine($"{_date} Running ({_length} min): Distance {_distance:F2} miles, Speed {_speed:F2} mph, Pace {_pace:F2} min per mile");
    }
}

public class Cycling : Activity
{
    private float _speed;

    public Cycling(string date, int length, float speed) : base(date, length)
    {
      _speed = speed;
    }

    public float GetDistance()
    {
        return _speed * (_length / 60.0f);
    }

    public float GetPace()
    {
        var _distance = GetDistance();
        return (_length / _distance);
    }

    public override void GetSummary()
    {
        var _distance = GetDistance();
        var _pace = GetPace();
        Console.WriteLine($"{_date} Cycling ({_length} min): Distance {_distance:F2} miles, Speed {_speed:F2} mph, Pace {_pace:F2} min per mile");
    }
}


public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int length, int laps) : base(date, length)
    {
      _laps = laps;
    }

    public float GetDistance()
    {
        return _laps * 50.0f / 1000.0f * 0.62f;
    }
    public float GetSpeed()
    {
        var _distance = GetDistance();
        return (_distance / _length) * 60.0f;
    }

    public float GetPace()
    {
        var _distance = GetDistance();
        return (_length / _distance);
    }

    public override void GetSummary()
    {
        var _distance = GetDistance();
        var _speed = GetSpeed();
        var _pace = GetPace();
        Console.WriteLine($"{_date} Swimming ({_length} min): Distance {_distance:F2} miles, Speed {_speed:F2} mph, Pace {_pace:F2} min per mile");
    }
}