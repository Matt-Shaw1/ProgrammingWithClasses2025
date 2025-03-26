using System;

class Achievement
{
    public string Name { get; }
    public string Description { get; }
    public bool Unlocked { get; private set; }

    public Achievement(string name, string description)
    {
        Name = name;
        Description = description;
        Unlocked = false;
    }

    public void Unlock()
    {
        Unlocked = true;
        Console.WriteLine($"Achievement unlocked: {Name} - {Description}");
    }
}
