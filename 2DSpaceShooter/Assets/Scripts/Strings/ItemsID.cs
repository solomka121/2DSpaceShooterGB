using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemsID
{
    public static int ID = 2; // all id

    public static string GetPathFromId(int id)
    {
        switch (id)
        {
            case 1:
                return PathStrings.SimpleGun;
            case 2:
                return PathStrings.SnipeGun;
            default:
                throw new System.NotImplementedException();
        }
    }
    public static int GetIDFromPath(string path)
    {
        switch (path)
        {
            case PathStrings.SimpleGun:
                return 1;
            case PathStrings.SnipeGun:
                return 2;
            default:
                throw new System.NotImplementedException();
        }
    }
}
