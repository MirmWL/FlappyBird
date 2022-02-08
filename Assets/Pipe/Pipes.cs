using System.Linq;

using UnityEngine;
public class Pipes : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Pipe _prefab;
    [SerializeField] private Rect _spread;
    [SerializeField] private int _startItemCount;

    private Pool<Pipe> _pool;
    
    private void Awake()
    {
        _pool = new Pool<Pipe>(_prefab, _startItemCount, _container);
        _pool.ObjectCreated += SubscribeToPipe;
        _pool.CreateInitial();
    }

    private void OnEnable()
    {
        _pool.ObjectCreated += SubscribeToPipe;
    }

    private void OnDisable()
    {
        _pool.ObjectCreated -= SubscribeToPipe;
    }

    private void SubscribeToPipe(Pipe pipe)
    {
        pipe.Out += Replace;  
    }

    private void Replace(Pipe pipe)
    {
        var rightestPosition = GetRightestPosition();
        var minSpread = new Vector2(rightestPosition.x + _spread.xMin, _spread.yMin);
        var maxSpread = new Vector2(rightestPosition.x + _spread.xMax, _spread.yMax);
            
        var randomPosition = new RandomPositionGenerator(minSpread, maxSpread).GetPosition();
        pipe.transform.position = randomPosition;
    }
    
    private Vector3 GetRightestPosition()
    {
        float maxXPosition = _pool.Items.
            Select(u => u.transform.position.x).
            Max();
        
        Pipe rightestItem = _pool.Items.
            FirstOrDefault(s => s.transform.position.x == maxXPosition);
        
        return rightestItem.transform.position;
    }
}
