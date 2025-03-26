using System.Collections.Generic;

class RewardSystem
{
    private List<Achievement> _achievements;
    private User _user;

    public RewardSystem(User user)
    {
        _user = user;
        _achievements = new List<Achievement>
        {
            new Achievement("Level 2 Achiever", "Reach Level 2"),
            new Achievement("Task Master", "Complete 5 Tasks")
        };
    }

    public void CheckAchievements()
    {
        foreach (var ach in _achievements)
        {
            if (!ach.Unlocked)
            {
                if (ach.Name == "Level 2 Achiever" && _user.Level >= 2)
                    ach.Unlock();
                else if (ach.Name == "Task Master" && _user.CompletedTaskCount >= 5)
                    ach.Unlock();
            }
        }
    }
}
