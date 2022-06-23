using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(ChickenSpawnEggState))]
public class ChickenInitialState : AbStatePatternState
{
    private ChickenSpawnEggState chickenSpawnEggState => GetComponent<ChickenSpawnEggState>();
    
    
    
    
    
    public override ResponseEvent TriggerEvent(GameEvent gameEvent)
    {
        return null;
    }
    
    public override void OnEnterState()
    {
        var decistion=Random.Range(1, 100);



        var xtarget = 0;
        var ytarget = Screen.height * 3 / 4;
        var xOutSize = Screen.width / 4;
        if (decistion > 50)
        {
            xtarget = Screen.width + xOutSize;

            var initialPosision=Camera.main.ScreenToWorldPoint(new Vector3(-xOutSize, ytarget, 0));
            initialPosision.z = 0;

            this.transform.position = initialPosision;
            var targetAngle = transform.rotation.eulerAngles;
            targetAngle.y = -180;
            transform.rotation=Quaternion.Euler(targetAngle);
        }
        else
        {
            xtarget = -xOutSize;
            
            var initialPosision=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width+xOutSize, ytarget, 0));
            initialPosision.z = 0;
            

            this.transform.position = initialPosision;
        }

        
        
        
        
        var worldTarget = Camera.main.ScreenToWorldPoint(new Vector3(xtarget, ytarget));
        worldTarget.z=0;
        chickenSpawnEggState.Target = worldTarget;
        
        abStatePatternIFSM.ChangeState(new GameEventChangeStateEvent
        {
            newState = chickenSpawnEggState
        });
    }

    public override void OnUpdateState()
    {
    }

    public override void OnExitState()
    {
    }

    public override bool DescistionToThisState()
    {
        return true;
    }
}
