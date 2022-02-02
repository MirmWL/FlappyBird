using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Pipe _prefab;
    [SerializeField] private int _startItemCount;
    [SerializeField] private Rect _spread;

    private Pool<Pipe> _pool;
    
    private void Awake()
    {
        _pool = new Pool<Pipe>(_prefab, _startItemCount, _container, _spread);
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
        pipe.Out += _pool.Replace;  
    }
}
