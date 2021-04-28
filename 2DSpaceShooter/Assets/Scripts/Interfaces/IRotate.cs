using UnityEngine;

public interface IRotate
{
    float RotationSpeed { get; set; }
    void Rotation(float horizontal , float deltaTime);
}
