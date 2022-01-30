using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _currentScore;

    public void UpdateScore()
    {
        _currentScore++;
        _scoreText.text = _currentScore.ToString();
    }
}
