using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    public event Action CollideWithPipe;
    
    [SerializeField]
    private BirdMovement _moveBehaviour;

    private void Update()
    {
        _moveBehaviour.Move();
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Pipe _))
            CollideWithPipe?.Invoke();
    }

}
