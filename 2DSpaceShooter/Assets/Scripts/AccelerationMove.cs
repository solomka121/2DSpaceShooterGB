using UnityEngine;

internal sealed class AccelerationMove : MoveRigidbody2D
{
    private float _acceleration;
    public AccelerationMove(Rigidbody2D rigidbody2D, float speed , float acceleration) : base(rigidbody2D , speed)
    {
        _acceleration = acceleration;
    }
    public void AddAcceleration()
    {
        Speed += _acceleration;
    }

    public void RemoveAcceleration()
    {
        Speed -= _acceleration;
    }
}
