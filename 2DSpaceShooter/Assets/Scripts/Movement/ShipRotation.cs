using UnityEngine;

public class ShipRotation : IRotate
{
    private Transform _transform;
    public float RotationSpeed { get; set; }

    public ShipRotation(Transform transform, float rotationSpeed)
    {
        _transform = transform;
        RotationSpeed = rotationSpeed;
    }

    public void Rotation(float horizontal)
    {
        _transform.Rotate(Vector3.forward * (RotationSpeed * -horizontal));
    }
}
