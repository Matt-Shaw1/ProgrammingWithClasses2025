///////I exceeded the requirements by making user interaction and experience better tha the core requirements. 
// There are no repeated prompts in the Reflection Activity so each session is unique. 
// The Listing Activity tracks user responses and displays a final count. 
// I also improved the Breathing Activity with a pacing and animations to guide users through the exercise.  
// Last, I added countdown animations.




using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities:");
            Console.WriteLine("1. Breathing Exercise");
            Console.WriteLine("2. Reflection Exercise");
            Console.WriteLine("3. Listing Exercise");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an activity (1-4): ");

            string choice = Console.ReadLine();

            MindfulnessActivity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            };

            if (activity == null)
            {
                Console.WriteLine("Goodbye! Stay mindful.");
                break;
            }

            activity.Run();
        }
    }
}
