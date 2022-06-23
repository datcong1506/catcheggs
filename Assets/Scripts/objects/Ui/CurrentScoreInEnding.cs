using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrentScoreInEnding : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _textMeshPro;
    private void OnEnable()
    {
        _textMeshPro.text = "" + ScoreManager.Singleton._currentScore;
    }
}
