using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour , IBullet , IDamage
{
    [SerializeField] private float _damage;
    [SerializeField] private float _minBulletSpeed;
    private Rigidbody2D _bulletRigidBody;

    private void Awake()
    {
        _bulletRigidBody = GetComponent<Rigidbody2D>();
    }

    public void Init(float startForce)
    {
        _bulletRigidBody.velocity = _bulletRigidBody.transform.up * startForce;
    }

    private void FixedUpdate()
    {
        if (_bulletRigidBody.velocity.magnitude < _minBulletSpeed)
            Destroy(this.gameObject);
    }
    public float Damage
    {
        get => (float)System.Math.Round
            (_damage * _bulletRigidBody.velocity.magnitude, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageble damagebleObject;
        if (collision.gameObject.TryGetComponent<IDamageble>(out damagebleObject))
        {
            damagebleObject.GetHealth().GetDamage(Damage);
        }
    }

}

