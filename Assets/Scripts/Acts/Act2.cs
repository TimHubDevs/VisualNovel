using System;
using System.Collections;
using UnityEngine;

public class Act2 : Act
{
    public override void StartAct(Action endCallback)
    {
        base.StartAct(endCallback);
        StepZero();
    }

    private void StepZero()
    {
        
    }
}
