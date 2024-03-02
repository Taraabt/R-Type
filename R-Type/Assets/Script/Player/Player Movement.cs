using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerMovement : MonoBehaviour
{

    public delegate void Death();
    public static event Death OnDeath;
    [SerializeField] Bullet bullet;
    //[SerializeField] Enemy enemy;
    [SerializeField] float shootDelay;
    Rigidbody2D rb;
    float xMove, yMove;
    bool shoot;
    float remainingTime;
    [SerializeField] float playerSpeed;
    [SerializeField]public int playerHp { get; set; }
    [SerializeField]public int nBullet { get; set; }

    void Start()
    {
        remainingTime = shootDelay;
        nBullet = 1;
        playerHp = 10;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;
        Debug.Log(playerHp);
        if (playerHp <= 0)
        {
            Debug.Log("You are dead");
            KillPlayer();
            //end the game 
        }else{
            xMove = Input.GetAxis("Horizontal");
            yMove = Input.GetAxis("Vertical");

            rb.velocity = new Vector2(xMove, yMove) * playerSpeed;
            shoot = Input.GetKey(KeyCode.Space);
            Debug.Log(shoot);
            if (remainingTime <= 0)
            {
                remainingTime = shootDelay;
                ShootBullet();
            }
        }

    }
    public void AddBullet()
    {
        nBullet= Random.Range(2, 4);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBullet>() != null)
        {
            playerHp--;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            playerHp -= 3;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PowerUp>() != null)
        {
            AddBullet();
        }
    }

    void ShootBullet()
    {
        Vector3 pos = new Vector2(transform.position.x + 0.1f, transform.position.y);
        if (shoot && nBullet == 1)
        {
            Bullet instance;
            instance = Instantiate(bullet, pos, Quaternion.identity);
        }
        else if (shoot && nBullet > 1)
        {
            Bullet instance;
            if (nBullet % 2 == 0)
            {
                float number = nBullet;
                number++;
                for (int i = 0; i < number; i++)
                {
                    float distance = 45 / number;
                    if (i != nBullet / 2)
                    {
                        Quaternion quaternion = Quaternion.AngleAxis((i * distance) - distance * (number - 1) / 2, transform.forward);
                        instance = Instantiate(bullet, pos, quaternion);
                        instance.transform.rotation = quaternion;
                    }
                }
            }
            else
            {
                for (int i = 0; i < nBullet; i++)
                {
                    float distance = 45 / nBullet;
                    Quaternion quaternion = Quaternion.AngleAxis((i * distance) - distance * (nBullet - 1) / 2, transform.forward);
                    instance = Instantiate(bullet, pos, quaternion);
                    instance.transform.rotation = quaternion;
                }
            }
        }
    }
    private void OnEnable()
    {
        OnDeath += KillPlayer;
    }
    private void OnDisable()
    {
        OnDeath += KillPlayer;
    }
    public void KillPlayer()
    {
        Debug.Log("Death");
    }


}
