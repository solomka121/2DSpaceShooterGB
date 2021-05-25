using UnityEngine;
using System;

public class WeaponController
{
    public IWeaponSlot[] _weaponSlots { get; private set; }

    private ShipInput _input;
    private IWeaponFactory _weaponFactory;

    public WeaponController( IWeaponFactory weaponFactory , IWeaponSlot[] weaponSlots , ShipInput input)
    {
        _weaponSlots = weaponSlots;
        _weaponFactory = weaponFactory;

        _input = input;
    }

    public bool IsSlotEmpty(int slot)
    {
        if (slot > _weaponSlots.Length)
            throw new NotImplementedException();

        slot--; // for massives
        if (_weaponSlots[slot].weapon == null) 
            return true;
        else 
            return false;
    }
    public void CreateWeapon( int slot , int gunID)
    {
        slot--;
        _weaponSlots[slot].weapon = _weaponFactory.CreateGun(_weaponSlots[slot].transform , gunID);
    }

    public IWeapon GetWeaponInSlot(int slot)
    {
        slot--;
        return _weaponSlots[slot].weapon;
    }
}
