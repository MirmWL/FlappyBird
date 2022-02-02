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
        _pool.ObjectCreated += SubscribePipe;
        _pool.CreateInitial();
    }

    private void OnEnable()
    {
        _pool.ObjectCreated += SubscribePipe;
    }

    private void OnDisable()
    {
        _pool.ObjectCreated -= SubscribePipe;
    }

    private void SubscribePipe(Pipe pipe)
    {
        pipe.Out += _pool.Replace;  
    }
}
