using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your username: ");
        var username = Console.ReadLine();
        User user = new User(username);
        RewardSystem rewardSystem = new RewardSystem(user);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n1-Add Task  2-Complete Task  3-Show Tasks  4-Exit");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Task title: ");
                    string title = Console.ReadLine();

                    Console.Write("Due Date (yyyy-mm-dd): ");
                    string dueDateInput = Console.ReadLine();
                    DateTime dueDate;
                    while (!DateTime.TryParseExact(dueDateInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dueDate))
                    {
                        Console.Write("Invalid date. Enter again (yyyy-mm-dd): ");
                        dueDateInput = Console.ReadLine();
                    }

                    user.AddTask(new SimpleTask(title, dueDate));
                    Console.WriteLine($"Task '{title}' due on {dueDate:yyyy-MM-dd} added.");
                    break;

                case "2":
                    Console.Write("Task to complete: ");
                    user.CompleteTask(Console.ReadLine());
                    rewardSystem.CheckAchievements();
                    break;

                case "3":
                    user.ShowTasks();
                    break;

                case "4":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
