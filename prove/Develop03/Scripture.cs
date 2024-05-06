using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Scripture
{
    private List<Word> words;
    private int hiddenWordCount;
    private static Random random = new Random();

    public bool AllWordsHidden => hiddenWordCount == words.Count;

    public Scripture(string reference, string text)
    {
        words = new List<Word>();
        string[] textWords = text.Split(' ');
        foreach (string word in textWords)
        {
            words.Add(new Word(word));
        }
        hiddenWordCount = 0;
        Reference = reference;
    }

    public string Reference { get; }

    public void HideRandomWord()
    {
        if (!AllWordsHidden)
        {
            int index = random.Next(words.Count);
            if (!words[index].IsHidden)
            {
                words[index].Hide();
                hiddenWordCount++;
            }
        }
    }

    public void Display()
    {
        foreach (Word word in words)
        {
            Console.Write(word.IsHidden ? "___ " : $"{word.Text} ");
        }
    }

    public void DisplayWithReference()
    {
        Console.WriteLine($"Reference: {Reference}");
        Display();
    }
}