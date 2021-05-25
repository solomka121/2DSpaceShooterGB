using System;
using UnityEngine;

internal sealed class Player : MonoBehaviour , IDamageble
{
    [Header("Health")]
    [SerializeField] private float _maxHealth;

    [Header("Movement")]
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _rotationSpeed;
    private Rigidbody2D _rigidbody2D;

    private CameraController _cameraController;

    private Health _health;
    private ShipInput _shipInput;
    private Ship _ship;
    public WeaponController _weaponController;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _cameraController = new CameraController(Camera.main , transform);

        _health = new Health(_maxHealth , _maxHealth);
        _shipInput = new ShipInput();

        var _moveTransform = new AccelerationMove(_rigidbody2D, _speed, _acceleration);
        var _shipRotation = new ShipRotation(transform , _rotationSpeed);
        _ship = new Ship(_moveTransform , _shipRotation);

        
        _weaponController = new WeaponController( new PlayerWeaponFactory1Lvl(_shipInput) 
            , GetComponentsInChildren<IWeaponSlot>() , _shipInput);

        /*if (_weaponController.IsSlotEmpty(2))
        {
            _weaponController.CreateWeapon(2 , 2);

        }*/
    }

    private void Update()
    {
        _shipInput.Execute();
    }

    private void FixedUpdate()
    {
        _ship.Move(0.0f, _shipInput.Vertical);

        _ship.Rotation(_shipInput.Horizontal);
    }

    private void LateUpdate()
    {
        _cameraController.LateExecute();
    }

    public IHealth GetHealth()
    {
        return _health;
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

