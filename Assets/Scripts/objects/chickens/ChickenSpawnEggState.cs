using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawnEggState : AbStatePatternState
{
    public Vector3 Target;
    public GameObject[] Eggs;
    [SerializeField] private float moveSpeed=3f;
    
    
    public override ResponseEvent TriggerEvent(GameEvent gameEvent)
    {
        return null;
    }

    public override void OnEnterState()
    {
        StartCoroutine(Spawn());
        moveSpeed = Random.Range(2f, 4f);
    }

    public override void OnUpdateState()
    {
        transform.position += (Target - transform.position).normalized * moveSpeed * Time.deltaTime;

        if (Vector3.Magnitude(transform.position - Target) < 0.2)
        {
            Destroy(gameObject);
        }
    }

    public override void OnExitState()
    {
    }

    public override bool DescistionToThisState()
    {
        return false;
    }


    private IEnumerator Spawn()
    {
        float spawnRate = Random.Range(0.5f, 2f);
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(spawnRate);
            // do spawn
            var scPosision = Camera.main.WorldToScreenPoint(this.transform.position);
            if(scPosision.x>Screen.width||scPosision.x<0) continue;
            SpawnEgg();
        }
    }

    private void SpawnEgg()
    {
        int eggCount = Eggs.Length;
        int eggSpawnIndex = Random.Range(0, eggCount);

        Instantiate(Eggs[eggSpawnIndex], transform.position+new Vector3(0,-0.5f,0), Quaternion.identity);
    }
}
