using UnityEngine;

public class PipeCreateBehaviour : ICreateBehaviour<Pipe>
{
    public Pipe Create(IPositionProvider positionProvider, Pipe prefab)
    {
        return Object.Instantiate(prefab, positionProvider.GetPosition(), Quaternion.identity);
    }
}
