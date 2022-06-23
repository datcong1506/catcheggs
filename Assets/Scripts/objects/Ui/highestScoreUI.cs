using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class highestScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highestScoreTextMeshProUGUI;

    private void OnEnable()
    {
        highestScoreTextMeshProUGUI.text = "" + GameDataSecssion.Singleton.maxScore;
    }
}
