using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;


[RequireComponent(typeof(Animator))]
public class MainGameUI : MonobehaviourSingletonInterface<MainGameUI>
{
    [SerializeField]private TextMeshProUGUI _textMeshProUGUI;

    public GameState gameState;
    private void Start()
    {
        gameState = GameState.Initial;
    }

    private Animator animator => GetComponent<Animator>();

    public void UpdateScore(int score)
    {
        _textMeshProUGUI.text=""+score;
    }

    public void PauseState()
    {
        animator.SetTrigger("PauseToMenu");
        Time.timeScale = 0;
    }

    public void BackToGame()
    {
        animator.SetTrigger("BackToGame");
        Time.timeScale = 1;

    }

    public void ToSetttinMenu()
    {
        animator.SetTrigger("BasicToSetting");
    }

    public void SettingToBasic()
    {
        animator.SetTrigger("SettingToBasic");
    }

    public void ToPlayState()
    {
        animator.SetTrigger("ToPlayState");
    }
    
    
    public void QuitGame()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}

public enum GameState
{
    Initial,
    Playing,
    Pausing,
    Ending,
}
