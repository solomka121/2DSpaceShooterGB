using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class NewWeaponBonus : MonoBehaviour
{
    [SerializeField] private int GunID;
    [SerializeField] private SpriteRenderer gunSprite;
    private SpritesManager _spritesManager;
    private void Awake()
    {
        _spritesManager = new SpritesManager();

        gunSprite.sprite = _spritesManager.GetGunSprite(GunID);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;
        if (collision.TryGetComponent<Player>(out player))
        {
            int slot;
            do
            {
                slot = Random.Range(1, player._weaponController._weaponSlots.Length + 1);
            }
            while (!player._weaponController.IsSlotEmpty(slot));

            player._weaponController.CreateWeapon(slot, GunID);

            Destroy(gameObject);

        }
    }
}
