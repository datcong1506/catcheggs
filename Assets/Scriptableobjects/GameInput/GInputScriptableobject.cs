using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GInput",menuName = "Scriptableobject/single/ginput")]
public class GInputScriptableobject : ScripableSingletonInterface<GInputScriptableobject>
{
    private GameInputs _gameInputs;

    public GameInputs GameInputs
    {
        get
        {
            if (_gameInputs == null)
            {
                _gameInputs = new GameInputs();
            }

            return _gameInputs;
        }
        
    }
}
