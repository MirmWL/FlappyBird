using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Button _restartButton;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    
    private Score _score;
    private SaveSystem _saveSystem;
    
    private void Awake()
    {
        _saveSystem = new SaveSystem();
        
        _score = new Score();
        new ScoreView(_scoreText, _highScoreText, _score);
        
        _saveSystem.Load(_score);
    }
    
    private void OnEnable()
    {
        SubscribeToScore();
        SubscribeToBird();
        SubscribeRestartButton();
    }

    private void OnDisable()
    {
        UnsubscribeFromScore();
        UnsubscribeFromBird();
        UnsubscribeRestartButton();
    }

    private void SubscribeToScore()
    {
        _score.HighScoreChanged += _saveSystem.Save;
    }

    private void SubscribeRestartButton()
    {
        _restartButton.onClick.AddListener(Restart);
    }
    
    private void SubscribeToBird()
    {
        _bird.CollideWithPipe += Restart;
        _bird.CollideWithScorePoint += _score.AddScore;
    }

    private void UnsubscribeFromScore()
    {
        _score.HighScoreChanged -= _saveSystem.Save;
    }
    
    private void UnsubscribeRestartButton()
    {
        _restartButton.onClick.RemoveListener(Restart);
    }

    private void UnsubscribeFromBird()
    {
        _bird.CollideWithPipe -= Restart;
        _bird.CollideWithScorePoint -= _score.AddScore;
    }
    
    private void Restart()
    { 
        SceneManager.LoadScene(0);  
    } 
}
