using System;

class SimpleTask : BaseTask
{
    public SimpleTask(string title, DateTime deadline)
        : base(title, deadline) { }

    public override void DisplayDetails()
    {
        Console.WriteLine($"[Simple] {Title} - Due: {Deadline:yyyy-MM-dd} Completed: {Completed}");
    }
}
