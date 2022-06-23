using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;


[RequireComponent(typeof(Rigidbody2D))]
public class EgsController : MonoBehaviour
{

    [SerializeField] private string groundTag;
    [SerializeField] private string playerTag;

    [SerializeField] private int score;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(groundTag))
        {
            StartCoroutine(EggHitGround());
        }
        else
        {
            if (col.CompareTag(playerTag))
            {
                ScoreManager.Singleton.PlusScore(score);
                Destroy(gameObject);
            }
        }
    }


    IEnumerator EggHitGround()
    {
        float t = UnityEngine.Random.Range(0f, 0.1f);

        yield return new WaitForSeconds(t);

        var rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;
        rigidbody2D.velocity=Vector2.zero;
        gameObject.GetComponent<Animator>().SetTrigger("EggBroke");
        ScoreManager.Singleton.PlusScore(-1);
        
        
        Destroy(gameObject,UnityEngine.Random.Range(1.5f,2.5f));
    }
}
