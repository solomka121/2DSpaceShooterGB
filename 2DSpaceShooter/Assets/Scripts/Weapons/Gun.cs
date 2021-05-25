using UnityEngine;
using System;

public class Gun : MonoBehaviour , IWeapon 
{
    [SerializeField] private Transform Barrel;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate;
    private float _nextFireTime;
    private bool canFire;
    [SerializeField] private float bulletStartSpeed;

    public ShipInput input;
    
    public void Initialize(ShipInput input)
    {
        this.input = input;
    }
    private void Start()
    {
        input.OnLeftMouseDown += Launch;
    }

    public bool CanFire()
    {
        return Time.time >= _nextFireTime;
    }

    public void Launch()
    {
        if (!CanFire())
            return;

        _nextFireTime = Time.time + fireRate;
        IBullet bullet = GameObject.Instantiate(bulletPrefab, 
            Barrel.position, Barrel.rotation).GetComponent<IBullet>();
        bullet.Init(bulletStartSpeed);
    }
}
