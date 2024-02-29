using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{


    [SerializeField] PlayerMovement player;
    int nBullet => player.nBullet;
    int proiettiliPowerUp;
    public delegate void Activation();
    public static event Activation ActivePowerUp;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject==player.gameObject)
        {
            UsePowerUp();
            Destroy(this.gameObject);
        }
    }


    private void OnEnable()
    {
         ActivePowerUp += UsePowerUp;
    }
    private void OnDisable()
    {
        ActivePowerUp += UsePowerUp;
    }
    public void UsePowerUp()
    {
        player.nBullet = proiettiliPowerUp;
    }
    private void Start()
    {
        proiettiliPowerUp=Random.Range(2,5);
    }


}
