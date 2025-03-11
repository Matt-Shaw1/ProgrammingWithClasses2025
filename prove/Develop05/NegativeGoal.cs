class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) : base(name, description, points) {}

    public override void RecordProgress()
    {
        Console.WriteLine($"Warning! Negative goal '{name}' recorded. Lost {points} points.");
    }

    public override string GetStatus() => $"[⚠️] {name}";
}
