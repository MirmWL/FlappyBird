using System;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public event Action<Pipe> Out;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.TryGetComponent(out Border _))
            Out?.Invoke(this);
    }
}
