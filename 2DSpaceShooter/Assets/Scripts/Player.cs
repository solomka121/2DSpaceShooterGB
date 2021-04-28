using System;
using UnityEngine;

internal sealed class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _rotationSpeed;

    private Camera _camera;
    private Rigidbody2D _rigidbody2D;

    private ShipInput _shipInput;
    private Ship _ship;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _camera = Camera.main;

        _shipInput = new ShipInput();
        var _moveTransform = new AccelerationMove(_rigidbody2D, _speed, _acceleration);
        var _shipRotation = new ShipRotation(transform , _rotationSpeed);

        _ship = new Ship(_moveTransform , _shipRotation);
    }

    private void Update()
    {
        _shipInput.Execute();
        var deltaTime = Time.deltaTime;

        _ship.Move( 0.0f , _shipInput.Vertical, deltaTime);
        
        _ship.Rotation(_shipInput.Horizontal , deltaTime);
        
    }

    private void OnEnable()
    {
        _shipInput.OnLeftShiftDown += AddAcceleration;
        _shipInput.OnLeftShiftUp += RemoveAcceleration;
    }

    private void AddAcceleration()
    {
        _ship.AddAcceleration();
    }

    private void RemoveAcceleration()
    {
        _ship.RemoveAcceleration();
    }

    private void OnDisable()
    {
        _shipInput.OnLeftShiftDown -= AddAcceleration;
        _shipInput.OnLeftShiftUp -= RemoveAcceleration;
    }
}

