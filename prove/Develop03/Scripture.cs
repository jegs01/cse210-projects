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

    public void HideRandomWords()
    {
        if (!AllWordsHidden)
        {
            int index1, index2;
            
            // Check if there's only one unhidden word left
            if (words.Count - hiddenWordCount == 1)
            {
                // Find the index of the remaining unhidden word
                int remainingWordIndex = words.FindIndex(word => !word.IsHidden);
                // Hide the remaining unhidden word
                words[remainingWordIndex].Hide();
                hiddenWordCount += 1;
            }
            else
            {
                // Randomly select two different indices until both words are unhidden
                do
                {
                    index1 = random.Next(words.Count);
                    index2 = random.Next(words.Count);
                } while (index1 == index2 || words[index1].IsHidden || words[index2].IsHidden);

                // Hide the selected words
                words[index1].Hide();
                words[index2].Hide();
                hiddenWordCount += 2;
            }
        }
    }


    public void Display()
    {
        Console.WriteLine($"Reference: {Reference}");
        foreach (Word word in words)
        {
            Console.Write(word.IsHidden ? "___ " : $"{word.Text} ");
        }
    }

    public void DisplayWithReference()
    { 
        Display();
    }
}