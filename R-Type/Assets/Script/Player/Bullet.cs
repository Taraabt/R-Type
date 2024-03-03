using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float bulletSpeed;

    void Start()
    {
        transform.Translate(Vector2.right);
    }
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * bulletSpeed);
    }
}
