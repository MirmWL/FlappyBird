using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    public event Action<T> ObjectCreated;
    
    private readonly T _prefab;
    private readonly List<T> _items;
    private readonly int _count;
    private readonly Transform _container;
    private readonly Rect _spread;
    
    public Pool(T prefab, int count, Transform container, Rect spread)
    {
        _spread = spread;
        _count = count;
        _prefab = prefab;
        _container = container;
        _items = new List<T>();
    }

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

    public void Replace(T item)
    {
        var rightestPipePosition = GetRightestPosition();
        var minSpread = new Vector2(rightestPipePosition.x + _spread.xMin, _spread.yMin);
        var maxSpread = new Vector2(rightestPipePosition.x + _spread.xMax, _spread.yMax);
            
        var randomPosition = new RandomPositionGenerator(minSpread, maxSpread).GetPosition();
        item.transform.position = randomPosition;
    }
    
    private Vector3 GetRightestPosition()
    {
        float maxXPosition = _items.
            Select(u => u.transform.position.x).
            Max();
        
        T rightestItem = _items.
            FirstOrDefault(s => s.transform.position.x == maxXPosition);
        
        return rightestItem.transform.position;
    }
}
