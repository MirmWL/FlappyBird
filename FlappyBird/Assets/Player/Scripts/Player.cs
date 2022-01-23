using System;
using UnityEngine;
  
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public event Action OnCollide;
    
    [SerializeField] 
    private PlayerStats _playerStats;
    
    private IMoveBehaviour _moveBehaviour;
    private Rigidbody2D _rigidbody2D;
    
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _moveBehaviour = new PlayerMovement(_playerStats, _rigidbody2D);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            _moveBehaviour.Jump();
    }
    
    private void FixedUpdate() => _moveBehaviour.Move();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Pipe pipe))
            OnCollide.Invoke();
    }
}
