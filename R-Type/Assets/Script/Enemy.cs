using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Bullet bullet;
    [SerializeField] PlayerMovement player;
    [SerializeField] protected int totalHp;
    protected int currentHp;
    [SerializeField] protected float shootingTime;
    [SerializeField] protected float enemySpeed;
    [SerializeField] protected EnemyBullet enemyBullet;
    float remainingTime;

    private void Start()
    {
        currentHp = totalHp;
        remainingTime = shootingTime;
        transform.Translate(Vector2.left * Time.deltaTime * enemySpeed);
    }
    private void Update()
    {
        if(currentHp<=0) { 
            Destroy(gameObject);
        }
        if (currentHp <= 0)
        {
            Destroy(transform.gameObject);
        }
        CheckOut();
        Vector3 pos = new Vector2(transform.position.x - 0.1f, transform.position.y);
        remainingTime -= Time.deltaTime;
        transform.Translate(Vector2.left * Time.deltaTime * enemySpeed);
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
            player.playerHp -= 3;
            currentHp = 0;
        }
    }




}
