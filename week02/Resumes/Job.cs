using System;

public class Job
{
    // gets list of variables
    public string _job;
    public string _company;
    public int _start;
    public int _end;

    public void Display(){
        Console.WriteLine($"{_job} ({_company}) {_start}-{_end}");
    }
}