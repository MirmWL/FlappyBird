using UnityEngine;

public class OffsetPositionProvider : IPositionProvider
{
    private readonly Vector2 _offset;
    private readonly IPositionProvider _positionProvider;

    public OffsetPositionProvider(IPositionProvider positionProvider, Vector2 offset)
    {
        _offset = offset;
        _positionProvider = positionProvider;
    }

    public Vector2 GetPosition()
    {
        return _positionProvider.GetPosition() + _offset;
    }
}
