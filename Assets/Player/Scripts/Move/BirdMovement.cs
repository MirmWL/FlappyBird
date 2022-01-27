using UnityEngine;

public class BirdMovement 
{
    private readonly Rigidbody2D _rigidbody2D;
    
    private readonly float _speed;
    private readonly float _jumpForce;
    
    public BirdMovement(Rigidbody2D rb, float speed, float jumpForce)
    {
        _speed = speed;
        _jumpForce = jumpForce;
        _rigidbody2D = rb;
    }

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
