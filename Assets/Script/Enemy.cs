using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Bullet bullet;
    [SerializeField] PlayerMovement player;
    [SerializeField] int totalHp;
    int currentHp;


    private void Start()
    {
        currentHp = totalHp;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject==player.gameObject){
            player.playerHp = player.playerHp - 3;
        }else if(collision.gameObject == bullet.gameObject)
        {
            currentHp--;
        }
    }

    private void Update()
    {
        if(currentHp==0) {
            Destroy(transform.gameObject);
        }
        CheckOut();
    }

    public void CheckOut()
    {
        if (transform.position.x <= player.transform.position.x - 20f)
        {
            Destroy(transform.gameObject);
        }
    }
}
