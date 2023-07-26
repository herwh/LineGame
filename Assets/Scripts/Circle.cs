using System;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public event Action Death;
    
    [SerializeField] private float _forceForward;
    [SerializeField] private float _forceUp;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Vector2 _velocityLimit;
    private Vector3 _direction;

    private void FixedUpdate()
    {
        MoveUp();
    }

    private void MoveUp()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector2.up * _forceUp);
        }

        var velocityY = Mathf.Clamp(_rigidbody2D.velocity.y, _velocityLimit.x, _velocityLimit.y);

        _rigidbody2D.velocity = new Vector2(_forceForward, velocityY);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Death != null) Death();
    }
}
