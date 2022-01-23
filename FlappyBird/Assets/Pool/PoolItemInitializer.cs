using UnityEngine;

public class PoolItemInitializer<T> where T : MonoBehaviour
{
    
    public void SetPosition(T item, IPositionProvider positionGenerator)
    {
        item.transform.position = positionGenerator.GetPosition();
    } 
}
