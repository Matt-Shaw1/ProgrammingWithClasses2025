using System;
using System.Collections.Generic;
using System.Linq;

public class RewardSystem
{
    public HashSet<string> Achievements { get; }

    public RewardSystem()
    {
        Achievements = new HashSet<string>();
    }

    public void CheckRewards(User user)
    {
        if (user.Level >= 2 && Achievements.Add("Level 2 Achiever"))
        {
            Console.WriteLine(" Achievement Unlocked: Level 2 Achiever");
        }

        int completedTasks = user.Tasks.Count(t => t.Completed);
        if (completedTasks >= 5 && Achievements.Add("Task Master"))
        {
            Console.WriteLine(" Achievement Unlocked: Task Master (Completed 5 tasks)");
        }
    }
}
