using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameDataSecssion",menuName =  "Scriptableobject/single/DataSecssion")]
public class GameDataSecssion : ScripableSingletonInterface<GameDataSecssion>
{
    public int currentScore;
    public int maxScore;
    public bool useAudio;
    public bool useEffect;
}
