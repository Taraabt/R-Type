using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Button : MonoBehaviour
{
    public bool canMove;
    [SerializeField] Canvas canvas;

    public void StartGame()
    {
        canMove = true;
        canvas.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
