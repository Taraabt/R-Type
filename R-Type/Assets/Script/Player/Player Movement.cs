using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] TMP_Text hp;
    [SerializeField] TMP_Text scoreText;

    [SerializeField] Canvas canvas;
    public delegate void PlayerDeath();
    [SerializeField] Enemy enemy;
    public static event PlayerDeath OnDeath;
    [SerializeField] Bullet bullet;
    [SerializeField] float shootDelay;
    Rigidbody2D rb;
    float xMove, yMove;
    bool shoot;
    float shootingTime;
    public int score;
    public float powerUpTime;
    
    [SerializeField] float playerSpeed;
    [SerializeField]public int playerHp { get; set; }
    [SerializeField]public int nBullet { get; set; }
    [SerializeField] Button button;

    void Start()
    {
        score = 0;
        shootingTime = shootDelay;
        nBullet = 1;
        playerHp = 10;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        scoreText.text ="Score: "+ score;
        if (playerHp<0)
        {
            playerHp=0;
        }
        hp.text = "Hp:" + playerHp.ToString();


        powerUpTime-=Time.deltaTime;

        shootingTime -= Time.deltaTime;
        Debug.Log(playerHp);
        if (playerHp <= 0)
        {
            KillPlayer();
            //end the game 
        }else if(button.canMove){
            xMove = Input.GetAxis("Horizontal");
            yMove = Input.GetAxis("Vertical");

            rb.velocity = new Vector2(xMove, yMove) * playerSpeed;
            shoot = Input.GetKey(KeyCode.Space);
            if (shootingTime <= 0)
            {
                shootingTime = shootDelay;
                ShootBullet();
            }
        }

    }
    public void AddBullet()
    {
        nBullet= Random.Range(2, 5);
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
            score++;
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
        else if (shoot && nBullet > 1&&powerUpTime>0)
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
        else
        {
            nBullet = 1;
        }
    }
    private void OnEnable()
    {
        OnDeath += KillPlayer;
    }
    private void OnDisable()
    {
        OnDeath -= KillPlayer;
    }
    public void KillPlayer()
    {
        canvas.gameObject.SetActive(true);
        button.canMove = false;
    }


}
