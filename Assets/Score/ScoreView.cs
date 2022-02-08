using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void Init(Score score)
    {
        score.Changed += UpdateView;
    }
    
    private void UpdateView(int score)
    {
        _scoreText.text = score.ToString();
    }
}
