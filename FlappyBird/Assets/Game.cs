using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Pipe _pipePrefab;
    [SerializeField] private Border _border;
    [SerializeField] private Vector2 _offsetBetweenPipes;
    [SerializeField] private Transform _pipeTopSpread, _pipeBottomSpread;
    [SerializeField] private Player _player;
    [SerializeField] private int _pipesCount;

    private ICreateBehaviour<Pipe> _pipeCreateBehaviour;
    private Pool<Pipe> _pool;
    private GameRestarter _restarter;
    private CameraArea _cameraArea;

    private void Awake()
    {
        _pipeCreateBehaviour = new PipeCreateBehaviour();
        _pool = new Pool<Pipe>(_pipePrefab);
        _cameraArea = new CameraArea(_camera);
        _restarter = new GameRestarter();
    }

    private void Start()
    {
        Subscribe();
        CreatePoolItems();
    }

    private void CreatePoolItems()
    {
        for (int i = 0; i < _pipesCount; i++)
        {
            if (i == 0)
            {
                _pool.Create(new OffsetPositionProvider(_cameraArea, _cameraArea.GetRightBound()), _pipeCreateBehaviour);
                continue;                
            }
            
            _pool.Create(GetRandomPipePosition(), _pipeCreateBehaviour);
        }
    }

    private void Subscribe()
    {
        _player.OnCollide += _restarter.Restart;
        
        _border.OnCollide += (pipe) =>
        {
            _pool.ReturnToPool(pipe);
            _pool.RemoveFromPool(GetRandomPipePosition());
        };
    }
    
    private Pipe GetRightMostPipe()
    {
        Pipe rightMost = null;
        
        foreach (Pipe item in _pool.Items)
        {
            if (rightMost == null)
            {
                rightMost = item;
                continue;                
            }

            if (item.GetPosition().x > rightMost.GetPosition().x)
                rightMost = item;
        }

        return rightMost;
    }

    private IPositionProvider GetRandomPipePosition()
    {
        Vector2 offsetPosition = 
            new OffsetPositionProvider(GetRightMostPipe(), _offsetBetweenPipes).GetPosition();

        return new RandomPositionGenerator(
            offsetPosition,
            offsetPosition +
            new RandomPositionGenerator(
                new Vector2(0, _pipeBottomSpread.position.y),
                new Vector2(0, _pipeTopSpread.position.y)).GetPosition());
    }
}
