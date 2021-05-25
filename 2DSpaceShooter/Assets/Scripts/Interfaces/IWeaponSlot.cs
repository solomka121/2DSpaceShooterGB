public interface IWeaponSlot
{
    UnityEngine.Transform transform { get; }
    IWeapon weapon { get; set; }

}
