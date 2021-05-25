using UnityEngine;
using System;

public class Health : IHealth
{
    public float Max { get; private set; }
    public float Current { get; private set; }

    public Action OnDamage = delegate { };
    public Action OnDeath = delegate { };

    public Health(float max, float current)
    {
        Max = max;
        Current = current;
    }

    public void ChangeCurrentHealth(float hp)
    {
        Current = hp;
    }

    public void GetDamage(float damage)
    {
        Current = (float)Math.Round(Current - damage , 1);
        OnDamage();

        if (Current <= 0)
        {
            Current = 0;
            OnDeath();
        }
    }
}

