using UnityEngine;
using System;

internal sealed class SpritesManager
{
    public Sprite GetGunSprite(int GunID)
    {
        Sprite gunSprite = Resources.Load<Gun>(ItemsID.GetPathFromId(GunID))
            .GetComponent<SpriteRenderer>().sprite;
        return gunSprite;
    }
}
