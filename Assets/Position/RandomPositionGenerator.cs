using UnityEngine;

public class RandomPositionGenerator 
{
    private readonly Vector2 _startRange;
    private readonly Vector2 _endRange;
    
    public RandomPositionGenerator(Vector2 startRange, Vector2 endRange)
    {
        _startRange = startRange;
        _endRange = endRange;
    }

    public Vector2 GetPosition()
    {
        var randomX = Random.Range(_startRange.x, _endRange.x);
        var randomY = Random.Range(_startRange.y, _endRange.y);
        
        return new Vector2(randomX, randomY);
    }
}
