using UnityEngine;

public class CameraArea : IPositionProvider
{
    private readonly Camera _camera;
    
    public CameraArea(Camera camera)
    {
        _camera = camera;
    }

    public Vector2 GetPosition()
    {
        return _camera.transform.position;
    }
    
    public Vector2 GetRightBound()
    {
        return new Vector2(_camera.ScreenToWorldPoint(
            new Vector2(_camera.pixelWidth, _camera.pixelHeight)).x, _camera.rect.y);
    }
    
}
