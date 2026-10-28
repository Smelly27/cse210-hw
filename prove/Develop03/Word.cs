public class Word
{
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Hide this word
    public void Hide()
    {
        _isHidden = true;
    }

    // Show this word
    public void Show()
    {
        _isHidden = false;
    }

    // Check whether the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Return the word or underscores
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }

        return _text;
    }
}