public class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }
    
    public virtual double GetArea()
    {
        return 0;
    }

    public string GetColor()
    {
        return _color;
    }
    public void SetColor(string color)
    {
        _color = color;
    }

}

// a child class called Student
public class Square : Shape
{
    private double _side;

    // calling the parent constructor using "base"!
    public Square(string color, double side) : base(color)
    {
      _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}