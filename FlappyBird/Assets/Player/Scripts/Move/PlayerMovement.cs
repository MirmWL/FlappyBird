using UnityEngine;

public class PlayerMovement : IMoveBehaviour
{
    private readonly PlayerStats _playerStats;
    private readonly Rigidbody2D _rigidbody2D;
    
    public PlayerMovement(PlayerStats playerStats, Rigidbody2D rb)
    {
        _rigidbody2D = rb;
        _playerStats = playerStats;
    }

    void IMoveBehaviour.Move()
    {
        _rigidbody2D.velocity = new Vector2(_playerStats.Speed, _rigidbody2D.velocity.y);
    }

    void IMoveBehaviour.Jump()
    {
        _rigidbody2D.velocity = Vector2.zero;   
        _rigidbody2D.AddForce(Vector2.up * _playerStats.JumpForce);
    }
}
