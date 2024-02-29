using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class FastEnemy : Enemy
{

    float remainingTime;
    [SerializeField]float shootingTime;
    [SerializeField] float enemySpeed;
    [SerializeField] EnemyBullet enemyBullet;

    void Start()
    {
        remainingTime = shootingTime;
        transform.Translate(Vector2.left * Time.deltaTime * enemySpeed);
    }

    void Update()
    {
        CheckOut();
        Vector3 pos = new Vector2(transform.position.x -0.1f, transform.position.y);
        remainingTime -= Time.deltaTime;
        transform.Translate(Vector2.left * Time.deltaTime * enemySpeed);
        if (remainingTime <= 0)
        {
            remainingTime = shootingTime;
            Instantiate(enemyBullet, pos, Quaternion.identity);
        }
    }

}
