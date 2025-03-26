using System;
using System.Collections.Generic;

public class User
{
    public string Username { get; }
    public List<Task> Tasks { get; }
    public int Points { get; private set; }
    public int Level { get; private set; }

    public User(string username)
    {
        Username = username;
        Tasks = new List<Task>();
        Points = 0;
        Level = 1;
    }

    public void AddTask(Task task)
    {
        Tasks.Add(task);
    }

    public void DeleteTask(string title)
    {
        Tasks.RemoveAll(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public void CompleteTask(string title)
    {
        foreach (var task in Tasks)
        {
            if (task.Title.Equals(title, StringComparison.OrdinalIgnoreCase) && !task.Completed)
            {
                task.MarkCompleted();
                Points += 10;
                CheckLevelUp();
                break;
            }
        }
    }

    private void CheckLevelUp()
    {
        while (Points >= 100)
        {
            Level++;
            Points -= 100;
            Console.WriteLine($" Congrats! You've reached level {Level}! ");
        }
    }
}
