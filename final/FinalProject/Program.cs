using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your username: ");
        var username = Console.ReadLine();
        var user = new User(username);
        var rewards = new RewardSystem();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n Task Manager Menu");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Edit Task");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. View Tasks");
            Console.WriteLine("6. View Achievements");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option (1-7): ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Task title: ");
                    string title = Console.ReadLine();
                    Console.Write("Category: ");
                    string category = Console.ReadLine();
                    Console.Write("Priority (High/Medium/Low): ");
                    string priority = Console.ReadLine();
                    Console.Write("Deadline (YYYY-MM-DD): ");
                    string deadlineStr = Console.ReadLine();

                    var task = new Task(title, category, priority, Utils.ParseDate(deadlineStr));
                    user.AddTask(task);
                    Console.WriteLine($"Task '{title}' added.");
                    break;

                case "2":
                    Console.Write("Task title to edit: ");
                    string editTitle = Console.ReadLine();
                    var taskToEdit = user.Tasks.Find(t => t.Title.Equals(editTitle, StringComparison.OrdinalIgnoreCase));
                    if (taskToEdit != null)
                    {
                        Console.Write("New title (leave empty to keep current): ");
                        var newTitle = Console.ReadLine();
                        Console.Write("New category (leave empty to keep current): ");
                        var newCategory = Console.ReadLine();
                        Console.Write("New priority (leave empty to keep current): ");
                        var newPriority = Console.ReadLine();
                        Console.Write("New deadline (YYYY-MM-DD, leave empty to keep current): ");
                        var newDeadline = Console.ReadLine();

                        taskToEdit.EditTask(
                            string.IsNullOrWhiteSpace(newTitle) ? null : newTitle,
                            string.IsNullOrWhiteSpace(newCategory) ? null : newCategory,
                            string.IsNullOrWhiteSpace(newPriority) ? null : newPriority,
                            string.IsNullOrWhiteSpace(newDeadline) ? (DateTime?)null : Utils.ParseDate(newDeadline)
                        );
                        Console.WriteLine($"Task '{editTitle}' Updated.");
                    }
                    else
                    {
                        Console.WriteLine("Task not found.");
                    }
                    break;

                case "3":
                    Console.Write("Title of completed task: ");
                    string completeTitle = Console.ReadLine();
                    user.CompleteTask(completeTitle);
                    rewards.CheckRewards(user);
                    break;

                case "4":
                    Console.Write("Title of task to delete: ");
                    string deleteTitle = Console.ReadLine();
                    user.DeleteTask(deleteTitle);
                    Console.WriteLine($"Task '{deleteTitle}' deleted if it existed.");
                    break;

                case "5":
                    Console.WriteLine("\n Your Tasks:");
                    foreach (var t in user.Tasks)
                    {
                        var status = t.Completed ? "✅" : "❌";
                        Console.WriteLine($"{status} [{t.Priority}] {t.Title} - {t.Category} (Due: {t.Deadline:yyyy-MM-dd})");
                    }
                    break;

                case "6":
                    Console.WriteLine("\n Achievements Earned:");
                    if (rewards.Achievements.Count > 0)
                        foreach (var achievement in rewards.Achievements)
                            Console.WriteLine($"• {achievement}");
                    else
                        Console.WriteLine("No achievements yet. Keep going!");
                    break;

                case "7":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
