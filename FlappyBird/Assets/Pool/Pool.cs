using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private readonly T _prefab;
    private readonly Stack<T> _items;
    private readonly int _count;
    private readonly PoolItemInitializer<T> _poolItemInitializer;
    
    public Pool(T prefab)
    {
        _prefab = prefab;
        _items = new Stack<T>();
        _poolItemInitializer = new PoolItemInitializer<T>();
    }

    public IReadOnlyCollection<T> Items => _items;

    public void Create(IPositionProvider positionProvider, ICreateBehaviour<T> createBehaviour)
    {
         _items.Push(createBehaviour.Create(positionProvider, _prefab));
    }

    public void ReturnToPool(T item)
    {
        _items.Push(item);
        item.gameObject.SetActive(false);
    }

    public void RemoveFromPool(IPositionProvider positionProvider)
    { 
        T item = _items.Peek();
        
        item.gameObject.SetActive(true);
        _poolItemInitializer.SetPosition(item, positionProvider);
    }
}
