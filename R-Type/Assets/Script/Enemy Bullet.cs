using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{


    [SerializeField] float bulletSpeed;
    [SerializeField] PlayerMovement player;

    void Start()
    {
        transform.Translate(Vector2.left);
    }
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * bulletSpeed);
        if (transform.position.x <= player.transform.position.x - 20f)
        {
            Destroy(transform.gameObject);
        }
    }

    

}
