using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                string escapedPrompt = EscapeForCsv(entry.Prompt);
                string escapedResponse = EscapeForCsv(entry.Response);
                file.WriteLine($"\"{entry.Date}\",\"{escapedPrompt}\",\"{escapedResponse}\"");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        using (StreamReader file = new StreamReader(filename))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var parts = ParseCsvLine(line);
                if (parts.Count == 3)
                {
                    AddEntry(new Entry(parts[1], parts[2], parts[0]));
                }
            }
        }
    }

    private string EscapeForCsv(string input)
    {
        if (input.Contains("\""))
            input = input.Replace("\"", "\"\"");
        if (input.Contains(","))
            return $"\"{input}\"";
        return input;
    }

    private List<string> ParseCsvLine(string line)
    {
        var parts = new List<string>();
        var regex = new Regex("\"(.*?)\"|([^,]+)");
        MatchCollection matches = regex.Matches(line);
        foreach (Match match in matches)
        {
            parts.Add(match.Value.Trim('"'));
        }
        return parts;
    }
}