using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Scripture> scriptureLibrary = LoadScripturesFromFile("scriptures.txt");

        if (scriptureLibrary.Count == 0)
        {
            Console.WriteLine("No scriptures found in the file.");
            return;
        }

        Random random = new Random();
        Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        while (true)
        {
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            string userInput = Console.ReadLine()?.Trim().ToLower();
            if (userInput == "quit")
                break;

            scripture.HideWords(3);

            if (scripture.IsFullyHidden())
            {
                scripture.Display();
                Console.WriteLine("\nAll words are hidden. You've memorized the scripture!");
                break;
            }
        }
    }

    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        try
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split('|');
                if (parts.Length != 2) continue;

                string referenceText = parts[0].Trim();
                string scriptureText = parts[1].Trim();

                Reference reference = Reference.Parse(referenceText);
                scriptures.Add(new Scripture(reference, scriptureText));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading scriptures: {ex.Message}");
        }

        return scriptures;
    }
}
