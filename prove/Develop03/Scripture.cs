using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private HashSet<int> _hiddenIndexes;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        _hiddenIndexes = new HashSet<int>();
    }

    public void HideWords(int count = 2)
    {
        var availableIndexes = Enumerable.Range(0, _words.Count)
                                         .Where(i => !_hiddenIndexes.Contains(i))
                                         .ToList();

        if (availableIndexes.Count == 0) return;

        var random = new Random();
        var toHide = availableIndexes.OrderBy(_ => random.Next()).Take(count);

        foreach (var index in toHide)
        {
            _words[index].Hide();
            _hiddenIndexes.Add(index);
        }
    }

    public bool IsFullyHidden()
    {
        return _hiddenIndexes.Count == _words.Count;
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference);
        Console.WriteLine(string.Join(" ", _words));
    }
}
