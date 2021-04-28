using UnityEngine;

internal class MoveRigidbody2D : IMove
{
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private Vector3 _move;

    public float Speed { get; set; }

    public MoveRigidbody2D(Rigidbody2D rigidbody , float speed)
    {
        _rigidbody2D = rigidbody;
        _transform = rigidbody.transform;
        Speed = speed;
    }

    public void Move(float horizontal , float vertical , float deltaTime)
    {
        var speed = Speed * deltaTime;
        _move = _transform.right * horizontal + _transform.up * vertical;
        _rigidbody2D.AddForce(_move * speed , ForceMode2D.Force);
    }
}
