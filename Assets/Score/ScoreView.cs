using TMPro;

public class ScoreView
{
    private readonly TextMeshProUGUI _scoreText;
    private readonly TextMeshProUGUI _highScoreText;
    
    public ScoreView(TextMeshProUGUI scoreText, TextMeshProUGUI highScoreText, Score score)
    {
        _highScoreText = highScoreText;
        _scoreText = scoreText;
        
        score.ScoreChanged += UpdateScoreView;
        score.HighScoreChanged += UpdateHighScoreView;
    }
    
    private void UpdateScoreView(int score)
    {
        _scoreText.text = score.ToString();
    }

    private void UpdateHighScoreView(int highScore)
    {
        _highScoreText.text = highScore.ToString();
    }
}
