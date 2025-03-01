using System;

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity helps you relax by guiding you through slow breathing. Clear your mind and focus on your breath.") { }

    public override void Run()
    {
        StartMessage();
        for (int i = 0; i < _duration / 6; i++)
        {
            Console.WriteLine("\nBreathe in...");
            ShowAnimation(3);
            Console.WriteLine("Breathe out...");
            ShowAnimation(3);
        }
        EndMessage();
    }
}
