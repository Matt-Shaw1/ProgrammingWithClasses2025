
// I have exceeded the requirements by adding some features.
// I maade it so Users can dynamically create goals instead of using hardcoded ones
// I made a leveling system where users progress through ranks (Novice - Warrior - Master - Legend) based on the points.
// I added "negative goals" or bad habits so users can do that if they want and it tracks bad habits and deducts points


class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Show Goals");
            Console.WriteLine("2. Create New Goal");
            Console.WriteLine("3. Record Progress");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1": manager.ShowGoals(); break;
                case "2": manager.CreateGoal(); break;
                case "3": manager.RecordEvent(); break;
                case "4": manager.SaveGoals(); break;
                case "5": manager.LoadGoals(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice. Try again."); break;
            }
        }
    }
}
