using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    public event Action CollideWithPipe;
    public event Action CollideWithScorePoint;
    
    [SerializeField]
    private BirdMovement _movement;

    private void Update() => _movement.Move();
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Pipe _))
            CollideWithPipe?.Invoke();
        
        if(collider.TryGetComponent(out ScorePoint _))
            CollideWithScorePoint?.Invoke();
    }

}
