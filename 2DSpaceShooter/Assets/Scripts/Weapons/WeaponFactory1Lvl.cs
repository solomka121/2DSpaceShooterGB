using UnityEngine;

public class PlayerWeaponFactory1Lvl : IWeaponFactory
{
    private ShipInput _input;
    public PlayerWeaponFactory1Lvl(ShipInput input)
    {
        _input = input;
    }

    public IWeapon CreateGun(Transform parent , int gunID)
    {
        var gun = 
            Object.Instantiate(Resources.Load<Gun>(ItemsID.GetPathFromId(gunID)) , parent);
        gun.Initialize(_input);
        return gun;
    }


}