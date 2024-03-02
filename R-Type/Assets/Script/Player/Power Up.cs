using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField] float powerUpSpeed;
    [SerializeField] PlayerMovement player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>()!=null)
        {
            Destroy(this.gameObject);
        }
    }


    private void Start()
    {
        transform.Translate(Vector2.left * Time.deltaTime * powerUpSpeed);
    }
    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * powerUpSpeed);
    }


}
