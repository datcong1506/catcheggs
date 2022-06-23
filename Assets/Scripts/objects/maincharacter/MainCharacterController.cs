using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainCharacterController : MonoBehaviour
{
    private GameInputs.PlayerActions playerActions;
    
    #region ChangeAble

    [SerializeField] private float moveSpeed = 2f;


    public Vector3 Target;
    #endregion

    
    private void Awake()
    {
        playerActions = GInputScriptableobject.Singleton.GameInputs.Player;
        if (!playerActions.enabled)
        {
            playerActions.Enable();
        }
    }
    
    
    private void Update()
    {
        if(Time.timeScale==0) return;
        
        SetTarget();
        Move();
        DebugThisMono();
    }
    
    private void SetTarget()
    {
        // handle input detect
        if (playerActions.Touch.IsPressed())
        {
            var touchPosision = playerActions.TouchPosision.ReadValue<Vector2>();
            if (touchPosision.x > Screen.width || touchPosision.x < 0) return;
            if(touchPosision.y > Screen.height*3/4||touchPosision.y<0) return;

            var touchWorldPosision = Camera.main.ScreenToWorldPoint(new Vector3(touchPosision.x, touchPosision.y));
            touchWorldPosision.z = 0;
            
            Target = touchWorldPosision;
            Target.y = -1.5f;
        }
    }
    private void Move()
    {
        if (Vector3.Magnitude(transform.position - Target) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, Target, 0.8f);
        }
    }
    
    
    // Test
    private void DebugThisMono()
    {
        /*Debug.Log(Target);*/
    }
}
