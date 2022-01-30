using System.Linq;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Pipe _prefab;
    [SerializeField] private int _startItemCount;
    [SerializeField] private Rect _spread;

    private Creator<Pipe> _creator;
    
    private void Awake()
    {
        _creator = new Creator<Pipe>(_prefab, _startItemCount, _container);
        _creator.ObjectCreated += PipeOutSubscribe;
        _creator.CreateInitial();
    }

    private void PipeOutSubscribe(Pipe pipe) => pipe.Out += SetPipePosition;
    
    private void SetPipePosition(Pipe pipe)
    {
        var rightestPipePosition = GetRightestPosition();
        var minSpread = new Vector2(rightestPipePosition.x + _spread.xMin, _spread.yMin);
        var maxSpread = new Vector2(rightestPipePosition.x + _spread.xMax, _spread.yMax);
            
        var randomPosition = new RandomPositionGenerator(minSpread, maxSpread).GetPosition();
        pipe.transform.position = randomPosition;
    }
    
    private Vector3 GetRightestPosition()
    {
        float maxXPosition = _creator.Items
            .Select(u => u.transform.position.x)
            .Max();
        
        Pipe rightestPipe = _creator.Items
            .FirstOrDefault(s => s.transform.position.x == maxXPosition);
        
        return rightestPipe.transform.position;
    }

    private void OnEnable()
    {
        _creator.ObjectCreated += PipeOutSubscribe;
    }

    private void OnDisable()
    {
        _creator.ObjectCreated -= PipeOutSubscribe;
    }
}
