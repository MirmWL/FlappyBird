using UnityEngine;

public interface ICreateBehaviour<T> where T : MonoBehaviour
{
    T Create(IPositionProvider positionProvider, T prefab);
}
