using System;
using System.Collections.Generic;

class ListingActivity : MindfulnessActivity
{
    private static readonly List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity helps you reflect on the good things in your life by listing as many as possible in a given category.") { }

    public override void Run()
    {
        StartMessage();
        Console.WriteLine("\n" + GetRandomPrompt());
        System.Threading.Thread.Sleep(3000);
        List<string> items = new();
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }
        Console.WriteLine($"\nYou listed {items.Count} items!");
        EndMessage();
    }

    private static string GetRandomPrompt()
    {
        Random rand = new();
        return _prompts[rand.Next(_prompts.Count)];
    }
}
