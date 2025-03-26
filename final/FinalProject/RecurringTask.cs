using System;

class RecurringTask : BaseTask
{
    private int _frequencyDays;

    public RecurringTask(string title, DateTime deadline, int frequencyDays)
        : base(title, deadline)
    {
        _frequencyDays = frequencyDays;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"[Recurring every {_frequencyDays} days] {Title} - Next Due: {Deadline:yyyy-MM-dd} Completed: {Completed}");
    }
}
