using System;
using UnityEngine;

[Serializable]
public class BirdMovement 
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    
    [SerializeField]
    private float _speed;
    
    [SerializeField]
    private float _jumpForce;

    public void Move()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            Jump();

        _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        _rigidbody2D.velocity = Vector2.zero;   
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }
}
