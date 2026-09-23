using System;

public class Word
{
    // gets list of variables
    private string _text;
    private bool _isHidden;

    public Word(String text)
    {
        _text = text;
        _isHidden = false;
    }
    public void Show()
    {
        _isHidden = false;
    }
    public void Hide()
    {
        _isHidden = true;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetDisplayText(bool _isEasy = false)
    {
        if (_isHidden)
        {
            if (_isEasy){
                string hiddenText = _text[0] + new string('_', _text.Length - 1);
                return hiddenText;
            }
            else
            {
                string hiddenText = new string('_', _text.Length);
                return hiddenText;
            }
        }
        else
        {
            return _text;
        }
    }

}