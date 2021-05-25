using UnityEngine;

public class Enemy : MonoBehaviour , IDamageble
{
    [Header("Health")]
    [SerializeField] private float _maxHealth;

    [Header("Movement")]
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rigidbody2D;
    private Ship _ship;
    private Health _health;

    public IHealth GetHealth()
    {
        return _health;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        var _moveTransform = new AccelerationMove(_rigidbody2D, _speed, _acceleration);
        var _shipRotation = new ShipRotation(transform, _rotationSpeed);

        _ship = new Ship(_moveTransform, _shipRotation);
        _health = new Health(_maxHealth, _maxHealth);

        _health.OnDamage += GotDamage;
    }
    private void GotDamage()
    {
        Debug.Log(_health.Current);
    }
}
