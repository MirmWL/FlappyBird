using UnityEngine;

public class SaveSystem
{
    private const string SAVE_HIGH_SCORE = "highScore";

    public void Save(int score)
    {
        PlayerPrefs.SetInt(SAVE_HIGH_SCORE, score);        
    }

    public void Load(Score score)
    {
        score.HighScore = PlayerPrefs.GetInt(SAVE_HIGH_SCORE);
    }
}