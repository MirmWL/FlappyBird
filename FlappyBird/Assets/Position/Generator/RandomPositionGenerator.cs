using UnityEngine;

public class RandomPositionGenerator : IPositionProvider
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
        return new Vector2(
            Random.Range(_startRange.x, _endRange.x),
            Random.Range(_startRange.y, _endRange.y));
    }
}
