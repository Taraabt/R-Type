using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTime;
    float remainingTime = 0;
    void Start()
    {
        remainingTime = spawnTime;
        //transform.Translate(Vector2.left * Time.deltaTime * MoveCamera.);
    }

    void Update()
    {   
        remainingTime-=Time.deltaTime;
        if(remainingTime<=0)
        {
            remainingTime = spawnTime;
            Vector2 pos = new Vector2(transform.position.x, Random.Range(-4.5f, +4.5f));
            GameObject instance;
            instance = Instantiate(enemy, pos, Quaternion.identity);
        }
    }
}
