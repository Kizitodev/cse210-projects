public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string underscores = "";

            foreach (char character in _text)
            {
                if (char.IsLetterOrDigit(character))
                {
                    underscores += "_";
                }
                else
                {
                    underscores += character;
                }
            }

            return underscores;
        }

        return _text;
    }
}