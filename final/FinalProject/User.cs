using System;
using System.Collections.Generic;

class User
{
    private string _username;
    private List<BaseTask> _tasks;
    private int _points;
    private int _level;

    public User(string username)
    {
        _username = username;
        _tasks = new List<BaseTask>();
        _points = 0;
        _level = 1;
    }

    public void AddTask(BaseTask task) => _tasks.Add(task);

    public void CompleteTask(string title)
    {
        foreach (var task in _tasks)
        {
            if (task.Title == title && !task.Completed)
            {
                task.MarkCompleted();
                _points += 10;
                CheckLevelUp();
                Console.WriteLine($"{title} completed!");
                return;
            }
        }
        Console.WriteLine("Task not found.");
    }

    private void CheckLevelUp()
    {
        if (_points >= 100)
        {
            _level++;
            _points -= 100;
            Console.WriteLine($"Leveled up! New level: {_level}");
        }
    }

    public int Level => _level;

    public int CompletedTaskCount => _tasks.FindAll(t => t.Completed).Count;

    public void ShowTasks()
    {
        foreach (var task in _tasks)
            task.DisplayDetails();
    }
}
