using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private string _hint;
    private Random _random;

    // Constructor
    public Scripture(Reference reference, string text, string hint)
    {
        _reference = reference;
        _hint = hint;
        _random = new Random();
        _words = new List<Word>();

        // Turn the scripture text into individual Word objects
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    // Hide random words that are still visible
    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = _words
            .Where(word => !word.IsHidden())
            .ToList();

        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = _random.Next(visibleWords.Count);

            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex);
        }
    }

    // Hide every word when Flashcard Mode begins
    public void HideAllWords()
    {
        foreach (Word word in _words)
        {
            word.Hide();
        }
    }

    // Reveal random words that are currently hidden
    public void RevealRandomWords(int numberToReveal)
    {
        List<Word> hiddenWords = _words
            .Where(word => word.IsHidden())
            .ToList();

        int wordsToReveal = Math.Min(numberToReveal, hiddenWords.Count);

        for (int i = 0; i < wordsToReveal; i++)
        {
            int randomIndex = _random.Next(hiddenWords.Count);

            hiddenWords[randomIndex].Show();
            hiddenWords.RemoveAt(randomIndex);
        }
    }

    // Return the scripture reference and its words
    public string GetDisplayText()
    {
        List<string> displayedWords = new List<string>();

        foreach (Word word in _words)
        {
            displayedWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()}\n{string.Join(" ", displayedWords)}";
    }

    // Check if every word is hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    // Check if every word is visible
    public bool IsCompletelyVisible()
    {
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    // Return the optional scripture hint
    public string GetHint()
    {
        return _hint;
    }
}