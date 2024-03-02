using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField]Button button;
    public bool canMove =>button.canMove;
    [SerializeField] float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector2.right*Time.deltaTime * cameraSpeed);
        }


    }


}
