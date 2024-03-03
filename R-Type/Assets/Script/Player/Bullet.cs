using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float bulletSpeed;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        transform.Translate(Vector2.right);
    }
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * bulletSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>()!=null) {
            player.GetComponent<PlayerMovement>().score++;
        }
    }

}
