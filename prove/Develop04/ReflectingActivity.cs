using System;
using System.Collections.Generic;

class ReflectionActivity : MindfulnessActivity
{
    private static readonly List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What did you learn from this experience?",
        "How can you apply this lesson to your life?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity helps you reflect on times in your life when you have shown strength and resilience.") { }

    public override void Run()
    {
        StartMessage();
        Console.WriteLine("\n" + GetRandomPrompt());
        System.Threading.Thread.Sleep(3000);
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.WriteLine("\n" + GetRandomQuestion());
            ShowAnimation(5);
            elapsed += 5;
        }
        EndMessage();
    }

    private static string GetRandomPrompt()
    {
        Random rand = new();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private static string GetRandomQuestion()
    {
        Random rand = new();
        return _questions[rand.Next(_questions.Count)];
    }
}
