class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) {}

    public override void RecordProgress()
    {
        Console.WriteLine($"Recorded progress for '{name}'. Earned {points} points.");
    }

    public override string GetStatus() => "[∞] " + name;
}
