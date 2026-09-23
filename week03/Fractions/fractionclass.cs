using System;

public class Fraction
{
    // gets list of variables
    private int _top;
    private int _bottom;

    public int get_top()
    {
        return _top;
    }
      public void set_top(int top)
    {
        _top = top;
    }
    public int get_bottom()
    {
        return _bottom;
    }
      public void set_bottom(int bottom)
    {
        _bottom = bottom;
    }
    public string one(){
        return "1/1";
    }
    public string top(){
        
        return $"{_top}/1";
    } 
    public string get_fraction(){
        return $"{_top}/{_bottom}";
    }
}