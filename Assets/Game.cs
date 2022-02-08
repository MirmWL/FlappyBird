using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Button _restartButton;
    
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private ScoreView _highScoreView;
    
    private Score _score;
    private Score _highScore;

    private SaveSystem _saveSystem;
    
    private void Awake()
    {
        _score = new Score();
        _scoreView.Init(_score);
        
        _highScore = new Score();
        _highScoreView.Init(_highScore);

        _saveSystem = new SaveSystem(_highScore);
        _saveSystem.Load();
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

    private void SetHighScore(int value)
    {
        if (_highScore.Value < value)
            _highScore.Value = value;
    }

    private void AddScore()
    {
        _score.Value++;
    }
    
    private void SubscribeToScore()
    {
        _score.Changed += SetHighScore;
    }

    private void SubscribeRestartButton()
    {
        _restartButton.onClick.AddListener(Restart);
    }
    
    private void SubscribeToBird()
    {
        _bird.CollideWithPipe += Restart;
        _bird.CollideWithPipe += _saveSystem.SaveToPlayerPrefs;
        _bird.CollideWithScorePoint += AddScore;
    }

    private void UnsubscribeFromScore()
    {
        _score.Changed -= SetHighScore;
    }
    
    private void UnsubscribeRestartButton()
    {
        _restartButton.onClick.RemoveListener(Restart);
    }

    private void UnsubscribeFromBird()
    {
        _bird.CollideWithPipe -= Restart;
        _bird.CollideWithPipe -= _saveSystem.SaveToPlayerPrefs;
        _bird.CollideWithScorePoint -= AddScore;
    }
    
    private void Restart()
    { 
        SceneManager.LoadScene(0);  
    } 
}
