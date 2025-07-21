using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count)
    {
        var visibleWords = _words.Where(w => !w.IsHidden).ToList();
        if (visibleWords.Count == 0) return;
        int toHide = Math.Min(count, visibleWords.Count);
        for (int i = 0; i < toHide; i++)
        {
            int idx = _random.Next(visibleWords.Count);
            visibleWords[idx].Hide();
            visibleWords.RemoveAt(idx);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden);
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        Console.WriteLine();
        Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplayText())));
    }
}