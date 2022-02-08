using System;

public class Score
{
    public event Action<int> Changed;
    private int _score;
    public int Value
    {
        get => _score;
        set 
        {
            Changed?.Invoke(value);
            _score = value;
        }
    }
}
