using System;

abstract class BaseTask
{
    public string Title { get; protected set; }
    public DateTime Deadline { get; protected set; }
    public bool Completed { get; private set; }

    protected BaseTask(string title, DateTime deadline)
    {
        Title = title;
        Deadline = deadline;
        Completed = false;
    }

    public void MarkCompleted() => Completed = true;

    public abstract void DisplayDetails();
}
