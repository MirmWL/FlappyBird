using UnityEngine;

public class SaveSystem
{
    private const string HighScoreSaveKey = "highScore";
    private readonly Score _score;
    
    public SaveSystem(Score score)
    {
        _score = score;
    }

    public void SaveToPlayerPrefs()
    {
        PlayerPrefs.SetInt(HighScoreSaveKey, _score.Value);        
    }

    public void Load()
    {
         _score.Value = PlayerPrefs.GetInt(HighScoreSaveKey);
    }
}