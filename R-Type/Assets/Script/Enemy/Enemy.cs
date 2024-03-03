using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{

    [SerializeField]float move;
    GameObject player;
    [SerializeField] PowerUp powerUp;
    [SerializeField] protected int totalHp;
    protected int currentHp;
    [SerializeField] protected float shootingTime;
    [SerializeField] public float enemySpeed;
    [SerializeField] protected EnemyBullet enemyBullet;
    float remainingTime;

    private void Start()
    {
        player = GameObject.Find("Player");
        currentHp = totalHp;
        remainingTime = shootingTime;
        transform.Translate(Vector2.left * Time.deltaTime * enemySpeed);
    }

    private void Update()
    {


        if(currentHp<=0){

            if (Random.Range(0,3)==2)
            {
                Instantiate(powerUp, transform.position,Quaternion.identity);
            }
            player.GetComponent<PlayerMovement>().score++;
            Destroy(gameObject);
        }
        CheckOut();
        Vector3 pos = new Vector2(transform.position.x - 0.1f, transform.position.y);
        remainingTime -= Time.deltaTime;

        transform.Translate(new Vector2(-1f, move * Mathf.Sin(Time.time)) * Time.deltaTime * enemySpeed);
        if (remainingTime <= 0)
        {
            remainingTime = shootingTime;
            Instantiate(enemyBullet, pos, Quaternion.identity);
        }
    }
    public void CheckOut()
    {
        if (transform.position.x <= player.transform.position.x - 20f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionCheck(collision);
    }

    public void CollisionCheck(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>()!=null)
        {
            currentHp--;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            currentHp = 0;
        }
    }



}
