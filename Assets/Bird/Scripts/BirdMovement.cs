using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        _rigidBody.velocity = new Vector2(_speed, _rigidBody.velocity.y);
    }

    private void Jump()
    {
        _rigidBody.velocity = Vector2.zero;   
        _rigidBody.AddForce(Vector2.up * _jumpForce);
    }
}
