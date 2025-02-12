using System;

public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int VerseStart { get; private set; }
    public int? VerseEnd { get; private set; }

    public Reference(string book, int chapter, int verseStart, int? verseEnd = null)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    public override string ToString()
    {
        return VerseEnd.HasValue ? $"{Book} {Chapter}:{VerseStart}-{VerseEnd}" : $"{Book} {Chapter}:{VerseStart}";
    }

    public static Reference Parse(string referenceText)
    {
        string[] parts = referenceText.Split(' ');
        string book = parts[0];
        string[] chapterVerse = parts[1].Split(':');

        int chapter = int.Parse(chapterVerse[0]);
        string[] verses = chapterVerse[1].Split('-');

        int verseStart = int.Parse(verses[0]);
        int? verseEnd = verses.Length > 1 ? int.Parse(verses[1]) : (int?)null;

        return new Reference(book, chapter, verseStart, verseEnd);
    }
}
