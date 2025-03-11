using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int totalScore = 0;

    public void AddGoal(Goal goal) => goals.Add(goal);

    public void ShowGoals()
    {
        Console.WriteLine("\nYour Goals:");
        foreach (var goal in goals)
            Console.WriteLine(goal.GetStatus());
        Console.WriteLine($"Total Score: {totalScore} | Level: {GetLevel()}");
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record progress:");
        for (int i = 0; i < goals.Count; i++)
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");

        int choice = int.Parse(Console.ReadLine()) - 1;
        if (choice >= 0 && choice < goals.Count)
        {
            goals[choice].RecordProgress();
            totalScore += goals[choice].GetPoints();
            CheckAchievements();
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal (Penalty)");
        Console.Write("Enter choice: ");
        
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points (positive for rewards, negative for penalties): ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                AddGoal(new SimpleGoal(name, description, points));
                break;
            case 2:
                AddGoal(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.Write("Enter target repetitions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points on completion: ");
                int bonus = int.Parse(Console.ReadLine());
                AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case 4:
                AddGoal(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid choice!");
                return;
        }

        Console.WriteLine($"Goal '{name}' created!");
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(totalScore);
            foreach (var goal in goals)
                writer.WriteLine(goal.GetStatus());
        }
        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                totalScore = int.Parse(reader.ReadLine());
                Console.WriteLine("Goals loaded!");
            }
        }
    }

    private string GetLevel()
    {
        if (totalScore >= 5000) return "Legend";
        if (totalScore >= 2000) return "Master";
        if (totalScore >= 1000) return "Warrior";
        return "Novice";
    }

    private void CheckAchievements()
    {
        if (totalScore >= 1000)
            Console.WriteLine("🏆 Achievement Unlocked: Warrior Level!");
        if (totalScore >= 5000)
            Console.WriteLine("🎖️ Achievement Unlocked: Legend Level!");
    }
}
