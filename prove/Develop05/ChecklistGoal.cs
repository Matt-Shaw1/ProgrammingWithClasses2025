class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) 
        : base(name, description, points)
    {
        this.targetCount = targetCount;
        this.currentCount = 0;
        this.bonusPoints = bonusPoints;
    }

    public override void RecordProgress()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            Console.WriteLine($"Progress recorded for '{name}'. Earned {points} points.");

            if (currentCount == targetCount)
            {
                isCompleted = true;
                Console.WriteLine($"Congratulations! '{name}' is complete. Earned {bonusPoints} bonus points.");
            }
        }
    }

    public override string GetStatus() => isCompleted ? $"[X] {name} (Completed)" : $"[{currentCount}/{targetCount}] {name}";
    
    public override int GetPoints() => isCompleted ? points + bonusPoints : points;
}
