using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenFSM : AbStatePatternIFSM
{
    private void Update()
    {
        currentState.CheckChangeState();
        currentState.OnUpdateState();
    }


    public override ResponseEvent TriggerEvent(GameEvent gameEvent)
    {
        return null;
    }
}
