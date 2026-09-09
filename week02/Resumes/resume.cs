using System;

public class Resume
{
    public string _name;

    // Make new list
    public List<Job> _jobs = new List<Job>();

    // Prints to screen
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job get_job in _jobs)
        {
            get_job.Display();
        }
    }
}