using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Score _score;
    [SerializeField] private Button _restartButton;

    private void SubscribeRestartButton()
    {
        _restartButton.onClick.AddListener(Restart);
    }
    
    private void SubscribeBird()
    {
        _bird.CollideWithPipe += Restart;
        _bird.CollideWithScorePoint += _score.UpdateScore;
    }

    private void UnsubscribeRestartButton()
    {
        _restartButton.onClick.RemoveListener(Restart);
    }

    private void UnsubscribeBird()
    {
        _bird.CollideWithPipe -= Restart;
        _bird.CollideWithScorePoint -= _score.UpdateScore;
    }

    private void OnEnable()
    {
        SubscribeBird();
        SubscribeRestartButton();
    }

    private void OnDisable()
    {
        UnsubscribeBird();
        UnsubscribeRestartButton();
    }
    private void Restart() => SceneManager.LoadScene(0);
}
