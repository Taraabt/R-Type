using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerMovement : MonoBehaviour
{



    [SerializeField]Bullet bullet;
    [SerializeField]EnemyBullet enemyBullet;
    [SerializeField]Enemy enemy;
    Rigidbody2D rb;
    float xMove, yMove;
    bool shoot;
    [SerializeField] float playerSpeed;
    [SerializeField]public int playerHp { get; set; }
    public int nBullet { get; set; }

    void Start()
    {
        nBullet = 1;
        playerHp = 3;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(playerHp);
        if (playerHp == 0)
        {
            Debug.Log("You are dead");
            //end the game 
        }

        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(xMove, yMove)*playerSpeed;



        shoot=Input.GetKeyDown(KeyCode.Space);

        Vector3 pos = new Vector2(transform.position.x+0.1f, transform.position.y);

        if (shoot&&nBullet==1)
        {
            Bullet instance;
            instance=Instantiate(bullet,pos,Quaternion.identity);
        }else if(shoot&&nBullet>1){
            Bullet instance;
            if (nBullet % 2 == 0){
                float number = nBullet;
                number++;
                for (int i = 0; i < number; i++) {
                    float distance = 45 / number;
                    if (i!=nBullet/2){
                        Quaternion quaternion = Quaternion.AngleAxis((i * distance) - distance * (number - 1) / 2, transform.forward);
                        instance = Instantiate(bullet, pos, quaternion);
                        instance.transform.rotation = quaternion;
                    }
                }
            }
            else{
                for (int i = 0; i < nBullet; i++){
                    float distance = 45 / nBullet;
                    Quaternion quaternion = Quaternion.AngleAxis((i * distance) - distance * (nBullet-1) / 2, transform.forward);
                    instance = Instantiate(bullet, pos, quaternion);
                    instance.transform.rotation = quaternion;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


    }


}
