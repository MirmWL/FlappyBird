using UnityEngine;

public class Pipe : MonoBehaviour, IPositionProvider
{
    public Vector2 GetPosition()
    {
        return transform.position;
    }

}
