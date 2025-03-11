class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points) {}

    public override void RecordProgress()
    {
        if (!isCompleted)
        {
            isCompleted = true;
            Console.WriteLine($"Goal '{name}' completed! Earned {points} points.");
        }
        else
        {
            Console.WriteLine($"Goal '{name}' is already completed.");
        }
    }

    public override string GetStatus() => isCompleted ? "[X] " + name : "[ ] " + name;
}
