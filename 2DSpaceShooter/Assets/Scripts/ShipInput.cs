using UnityEngine;
using System;

public class ShipInput 
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    public Vector2 MousePosition { get; private set; }

    public Action OnLeftMouseClick = delegate { };
    public Action OnRightMouseClick = delegate { };

    public Action OnLeftMouseDown = delegate { };
    private float interval = 1f;
    private float localInterval;

    public Action OnRightMouseDown = delegate { };

    public Action OnLeftShiftDown = delegate { };
    public Action OnLeftShiftUp = delegate { };

    public void Execute()
    {

        Horizontal = Input.GetAxis(PCStrings.Horizontal);
        Vertical = Input.GetAxis(PCStrings.Vetical);
        
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown(PCStrings.LeftMouseButton))
        {
            OnLeftMouseClick();
        }
        localInterval += Time.deltaTime;
        if (Input.GetButton(PCStrings.LeftMouseButton) && localInterval >= interval)
        {
            localInterval = 0.0f;
            OnLeftMouseDown();
        }

        if (Input.GetButtonDown(PCStrings.RightMouseButton))
        {
            OnRightMouseClick();
        }
        if (Input.GetButton(PCStrings.RightMouseButton))
        {
            OnRightMouseDown();
        }

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
