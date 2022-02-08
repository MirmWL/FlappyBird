using System;
using System.Collections.Generic;

using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    public event Action<T> ObjectCreated;
    
    private readonly T _prefab;
    private readonly List<T> _items;
    private readonly int _count;
    private readonly Transform _container;

    public Pool(T prefab, int count, Transform container)
    {
        _count = count;
        _prefab = prefab;
        _container = container;
        _items = new List<T>();
    }

    public IReadOnlyList<T> Items => _items;

    public void CreateInitial()
    {
        for (int i = 0; i < _count; i++)
            CreateObject();
    }

    private void CreateObject()
    {
        var item = UnityEngine.Object.Instantiate(_prefab, _container);
        
        _items.Add(item);
        
        ObjectCreated?.Invoke(item);
    }
}
