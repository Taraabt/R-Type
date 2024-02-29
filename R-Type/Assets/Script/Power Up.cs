using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{


    [SerializeField] PlayerMovement player;
    int nBullet => player.nBullet;
    [SerializeField] int proiettiliPowerUp;
    public delegate void Activation();
    public static event Activation ActivePowerUp;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        UsePowerUp();
        Destroy(this.gameObject);
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


}
