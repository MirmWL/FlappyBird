using UnityEngine;
using System;

[RequireComponent(typeof(BoxCollider2D))]
public class Border : MonoBehaviour 
{
    public event Action<Pipe> OnCollide;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Pipe pipe))
            OnCollide.Invoke(pipe);
    }
}
