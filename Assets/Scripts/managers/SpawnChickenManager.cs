using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnChickenManager : MonobehaviourSingletonInterface<SpawnChickenManager>
{
    [SerializeField]private float numberChicken;


    [SerializeField]private GameObject[] chickens;


    private void Start()
    {
        StartCoroutine(SpawnChickens());
    }


    IEnumerator SpawnChickens()
    {
        for (int i = 0; i < numberChicken;i++)
        {
            SpawnChicken();
            yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 1.5f));
        }
    }

    private void SpawnChicken()
    {
        int chickenCount = chickens.Length;
        if(chickenCount<0) return;

        int spawnIndex = UnityEngine.Random.Range(0, chickenCount - 1);
        Instantiate(chickens[spawnIndex], Vector3.back * 100, quaternion.identity);
    }
}
