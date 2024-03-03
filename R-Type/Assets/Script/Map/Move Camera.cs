using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField] EnemySpawner[] enemy;
    [SerializeField]Button button;
    public bool canMove =>button.canMove;
    [SerializeField] float cameraSpeed;
    [SerializeField] Canvas canvas;
    int i = 1;
    void Update()
    {
        if (transform.position.x>=i*47.5f){
            enemy[i].gameObject.GetComponent<EnemySpawner>().enabled = true;
            enemy[i-1].gameObject.GetComponent<EnemySpawner>().enabled = false;
            i++;
        }
        if (canMove&&transform.position.x<=124.5f)
        {
            transform.Translate(Vector2.right*Time.deltaTime * cameraSpeed);
        }else if(transform.position.x>=124.5){
            button.canMove = false;
            canvas.gameObject.SetActive(true);

        }



    }


}
