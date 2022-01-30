using System;
using UnityEngine;

[Serializable]
public class BirdMovement 
{
    [SerializeField]
    private Rigidbody2D _rigidBody;
    
    [SerializeField]
    private float _speed;
    
    [SerializeField]
    private float _jumpForce;

    public void Move()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            Jump();

        _rigidBody.velocity = new Vector2(_speed, _rigidBody.velocity.y);
    }

    private void Jump()
    {
        _rigidBody.velocity = Vector2.zero;   
        _rigidBody.AddForce(Vector2.up * _jumpForce);
    }
}
