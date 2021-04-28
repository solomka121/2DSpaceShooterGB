using UnityEngine;
using System;

public class ShipInput
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    public Action OnLeftShiftDown = delegate { };
    public Action OnLeftShiftUp = delegate { };

public void Execute()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnLeftShiftDown();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            OnLeftShiftUp();
        }
    }
}
