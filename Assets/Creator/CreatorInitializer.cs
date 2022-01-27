using UnityEngine;

public class CreatorInitializer : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Pipe _prefab;
    [SerializeField] private int _startItemCount;
    [SerializeField] private Rect _spread;

    private Creator<Pipe> _creator;
    
    private void Awake()
    {
        _creator = new Creator<Pipe>(_prefab, _startItemCount, _container);
        _creator.ObjectCreated += Subscribe;
        _creator.CreateInitial();
    }
    
    private void Subscribe(Pipe pipe)
    {
        pipe.Out += (s) =>
        {
            var rightestPipePosition = GetRightestPipe().transform.position;
            var minSpread = new Vector2(rightestPipePosition.x + _spread.xMin, _spread.yMin);
            var maxSpread = new Vector2(rightestPipePosition.x + _spread.xMax, _spread.yMax);
            
            var randomPosition = new RandomPositionGenerator(minSpread, maxSpread).GetPosition();
            s.transform.position = randomPosition;
        };
    }
    
    private Pipe GetRightestPipe()
    {
        Pipe rightestPipe = null;
        
        foreach (Pipe item in _creator.Items)
        {
            if (rightestPipe == null)
            {
                rightestPipe = item;
                continue;
            }

            if (item.transform.position.x > rightestPipe.transform.position.x)
                rightestPipe = item;
        }

        return rightestPipe;
    }
}
