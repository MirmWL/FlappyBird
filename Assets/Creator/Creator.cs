using System;
using System.Collections.Generic;
using UnityEngine;

public class Creator<T> where T : MonoBehaviour
{
    public event Action<T> ObjectCreated;
    private readonly T _prefab;
    private readonly Stack<T> _items;
    private readonly int _count;
    private readonly Transform _container;

    public Creator(T prefab, int count, Transform container)
    {
        _count = count;
        _prefab = prefab;
        _container = container;
        _items = new Stack<T>();
    }

    public IReadOnlyCollection<T> Items => _items;

    public void CreateInitial()
    {
        for (int i = 0; i < _count; i++)
            CreateObject();
    }

    private void CreateObject()
    {
        var item = UnityEngine.Object.Instantiate(_prefab, _container);
        _items.Push(item);
        ObjectCreated?.Invoke(item);
    }
}
