using System;

public class Task
{
    public string Title { get; set; }
    public string Category { get; set; }
    public string Priority { get; set; }
    public DateTime Deadline { get; set; }
    public bool Completed { get; private set; }

    public Task(string title, string category, string priority, DateTime deadline)
    {
        Title = title;
        Category = category;
        Priority = priority;
        Deadline = deadline;
        Completed = false;
    }

    public void MarkCompleted()
    {
        Completed = true;
    }

    public void EditTask(string title = null, string category = null, string priority = null, DateTime? deadline = null)
    {
        if (!string.IsNullOrEmpty(title)) Title = title;
        if (!string.IsNullOrEmpty(category)) Category = category;
        if (!string.IsNullOrEmpty(priority)) Priority = priority;
        if (deadline.HasValue) Deadline = deadline.Value;
    }
}
