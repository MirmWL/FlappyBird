using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    public event Action CollideWithPipe;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    
    private BirdMovement _moveBehaviour;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _moveBehaviour = new BirdMovement(_rigidbody, _speed, _jumpForce);
    }
    
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
