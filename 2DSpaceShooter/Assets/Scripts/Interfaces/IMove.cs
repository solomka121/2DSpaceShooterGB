﻿using UnityEngine;

public interface IMove
{
    float Speed { get; set; }
    void Move(float horizontal , float verticlal);
}
