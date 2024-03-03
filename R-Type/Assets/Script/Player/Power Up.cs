using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField] float powerUpSpeed;
    [SerializeField] GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>()!=null)
        {
            player.GetComponent<PlayerMovement>().powerUpTime=2;
            Destroy(this.gameObject);
        }
    }


    private void Start()
    {
        player = GameObject.Find("Player");
        transform.Translate(Vector2.left * Time.deltaTime * powerUpSpeed);
    }
    private void Update()
    {
        if (transform.position.x<=player.GetComponent<PlayerMovement>().transform.position.x -20f)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * Time.deltaTime * powerUpSpeed);
    }


}
