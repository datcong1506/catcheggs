using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonobehaviourSingletonInterface<GameStateManager>
{

    [SerializeField] private UnityEvent OnPlayGameEvent;
    private void Start()
    {
        InitialState();
    }
    
    public void InitialState()
    {
        Time.timeScale = 0;
    }

    public void PlayState()
    {
        Time.timeScale = 1;
        OnPlayGameEvent?.Invoke();
        MainGameUI.Singleton.ToPlayState();
    }
    
    
    // Test
   
}
