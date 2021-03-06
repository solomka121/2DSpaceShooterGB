using UnityEngine;

internal sealed class Ship : IMove, IRotate
{
    private IMove _moveImplementation;
    private IRotate _rotationImplementation;

    public float Speed
    {
        get => _moveImplementation.Speed;
        set => _moveImplementation.Speed = value;
    }
    public float RotationSpeed 
    { 
        get => _rotationImplementation.RotationSpeed;
        set => _rotationImplementation.RotationSpeed = value;
    }

    public Ship(IMove moveImplementation, IRotate rotationImplementation)
    {
        _moveImplementation = moveImplementation;
        _rotationImplementation = rotationImplementation;
    }

    public void Move(float horizontal, float vertical)
    {
        _moveImplementation.Move(horizontal, vertical);
    }

    public void Rotation(float horizontal)
    {
        _rotationImplementation.Rotation(horizontal);
    }

    public void AddAcceleration()
    {
        if (_moveImplementation is AccelerationMove accelerationMove)
        {
            accelerationMove.AddAcceleration();
        }
    }

    public void RemoveAcceleration()
    {
        if (_moveImplementation is AccelerationMove accelerationMove)
        {
            accelerationMove.RemoveAcceleration();
        }
    }
}
