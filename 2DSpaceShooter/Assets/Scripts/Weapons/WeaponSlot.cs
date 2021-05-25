using UnityEngine;

internal sealed class WeaponSlot : MonoBehaviour, IWeaponSlot
{
    public IWeapon weapon { get; set; }
}
