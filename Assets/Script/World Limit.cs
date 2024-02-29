using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLimit : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject != player)
        {
           Destroy(collision.gameObject);
        }
    }
}
