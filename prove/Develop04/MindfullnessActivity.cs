using System;
using System.Threading;

abstract class MindfulnessActivity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected void GetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid positive number: ");
        }
    }

    protected void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name}...\n{_description}\n");
        GetDuration();
        Console.WriteLine("Get ready...\n");
        ShowAnimation(3);
    }

    protected void EndMessage()
    {
        Console.WriteLine("\nGreat job! You have completed the activity.");
        Console.WriteLine($"You spent {_duration} seconds on {_name}.\n");
        ShowAnimation(3);
    }

    protected void ShowAnimation(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"Starting in {i}... \r");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void Run();
}
