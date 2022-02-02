using System;

public class Score
{
    public event Action<int> ScoreChanged;
    public event Action<int> HighScoreChanged;
    
    private int _currentScore;
    private int _highScore;

    public int HighScore
    {
        set
        {
            HighScoreChanged?.Invoke(value);
            _highScore = value;
        }
    }
    
    private int CurrentScore
    {
        get => _currentScore;
        set
        {
            ScoreChanged?.Invoke(value);
            _currentScore = value;
        }
    }

    public void AddScore()
    {
        CurrentScore++;

        if (_currentScore > _highScore)
            HighScore = _currentScore;
    }
}
