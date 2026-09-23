using System;

public class Scripture
{
    // gets list of variables
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    private bool _isEasy = false;

    public Scripture(Reference Reference, string text)
    {
        _reference = Reference;

        // turns text into individual words
        string[] words = text.Split(' ');
    
        foreach (string word in words)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
    }
    public void HideRandomWords()
    {
        List<Word> _can_hide = new List<Word>();

        // puts all none hidden words in a list
        foreach (Word get_word in _words)
        {
            if (!get_word.IsHidden()){
                _can_hide.Add(get_word);
            }
        }

        // gets number count to hide
        int hide_number = Math.Clamp(_words.Count / 10, 1, 999);


        for (int i = 0; i < hide_number; i++)
        {   
            Random random = new Random();
            int get_random = random.Next(_can_hide.Count);

            Word randomWord = _can_hide[get_random];

            // Do something with the selected word
            randomWord.Hide();

            // Prevent this word from being selected again
            _can_hide.RemoveAt(get_random);
        }

    }
    public string GetDisplayText()
    {
        string text = "";
        text += _reference.GetDisplayText() + " ";
        foreach (Word get_word in _words)
        {
            text += " " + get_word.GetDisplayText(_isEasy);
        }

        return text;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word get_word in _words)
        {
            if (!get_word.IsHidden()){
                return false;
            }
        }
        return true;
    }

    public void EasyMode()
    {
        _isEasy = true;
    }
    public bool IsEasy()
    {
        return _isEasy;
    }
}