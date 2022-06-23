using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonobehaviourSingletonInterface<ScoreManager>
{
    [SerializeField]public int _currentScore=0;

    private int CurrentScore
    {
        get
        {
            return _currentScore;
        }
        set
        {
            _currentScore = value;
        }
    }


    public void PlusScore(int Score)
    {
        CurrentScore+=Score;
        MainGameUI.Singleton.UpdateScore(CurrentScore);
        GameDataSecssion.Singleton.maxScore = CurrentScore > GameDataSecssion.Singleton.maxScore
            ? CurrentScore
            : GameDataSecssion.Singleton.maxScore;
    }
}
